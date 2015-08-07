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
    public partial class AddNewGroupForm : Form
    {
        public AddNewGroupForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object i_Sender, EventArgs i_Args)
        {
            bool isValidInput = !string.IsNullOrEmpty(textBoxGroupName.Text) && comboBoxPriority.SelectedItem != null;
            if (isValidInput)
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
