using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using TaskManager.DataAccess;
using TaskManager.Localization;
using TaskManager.Properties;

namespace TaskManager.UI
{
    public partial class CommentControl : UserControl
    {
        public CommentControl()
        {
            InitializeComponent();
            ILanguage lang = Information.Languages[Settings.Default.CurrentLanguage];
            this.lblUserNameLbl.Text = lang.CommentControl_UserNameLabel;
            this.lblDateLbl.Text = lang.CommentControl_DateLabel;
        }

        public override string Text
        {
            get
            {
                return this.txtComment.Text;
            }
            set
            {
                this.txtComment.Text = value;
                int lineHeight = Math.Min(10, this.txtComment.Lines.Length);
                int delta = this.Height - this.txtComment.Height;
                this.Height = (int)Math.Round((lineHeight + 1) * this.txtComment.Font.GetHeight()) + delta;
            }
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
            get
            {
                return this.lblUserName.Text;
            }
            set
            {
                lblUserName.Text = value;
            }
        }
    }
}
