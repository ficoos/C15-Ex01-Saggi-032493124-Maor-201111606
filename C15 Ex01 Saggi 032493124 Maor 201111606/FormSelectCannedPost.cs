using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
	using System.CodeDom;
	using System.IO;
	using System.Xml.Serialization;

	public partial class FormSelectCannedPost : Form
	{
		public CannedPost SelectedPost { get; private set; }

		public string CannedPostsDirectoryPath { get; set; }

		public FormSelectCannedPost()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			refreshPostList();
			base.OnShown(e);
		}

		private void refreshPostList()
		{
			listBoxCannedPosts.DataSource = Directory.GetFiles(this.CannedPostsDirectoryPath)
				.Where(i_FileName => i_FileName.ToLower().EndsWith(".post.xml"))
				.Select(Path.GetFileName)
				.ToList();
		}

		private void buttonCancel_Click(object i_Sender, EventArgs i_Args)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void buttonSelect_Click(object i_Sender, EventArgs i_Args)
		{
			this.SelectedPost = listBoxCannedPosts.SelectedItem as CannedPost;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonCreateNew_Click(object i_Sender, EventArgs i_Args)
		{
			showEditPost(null);
		}

		private void buttonEdit_Click(object i_Sender, EventArgs i_Args)
		{
			string selectedPostName = listBoxCannedPosts.SelectedItem as string;
			if (selectedPostName != null)
			{
				string selectedPostPath = Path.Combine(CannedPostsDirectoryPath, selectedPostName);
				XmlSerializer serializer = new XmlSerializer(typeof(CannedPost));
				CannedPost post;
				using (TextReader reader = new StreamReader(selectedPostPath))
				{
					post = serializer.Deserialize(reader) as CannedPost;
				}
				
				showEditPost(post);
			}
		}

		private void showEditPost(CannedPost i_Post)
		{
			FormEditCannedPost editForm = new FormEditCannedPost();
			editForm.CannedPost = i_Post;
			editForm.ShowDialog();
			if (editForm.DialogResult == DialogResult.OK)
			{
				XmlSerializer serializer = new XmlSerializer(typeof(CannedPost));
				using (TextWriter writer = new StreamWriter(Path.Combine(this.CannedPostsDirectoryPath, editForm.CannedPost.Name + ".post.xml")))
				{
					serializer.Serialize(writer, editForm.CannedPost);
				}
			}

			refreshPostList();
		}
	}
}
