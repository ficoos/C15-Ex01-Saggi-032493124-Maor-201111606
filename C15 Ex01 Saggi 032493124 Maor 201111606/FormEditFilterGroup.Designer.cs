namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
    partial class FormEditFilterGroup
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonRemoveSelectedGroups = new System.Windows.Forms.Button();
			this.buttonAddFilter = new System.Windows.Forms.Button();
			this.checkedListBoxFilterFilters = new System.Windows.Forms.CheckedListBox();
			this.comboBoxPriority = new System.Windows.Forms.ComboBox();
			this.textBoxAddFilter = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.postFilterGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.postFilterGroupBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonClose
			// 
			this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonClose.Location = new System.Drawing.Point(11, 334);
			this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(359, 27);
			this.buttonClose.TabIndex = 7;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// buttonRemoveSelectedGroups
			// 
			this.buttonRemoveSelectedGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRemoveSelectedGroups.Location = new System.Drawing.Point(11, 305);
			this.buttonRemoveSelectedGroups.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonRemoveSelectedGroups.Name = "buttonRemoveSelectedGroups";
			this.buttonRemoveSelectedGroups.Size = new System.Drawing.Size(359, 25);
			this.buttonRemoveSelectedGroups.TabIndex = 6;
			this.buttonRemoveSelectedGroups.Text = "Remove Selected filters";
			this.buttonRemoveSelectedGroups.UseVisualStyleBackColor = true;
			this.buttonRemoveSelectedGroups.Click += new System.EventHandler(this.buttonRemoveSelectedGroups_Click);
			// 
			// buttonAddFilter
			// 
			this.buttonAddFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonAddFilter.Location = new System.Drawing.Point(276, 63);
			this.buttonAddFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.buttonAddFilter.Name = "buttonAddFilter";
			this.buttonAddFilter.Size = new System.Drawing.Size(95, 23);
			this.buttonAddFilter.TabIndex = 4;
			this.buttonAddFilter.Text = "Add new filter";
			this.buttonAddFilter.UseVisualStyleBackColor = true;
			this.buttonAddFilter.Click += new System.EventHandler(this.buttonAddFilter_Click);
			// 
			// checkedListBoxFilterFilters
			// 
			this.checkedListBoxFilterFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkedListBoxFilterFilters.FormattingEnabled = true;
			this.checkedListBoxFilterFilters.Location = new System.Drawing.Point(11, 90);
			this.checkedListBoxFilterFilters.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.checkedListBoxFilterFilters.Name = "checkedListBoxFilterFilters";
			this.checkedListBoxFilterFilters.Size = new System.Drawing.Size(360, 199);
			this.checkedListBoxFilterFilters.TabIndex = 5;
			this.checkedListBoxFilterFilters.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxFilterFilters_ItemCheck);
			// 
			// comboBoxPriority
			// 
			this.comboBoxPriority.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboBoxPriority.FormattingEnabled = true;
			this.comboBoxPriority.Location = new System.Drawing.Point(12, 25);
			this.comboBoxPriority.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.comboBoxPriority.Name = "comboBoxPriority";
			this.comboBoxPriority.Size = new System.Drawing.Size(359, 21);
			this.comboBoxPriority.TabIndex = 1;
			this.comboBoxPriority.SelectionChangeCommitted += new System.EventHandler(this.comboBoxPriority_SelectionChangeCommitted);
			// 
			// textBoxAddFilter
			// 
			this.textBoxAddFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxAddFilter.Location = new System.Drawing.Point(11, 63);
			this.textBoxAddFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.textBoxAddFilter.Name = "textBoxAddFilter";
			this.textBoxAddFilter.Size = new System.Drawing.Size(261, 20);
			this.textBoxAddFilter.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Priority:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Filter Expression:";
			// 
			// postFilterGroupBindingSource
			// 
			this.postFilterGroupBindingSource.DataSource = typeof(C15_Ex01_Saggi_032493124_Maor_201111606.PostFilterGroup);
			// 
			// FormEditFilterGroup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 366);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxAddFilter);
			this.Controls.Add(this.comboBoxPriority);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonRemoveSelectedGroups);
			this.Controls.Add(this.buttonAddFilter);
			this.Controls.Add(this.checkedListBoxFilterFilters);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MinimumSize = new System.Drawing.Size(400, 400);
			this.Name = "FormEditFilterGroup";
			this.Text = "Edit Filter Group";
			((System.ComponentModel.ISupportInitialize)(this.postFilterGroupBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonRemoveSelectedGroups;
        private System.Windows.Forms.Button buttonAddFilter;
        private System.Windows.Forms.CheckedListBox checkedListBoxFilterFilters;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.BindingSource postFilterGroupBindingSource;
        private System.Windows.Forms.TextBox textBoxAddFilter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
    }
}