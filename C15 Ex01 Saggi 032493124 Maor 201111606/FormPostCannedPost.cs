using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
    public partial class FormPostCannedPost : Form
    {
        private Point m_StartFormPosition;

        public CannedPost CannedPost { get; set; }

        Dictionary<string, TextBox> m_DynamicTextBoxes;

        private Template CurrTemplate;

        public User m_LoggedInUser;

	    public FormPostCannedPost()
	    {
			InitializeComponent();
	    }

	    protected override void OnShown(EventArgs e)
	    {
		    base.OnShown(e);
			StartForm();
	    }

	    public void StartForm()
        {
            CurrTemplate = Template.DeepCloneWithDummyValuesForDynmicText(this.CannedPost.StatusTextTemplate);
            m_StartFormPosition = new Point(10, 10);
            var AllKeys = CurrTemplate.Keys;
            foreach (string Key in AllKeys)
            {
                Label newLable = new Label();
                newLable.Visible = true;
                newLable.Text = Key + ":";
	            newLable.AutoSize = true;
                
                TextBox newTextbox = new TextBox();
                newTextbox.Left = newLable.Width + 20;
                newTextbox.Name = "TextBoxDynamic" + Key;
	            newTextbox.Anchor = AnchorStyles.Right | AnchorStyles.Left;
				newTextbox.Width = (int)this.tableLayoutDyamicNodes.ColumnStyles[1].Width;
               
				tableLayoutDyamicNodes.ColumnStyles[0].SizeType = SizeType.AutoSize;
				tableLayoutDyamicNodes.Controls.Add(newLable);
				tableLayoutDyamicNodes.Controls.Add(newTextbox);
                newTextbox.TextChanged += new System.EventHandler(this.textBoxDynamic_TextChanged);
            }
            textBoxTemplate.Text = CurrTemplate.ToString();
        }

        private void textBoxDynamic_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;


                int index = textbox.Name.IndexOf("TextBoxDynamic");
                string Name = (index < 0)     ? textbox.Name     : textbox.Name.Remove(index, "TextBoxDynamic".Length);
                CurrTemplate.GetDynamicTextNodeValueByKey(Name).Text = textbox.Text;
                textBoxTemplate.Text = CurrTemplate.ToString();
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            string statusText = textBoxTemplate.Text.Trim();
            if (!string.IsNullOrEmpty(statusText))
            {
                Status status = m_LoggedInUser.PostStatus(textBoxTemplate.Text);
                MessageBox.Show(@"Status Posted! ID: " + status.Id);
            }
            
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
