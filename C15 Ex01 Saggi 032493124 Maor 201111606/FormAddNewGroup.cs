using System;
using System.Windows.Forms;

namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
    public partial class FormAddNewGroup : Form
    {
		public PostFilterGroup NewFilterGroup { get; private set; }

        public FormAddNewGroup()
        {
            InitializeComponent();
        }

	    private bool isFormValid()
	    {
			return !string.IsNullOrEmpty(textBoxGroupName.Text) && comboBoxPriority.SelectedItem != null;
	    }

        private void buttonAdd_Click(object i_Sender, EventArgs i_Args)
        {
            if (isFormValid())
            {
                NewFilterGroup = new PostFilterGroup(textBoxGroupName.Text, (ePostPriority)comboBoxPriority.SelectedItem);
                DialogResult = DialogResult.OK;
            }
        }

        private void buttonCancel_Click(object i_Sender, EventArgs i_Args)
        {
            DialogResult = DialogResult.Cancel;
            this.Dispose();
        }
    }
}
