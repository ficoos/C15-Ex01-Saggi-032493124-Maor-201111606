using System;
using System.Windows.Forms;

namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
    public partial class FormEditFilterGroup : Form
    {
        public PostFilterGroup FilterGroup { get; set; }

        public FormEditFilterGroup()
        {
            InitializeComponent();
        }

        public void LoadFilterGroup()
        {
            this.comboBoxPriority.Items.Add(ePostPriority.Demoted);
            this.comboBoxPriority.Items.Add(ePostPriority.Hidden);
            this.comboBoxPriority.Items.Add(ePostPriority.Promoted);
            this.comboBoxPriority.SelectedItem = this.FilterGroup.PostPriority;
            this.Text = this.FilterGroup.Name;
            foreach(IPostFilter filter in this.FilterGroup.PostFilters)
            {
	            checkedListBoxFilterFilters.Items.Add(filter, filter.Enabled);
            }
        }

        private void buttonAddFilter_Click(object i_Sender, EventArgs i_Args)
        {
            if (textBoxAddFilter.Text.Length > 0)
            {
                RegexPostFilter newFilter = new RegexPostFilter(textBoxAddFilter.Text);
                checkedListBoxFilterFilters.Items.Add(newFilter, newFilter.Enabled);
                this.FilterGroup.PostFilters.Add(newFilter);
                textBoxAddFilter.Text = string.Empty;
            }
        }

        private void buttonClose_Click(object i_Sender, EventArgs i_Args)
        {
            Close();
        }

        private void buttonRemoveSelectedGroups_Click(object i_Sender, EventArgs i_Args)
        {
            IPostFilter obj = (IPostFilter)checkedListBoxFilterFilters.SelectedItem;
            checkedListBoxFilterFilters.Items.Remove(obj);
            this.FilterGroup.RemovePostFilter(obj);
        }

        private void comboBoxPriority_SelectionChangeCommitted(object i_Sender, EventArgs i_Args)
        {
            this.FilterGroup.PostPriority = (ePostPriority)comboBoxPriority.SelectedItem;
        }

        private void checkedListBoxFilterFilters_ItemCheck(object i_Sender, ItemCheckEventArgs i_Args)
        {
	        IPostFilter filter = (IPostFilter)checkedListBoxFilterFilters.Items[i_Args.Index];
	        switch (i_Args.NewValue)
	        {
		        case CheckState.Unchecked:
			        filter.Enabled = false;
			        break;
		        case CheckState.Checked:
			        filter.Enabled = true;
			        break;
	        }
        }
    }
}
