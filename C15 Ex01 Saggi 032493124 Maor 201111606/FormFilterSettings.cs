using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
    public partial class FormFilterSettings : Form
    {
        public List<PostFilterGroup> PostFilterGroup { get; set; }

	    public FormFilterSettings()
	    {
		    InitializeComponent();
        }

        private void filterSettingsForm_Load(object i_Sender, EventArgs i_Args)
        {
            foreach(PostFilterGroup group in PostFilterGroup)
            {
                checkedListBoxFilterGroups.Items.Add(group, group.Enabled);
            }
        }

        private void buttonAddGroup_Click(object i_Sender, EventArgs i_Args)
        {
            FormAddNewGroup formAddGroup = new FormAddNewGroup();
            formAddGroup.ShowDialog();
            if (formAddGroup.DialogResult == DialogResult.OK)
            {
                checkedListBoxFilterGroups.Items.Add(formAddGroup.NewFilterGroup, formAddGroup.NewFilterGroup.Enabled);
                PostFilterGroup.Add(formAddGroup.NewFilterGroup);
            }
        }
        
		private void buttonRemoveSelectedGroups_Click(object i_Sender, EventArgs i_Args)
        {
            PostFilterGroup groupToDelete = (PostFilterGroup)checkedListBoxFilterGroups.SelectedItem;
            checkedListBoxFilterGroups.Items.Remove(groupToDelete);
            PostFilterGroup.Remove(groupToDelete);
        }

		private void buttonClose_Click(object i_Sender, EventArgs i_Args)
        {         
            this.Close();
        }

		private void buttonEditMarked_Click(object i_Sender, EventArgs i_Args)
        {
            if (checkedListBoxFilterGroups.SelectedItem != null)
            {
                PostFilterGroup postFilterGroup = (PostFilterGroup)checkedListBoxFilterGroups.SelectedItem;
                FormEditFilterGroup editFilterGroupForm = new FormEditFilterGroup();
                editFilterGroupForm.FilterGroup = postFilterGroup;
                editFilterGroupForm.ShowDialog();
            }
        }

		private void checkedListBoxFilterGroups_ItemCheck(object i_Sender, ItemCheckEventArgs i_Args)
		{
			PostFilterGroup group = (PostFilterGroup)checkedListBoxFilterGroups.Items[i_Args.Index];
			switch (i_Args.NewValue)
			{
				case CheckState.Unchecked:
					group.Enabled = false;
					break;
				case CheckState.Checked:
					group.Enabled = true;
					break;
			}
		}
    }
}
