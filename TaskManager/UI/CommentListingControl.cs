using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using TaskManager.DataAccess;

namespace TaskManager.UI
{
    public delegate void CommentCreatedEventHandler(CommentListingControl sender, string commentText);
    public delegate void CommentDeletedEventHandler(CommentListingControl sender, int commentID);
    public partial class CommentListingControl : UserControl
    {
        private List<Comment> comments;
        private EventHandler deleteComment;

        public CommentListingControl()
        {
            InitializeComponent();
            this.deleteComment = new EventHandler(this.DeleteComment);
        }

        public event CommentCreatedEventHandler CommentCreated;
        public event CommentDeletedEventHandler CommentDeleted;

        public virtual void OnCommentCreated(string commentText)
        {
            if (this.CommentCreated != null)
                this.CommentCreated(this, commentText);
        }

        public virtual void OnCommentDeleted(int commentID)
        {
            if (this.CommentDeleted != null)
                this.CommentDeleted(this, commentID);
        }

        public void SetComments(List<Comment> comments)
        {
            this.comments = comments;
            this.flowComments.Controls.Clear();
            if (this.comments != null)
            {
                foreach (Comment comment in this.comments)
                {
                    CommentControl cc = new CommentControl();
                    cc.Text = comment.Text;
                    cc.UserName = comment.UserName;
                    cc.CommentDate = comment.DateCreated;
                    cc.CommentID = comment.CommentID;
                    cc.Width = this.flowComments.Width - 25;
                    cc.Delete += this.deleteComment;
                    this.flowComments.Controls.Add(cc);
                }
            }
        }

        private void DeleteComment(object source, EventArgs args)
        {
            if (source is CommentControl)
                this.OnCommentDeleted((source as CommentControl).CommentID);
        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            this.OnCommentCreated(this.txtNewComment.Text.Trim());
        }

        private void btnClearComment_Click(object sender, EventArgs e)
        {
            this.txtNewComment.Text = "";
        }
    }
}
