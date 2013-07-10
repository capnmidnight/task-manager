using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using TaskManager.DataAccess;
using TaskManager.Properties;

namespace TaskManager.UI
{
    public partial class CommentControl : UserControl
    {
        public event EventHandler Delete;
        private int commentID;
        private static int GUTTER = 40;
        public CommentControl()
        {
            InitializeComponent();
        }

        public override string Text
        {
            get { return this.txtComment.Text; }
            set
            {
                this.txtComment.Text = value;
                this.SetSize();
            }
        }
        private void SetSize()
        {
            Graphics g = this.CreateGraphics();
            float height = 0, fontHeight = this.txtComment.Font.GetHeight() * 1.6f;
            foreach (string line in this.txtComment.Lines)
            {
                float width = g.MeasureString(line, this.txtComment.Font).Width;
                int lines = (int)(Math.Ceiling(width / this.txtComment.Width));
                height += lines * fontHeight;
            }
            this.Height = (int)(Math.Ceiling(Math.Max(fontHeight * 2, Math.Min(fontHeight * 10, height)))) + GUTTER;
        }
        public int CommentID
        {
            get { return this.commentID; }
            set { this.commentID = value; }
        }

        public DateTime CommentDate
        {
            get
            {
                DateTime result = DateTime.Now;
                if (DateTime.TryParse(lblDate.Text, out result))
                    return result;
                return DateTime.Now;
            }
            set
            {
                lblDate.Text = value.ToString();
            }
        }

        public string UserName
        {
            get { return this.lblUserName.Text; }
            set { lblUserName.Text = value; }
        }

        private void linkToggleVisible_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtComment.Visible = !txtComment.Visible;
            linkToggleVisible.Text = txtComment.Visible ? "Hide" : "Show";
            if (txtComment.Visible)
                this.SetSize();
            else
                this.Height = GUTTER;
        }

        private void linkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this.Delete != null)
                this.Delete(this, null);
        }
    }
}
