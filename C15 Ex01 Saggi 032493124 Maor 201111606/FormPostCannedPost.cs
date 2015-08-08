using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
	using System.Collections.Generic;

	public partial class FormPostCannedPost : Form
    {
		private readonly Dictionary<string, string> r_DynamicParts = new Dictionary<string, string>();

        public CannedPost CannedPost { get; set; }

		public PostInfo CompiledPost { get; private set; }

		private Template m_Template;

	    public FormPostCannedPost()
	    {
			InitializeComponent();
	    }

	    protected override void OnShown(EventArgs i_Args)
	    {
		    base.OnShown(i_Args);
			this.initializeForm();
	    }

	    private void initializeForm()
	    {
			this.r_DynamicParts.Clear();
		    this.m_Template = CannedPost.StatusTextTemplate;
            foreach (string key in m_Template.Keys)
            {
				this.r_DynamicParts[key] = string.Format("{{{{{0}}}}}", key);
	            Label newLable = new Label
				{
					Visible = true,
					Text = key + @":",
					AutoSize = true
				};

	            TextBox newTextbox = new TextBox
				{
					Left = newLable.Width + 20,
					Name = "TextBoxDynamic" + key,
					Anchor = AnchorStyles.Right | AnchorStyles.Left,
					Width = (int)tableLayoutDyamicNodes.ColumnStyles[1].Width
				};

	            tableLayoutDyamicNodes.ColumnStyles[0].SizeType = SizeType.AutoSize;
				tableLayoutDyamicNodes.Controls.Add(newLable);
				tableLayoutDyamicNodes.Controls.Add(newTextbox);
                newTextbox.TextChanged += textBoxDynamic_TextChanged;
            }

			textBoxTemplate.Text = m_Template.Compile(this.r_DynamicParts);
        }

	    private void textBoxDynamic_TextChanged(object i_Sender, EventArgs i_Args)
	    {
		    TextBox textbox = (TextBox)i_Sender;
		    int index = textbox.Name.IndexOf("TextBoxDynamic", StringComparison.Ordinal);
		    string name = (index < 0) ? textbox.Name : textbox.Name.Remove(index, "TextBoxDynamic".Length);
			if (string.IsNullOrEmpty(textbox.Text))
			{
				this.r_DynamicParts[name] = string.Format("{{{{{0}}}}}", name);
			}
			else
			{
				this.r_DynamicParts[name] = textbox.Text;
			}

		    textBoxTemplate.Text = m_Template.Compile(this.r_DynamicParts);
	    }

	    private void buttonPost_Click(object i_Sender, EventArgs i_Args)
	    {
		    CompiledPost = CannedPost.GeneratePost(r_DynamicParts);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object i_Sender, EventArgs i_Args)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
