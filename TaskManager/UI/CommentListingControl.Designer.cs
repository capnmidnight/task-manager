namespace TaskManager.UI
{
    partial class CommentListingControl
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
            this.splitCommentContainer = new System.Windows.Forms.SplitContainer();
            this.tableAddComment = new System.Windows.Forms.TableLayoutPanel();
            this.lblAddComment = new System.Windows.Forms.Label();
            this.txtNewComment = new System.Windows.Forms.TextBox();
            this.flowComments = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.btnClearComment = new System.Windows.Forms.Button();
            this.splitCommentContainer.Panel1.SuspendLayout();
            this.splitCommentContainer.Panel2.SuspendLayout();
            this.splitCommentContainer.SuspendLayout();
            this.tableAddComment.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitCommentContainer
            // 
            this.splitCommentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitCommentContainer.Location = new System.Drawing.Point(0, 0);
            this.splitCommentContainer.Name = "splitCommentContainer";
            this.splitCommentContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitCommentContainer.Panel1
            // 
            this.splitCommentContainer.Panel1.Controls.Add(this.flowComments);
            // 
            // splitCommentContainer.Panel2
            // 
            this.splitCommentContainer.Panel2.Controls.Add(this.tableAddComment);
            this.splitCommentContainer.Size = new System.Drawing.Size(344, 470);
            this.splitCommentContainer.SplitterDistance = 306;
            this.splitCommentContainer.TabIndex = 0;
            // 
            // tableAddComment
            // 
            this.tableAddComment.ColumnCount = 1;
            this.tableAddComment.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableAddComment.Controls.Add(this.lblAddComment, 0, 0);
            this.tableAddComment.Controls.Add(this.txtNewComment, 0, 1);
            this.tableAddComment.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableAddComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableAddComment.Location = new System.Drawing.Point(0, 0);
            this.tableAddComment.Name = "tableAddComment";
            this.tableAddComment.RowCount = 3;
            this.tableAddComment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableAddComment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableAddComment.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableAddComment.Size = new System.Drawing.Size(344, 160);
            this.tableAddComment.TabIndex = 0;
            // 
            // lblAddComment
            // 
            this.lblAddComment.AutoSize = true;
            this.lblAddComment.Location = new System.Drawing.Point(3, 0);
            this.lblAddComment.Name = "lblAddComment";
            this.lblAddComment.Size = new System.Drawing.Size(73, 13);
            this.lblAddComment.TabIndex = 0;
            this.lblAddComment.Text = "Add Comment";
            // 
            // txtNewComment
            // 
            this.txtNewComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNewComment.Location = new System.Drawing.Point(3, 23);
            this.txtNewComment.Multiline = true;
            this.txtNewComment.Name = "txtNewComment";
            this.txtNewComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNewComment.Size = new System.Drawing.Size(338, 104);
            this.txtNewComment.TabIndex = 1;
            // 
            // flowComments
            // 
            this.flowComments.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowComments.Location = new System.Drawing.Point(0, 0);
            this.flowComments.Name = "flowComments";
            this.flowComments.Size = new System.Drawing.Size(344, 306);
            this.flowComments.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnAddComment);
            this.flowLayoutPanel1.Controls.Add(this.btnClearComment);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 133);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(338, 24);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnAddComment
            // 
            this.btnAddComment.Location = new System.Drawing.Point(3, 3);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(75, 23);
            this.btnAddComment.TabIndex = 0;
            this.btnAddComment.Text = "Add";
            this.btnAddComment.UseVisualStyleBackColor = true;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // btnClearComment
            // 
            this.btnClearComment.Location = new System.Drawing.Point(84, 3);
            this.btnClearComment.Name = "btnClearComment";
            this.btnClearComment.Size = new System.Drawing.Size(75, 23);
            this.btnClearComment.TabIndex = 1;
            this.btnClearComment.Text = "Clear";
            this.btnClearComment.UseVisualStyleBackColor = true;
            this.btnClearComment.Click += new System.EventHandler(this.btnClearComment_Click);
            // 
            // CommentListingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitCommentContainer);
            this.Name = "CommentListingControl";
            this.Size = new System.Drawing.Size(344, 470);
            this.splitCommentContainer.Panel1.ResumeLayout(false);
            this.splitCommentContainer.Panel2.ResumeLayout(false);
            this.splitCommentContainer.ResumeLayout(false);
            this.tableAddComment.ResumeLayout(false);
            this.tableAddComment.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitCommentContainer;
        private System.Windows.Forms.TableLayoutPanel tableAddComment;
        private System.Windows.Forms.Label lblAddComment;
        private System.Windows.Forms.TextBox txtNewComment;
        private System.Windows.Forms.FlowLayoutPanel flowComments;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.Button btnClearComment;
    }
}
