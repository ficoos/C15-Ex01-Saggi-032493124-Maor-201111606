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
	public partial class FormEditCannedPost : Form
	{
		public CannedPost CannedPost { get; set; }

		public FormEditCannedPost()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs i_Args)
		{
			this.initializeControls();
			base.OnShown(i_Args);
		}

		private void initializeControls()
		{
			if (CannedPost != null)
			{
				this.textBoxName.Enabled = false;
				this.textBoxName.Text = CannedPost.Name;
				this.textBoxCategories.Text = string.Join(", ", CannedPost.Categories);
				this.textBoxTemplate.Text = CannedPost.StatusTextTemplate == null ? string.Empty : CannedPost.StatusTextTemplate.ToString();
			}
		}

		private void buttonCancel_Click(object i_Sender, EventArgs i_Args)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void buttonSave_Click(object i_Sender, EventArgs i_Args)
		{
			if (CannedPost == null)
			{
				CannedPost = new CannedPost();
			}

			CannedPost.Name = this.textBoxName.Text;
			CannedPost.Categories.Clear();
			foreach (string category in textBoxCategories.Text.Split(','))
			{
				string trimmedCategory = category.Trim();
				if (!string.IsNullOrEmpty(trimmedCategory))
				{
					CannedPost.Categories.Add(trimmedCategory.Trim());
				}
			}

			CannedPost.StatusTextTemplate = Template.Parse(textBoxTemplate.Text);
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
