namespace TaskManager.UI
{
    partial class CommentControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableComment = new System.Windows.Forms.TableLayoutPanel();
            this.flowUserName = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUserNameLbl = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDateLbl = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.linkToggleVisible = new System.Windows.Forms.LinkLabel();
            this.linkDelete = new System.Windows.Forms.LinkLabel();
            this.tableComment.SuspendLayout();
            this.flowUserName.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableComment
            // 
            this.tableComment.ColumnCount = 2;
            this.tableComment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableComment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableComment.Controls.Add(this.flowUserName, 0, 0);
            this.tableComment.Controls.Add(this.panel1, 1, 0);
            this.tableComment.Controls.Add(this.txtComment, 0, 1);
            this.tableComment.Controls.Add(this.linkToggleVisible, 0, 2);
            this.tableComment.Controls.Add(this.linkDelete, 1, 2);
            this.tableComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableComment.Location = new System.Drawing.Point(0, 0);
            this.tableComment.Name = "tableComment";
            this.tableComment.RowCount = 3;
            this.tableComment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableComment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableComment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableComment.Size = new System.Drawing.Size(283, 150);
            this.tableComment.TabIndex = 0;
            // 
            // flowUserName
            // 
            this.flowUserName.Controls.Add(this.lblUserNameLbl);
            this.flowUserName.Controls.Add(this.lblUserName);
            this.flowUserName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowUserName.Location = new System.Drawing.Point(3, 3);
            this.flowUserName.Name = "flowUserName";
            this.flowUserName.Size = new System.Drawing.Size(135, 15);
            this.flowUserName.TabIndex = 3;
            // 
            // lblUserNameLbl
            // 
            this.lblUserNameLbl.AutoSize = true;
            this.lblUserNameLbl.Location = new System.Drawing.Point(3, 0);
            this.lblUserNameLbl.Name = "lblUserNameLbl";
            this.lblUserNameLbl.Size = new System.Drawing.Size(35, 13);
            this.lblUserNameLbl.TabIndex = 0;
            this.lblUserNameLbl.Text = "User: ";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(44, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(0, 13);
            this.lblUserName.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.lblDateLbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(144, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(136, 15);
            this.panel1.TabIndex = 4;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(34, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(10, 13);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "-";
            // 
            // lblDateLbl
            // 
            this.lblDateLbl.AutoSize = true;
            this.lblDateLbl.Location = new System.Drawing.Point(0, 0);
            this.lblDateLbl.Name = "lblDateLbl";
            this.lblDateLbl.Size = new System.Drawing.Size(36, 13);
            this.lblDateLbl.TabIndex = 0;
            this.lblDateLbl.Text = "Date: ";
            // 
            // txtComment
            // 
            this.tableComment.SetColumnSpan(this.txtComment, 2);
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComment.ForeColor = System.Drawing.Color.Black;
            this.txtComment.Location = new System.Drawing.Point(3, 24);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(277, 103);
            this.txtComment.TabIndex = 5;
            // 
            // linkToggleVisible
            // 
            this.linkToggleVisible.AutoSize = true;
            this.linkToggleVisible.Location = new System.Drawing.Point(3, 130);
            this.linkToggleVisible.Name = "linkToggleVisible";
            this.linkToggleVisible.Size = new System.Drawing.Size(29, 13);
            this.linkToggleVisible.TabIndex = 6;
            this.linkToggleVisible.TabStop = true;
            this.linkToggleVisible.Text = "Hide";
            this.linkToggleVisible.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkToggleVisible_LinkClicked);
            // 
            // linkDelete
            // 
            this.linkDelete.AutoSize = true;
            this.linkDelete.Location = new System.Drawing.Point(144, 130);
            this.linkDelete.Name = "linkDelete";
            this.linkDelete.Size = new System.Drawing.Size(38, 13);
            this.linkDelete.TabIndex = 7;
            this.linkDelete.TabStop = true;
            this.linkDelete.Text = "Delete";
            this.linkDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDelete_LinkClicked);
            // 
            // CommentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableComment);
            this.Name = "CommentControl";
            this.Size = new System.Drawing.Size(283, 150);
            this.tableComment.ResumeLayout(false);
            this.tableComment.PerformLayout();
            this.flowUserName.ResumeLayout(false);
            this.flowUserName.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableComment;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.FlowLayoutPanel flowUserName;
        private System.Windows.Forms.Label lblUserNameLbl;
        private System.Windows.Forms.Label lblDateLbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.LinkLabel linkToggleVisible;
        private System.Windows.Forms.LinkLabel linkDelete;
    }
}
