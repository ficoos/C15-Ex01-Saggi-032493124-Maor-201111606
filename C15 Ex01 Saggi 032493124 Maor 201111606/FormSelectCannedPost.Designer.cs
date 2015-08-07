namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
	partial class FormSelectCannedPost
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
			this.listBoxCannedPosts = new System.Windows.Forms.ListBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonCreateNew = new System.Windows.Forms.Button();
			this.buttonEdit = new System.Windows.Forms.Button();
			this.buttonSelect = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBoxCannedPosts
			// 
			this.listBoxCannedPosts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBoxCannedPosts.FormattingEnabled = true;
			this.listBoxCannedPosts.Location = new System.Drawing.Point(13, 13);
			this.listBoxCannedPosts.Name = "listBoxCannedPosts";
			this.listBoxCannedPosts.Size = new System.Drawing.Size(398, 212);
			this.listBoxCannedPosts.TabIndex = 0;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(335, 232);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 1;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// buttonCreateNew
			// 
			this.buttonCreateNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCreateNew.Location = new System.Drawing.Point(227, 232);
			this.buttonCreateNew.Name = "buttonCreateNew";
			this.buttonCreateNew.Size = new System.Drawing.Size(102, 23);
			this.buttonCreateNew.TabIndex = 2;
			this.buttonCreateNew.Text = "Cerate New...";
			this.buttonCreateNew.UseVisualStyleBackColor = true;
			this.buttonCreateNew.Click += new System.EventHandler(this.buttonCreateNew_Click);
			// 
			// buttonEdit
			// 
			this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonEdit.Location = new System.Drawing.Point(119, 232);
			this.buttonEdit.Name = "buttonEdit";
			this.buttonEdit.Size = new System.Drawing.Size(102, 23);
			this.buttonEdit.TabIndex = 3;
			this.buttonEdit.Text = "Edit...";
			this.buttonEdit.UseVisualStyleBackColor = true;
			this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
			// 
			// buttonSelect
			// 
			this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelect.Location = new System.Drawing.Point(11, 232);
			this.buttonSelect.Name = "buttonSelect";
			this.buttonSelect.Size = new System.Drawing.Size(102, 23);
			this.buttonSelect.TabIndex = 4;
			this.buttonSelect.Text = "Select";
			this.buttonSelect.UseVisualStyleBackColor = true;
			this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
			// 
			// FormSelectCannedPost
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(423, 262);
			this.Controls.Add(this.buttonSelect);
			this.Controls.Add(this.buttonEdit);
			this.Controls.Add(this.buttonCreateNew);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.listBoxCannedPosts);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MinimumSize = new System.Drawing.Size(439, 296);
			this.Name = "FormSelectCannedPost";
			this.Text = "Select Canned Post";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxCannedPosts;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonCreateNew;
		private System.Windows.Forms.Button buttonEdit;
		private System.Windows.Forms.Button buttonSelect;
	}
}