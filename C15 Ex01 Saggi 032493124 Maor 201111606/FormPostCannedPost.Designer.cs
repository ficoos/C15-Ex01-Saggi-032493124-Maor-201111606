namespace C15_Ex01_Saggi_032493124_Maor_201111606
{
    partial class FormPostCannedPost
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
			this.buttonPost = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.textBoxTemplate = new System.Windows.Forms.TextBox();
			this.splitContainerMain = new System.Windows.Forms.SplitContainer();
			this.tableLayoutDyamicNodes = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
			this.splitContainerMain.Panel1.SuspendLayout();
			this.splitContainerMain.Panel2.SuspendLayout();
			this.splitContainerMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonPost
			// 
			this.buttonPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPost.Location = new System.Drawing.Point(453, 391);
			this.buttonPost.Name = "buttonPost";
			this.buttonPost.Size = new System.Drawing.Size(75, 23);
			this.buttonPost.TabIndex = 11;
			this.buttonPost.Text = "Post";
			this.buttonPost.UseVisualStyleBackColor = true;
			this.buttonPost.Click += new System.EventHandler(this.buttonPost_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.Location = new System.Drawing.Point(534, 391);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 10;
			this.buttonCancel.Text = "Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// textBoxTemplate
			// 
			this.textBoxTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxTemplate.Location = new System.Drawing.Point(0, 3);
			this.textBoxTemplate.Multiline = true;
			this.textBoxTemplate.Name = "textBoxTemplate";
			this.textBoxTemplate.Size = new System.Drawing.Size(594, 177);
			this.textBoxTemplate.TabIndex = 8;
			// 
			// splitContainerMain
			// 
			this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainerMain.Location = new System.Drawing.Point(12, 12);
			this.splitContainerMain.Name = "splitContainerMain";
			this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerMain.Panel1
			// 
			this.splitContainerMain.Panel1.AutoScroll = true;
			this.splitContainerMain.Panel1.Controls.Add(this.tableLayoutDyamicNodes);
			// 
			// splitContainerMain.Panel2
			// 
			this.splitContainerMain.Panel2.Controls.Add(this.textBoxTemplate);
			this.splitContainerMain.Size = new System.Drawing.Size(597, 373);
			this.splitContainerMain.SplitterDistance = 186;
			this.splitContainerMain.TabIndex = 12;
			// 
			// tableLayoutDyamicNodes
			// 
			this.tableLayoutDyamicNodes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutDyamicNodes.AutoSize = true;
			this.tableLayoutDyamicNodes.ColumnCount = 2;
			this.tableLayoutDyamicNodes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.576271F));
			this.tableLayoutDyamicNodes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.42373F));
			this.tableLayoutDyamicNodes.Location = new System.Drawing.Point(4, 4);
			this.tableLayoutDyamicNodes.Name = "tableLayoutDyamicNodes";
			this.tableLayoutDyamicNodes.RowCount = 1;
			this.tableLayoutDyamicNodes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutDyamicNodes.Size = new System.Drawing.Size(590, 24);
			this.tableLayoutDyamicNodes.TabIndex = 0;
			// 
			// FormPostCannedPost
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(621, 426);
			this.Controls.Add(this.splitContainerMain);
			this.Controls.Add(this.buttonPost);
			this.Controls.Add(this.buttonCancel);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "FormPostCannedPost";
			this.Text = "Post Canned Post";
			this.splitContainerMain.Panel1.ResumeLayout(false);
			this.splitContainerMain.Panel1.PerformLayout();
			this.splitContainerMain.Panel2.ResumeLayout(false);
			this.splitContainerMain.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
			this.splitContainerMain.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxTemplate;
		private System.Windows.Forms.SplitContainer splitContainerMain;
		private System.Windows.Forms.TableLayoutPanel tableLayoutDyamicNodes;

    }
}