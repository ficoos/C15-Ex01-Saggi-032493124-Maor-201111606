namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
    partial class AddNewGroupForm
    {
        public PostFilterGroup NewFilterGroup;
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
			this.textBoxGroupName = new System.Windows.Forms.TextBox();
			this.labelGroupName = new System.Windows.Forms.Label();
			this.comboBoxPriority = new System.Windows.Forms.ComboBox();
			this.labelPriority = new System.Windows.Forms.Label();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textBoxGroupName
			// 
			this.textBoxGroupName.Location = new System.Drawing.Point(85, 11);
			this.textBoxGroupName.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxGroupName.Name = "textBoxGroupName";
			this.textBoxGroupName.Size = new System.Drawing.Size(135, 20);
			this.textBoxGroupName.TabIndex = 1;
			// 
			// labelGroupName
			// 
			this.labelGroupName.AutoSize = true;
			this.labelGroupName.Location = new System.Drawing.Point(11, 9);
			this.labelGroupName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelGroupName.Name = "labelGroupName";
			this.labelGroupName.Size = new System.Drawing.Size(70, 13);
			this.labelGroupName.TabIndex = 0;
			this.labelGroupName.Text = "Group Name:";
			// 
			// comboBoxPriority
			// 
			this.comboBoxPriority.CausesValidation = false;
			this.comboBoxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxPriority.FormattingEnabled = true;
			this.comboBoxPriority.Items.AddRange(new object[] {
            C15_Ex01_Saggi_032493124_Maor_201111606.ePostPriority.Demoted,
            C15_Ex01_Saggi_032493124_Maor_201111606.ePostPriority.Hidden,
            C15_Ex01_Saggi_032493124_Maor_201111606.ePostPriority.Promoted});
			this.comboBoxPriority.Location = new System.Drawing.Point(85, 35);
			this.comboBoxPriority.Margin = new System.Windows.Forms.Padding(2);
			this.comboBoxPriority.Name = "comboBoxPriority";
			this.comboBoxPriority.Size = new System.Drawing.Size(135, 21);
			this.comboBoxPriority.TabIndex = 3;
			// 
			// labelPriority
			// 
			this.labelPriority.AutoSize = true;
			this.labelPriority.Location = new System.Drawing.Point(11, 38);
			this.labelPriority.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPriority.Name = "labelPriority";
			this.labelPriority.Size = new System.Drawing.Size(41, 13);
			this.labelPriority.TabIndex = 2;
			this.labelPriority.Text = "Priority:";
			// 
			// buttonAdd
			// 
			this.buttonAdd.Location = new System.Drawing.Point(52, 60);
			this.buttonAdd.Margin = new System.Windows.Forms.Padding(2);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(82, 23);
			this.buttonAdd.TabIndex = 4;
			this.buttonAdd.Text = "Add";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(138, 60);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(82, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// AddNewGroupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(226, 93);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonAdd);
			this.Controls.Add(this.labelPriority);
			this.Controls.Add(this.comboBoxPriority);
			this.Controls.Add(this.labelGroupName);
			this.Controls.Add(this.textBoxGroupName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "AddNewGroupForm";
			this.Text = "Add New Group";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxGroupName;
        private System.Windows.Forms.Label labelGroupName;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonCancel;
    }
}