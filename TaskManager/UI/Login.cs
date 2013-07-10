using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

using TaskManager.DataAccess;
using TaskManager.DataAccess.SqlServer;
using TaskManager.Localization;
using TaskManager.Properties;

namespace TaskManager.UI
{
    public partial class LoginDialog : Form
    {
        InfoAdapter data;
        int userID;
        public InfoAdapter DataConnection
        {
            get
            {
                return data;
            }
        }

        public LoginDialog()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ILanguage lang = Information.Languages[Settings.Default.CurrentLanguage];
            this.btnOK.Text = lang.OK;
            this.btnCancel.Text = lang.Cancel;
            this.lblUserName.Text = lang.Login_UserNameLabel;
            this.lblPassword.Text = lang.Login_PasswordLabel;
            this.Text = lang.Login_Title;
            this.checkSaveUserName.Text = lang.Login_SaveUserLabel;
            this.grpDataSource.Text = lang.Login_DataSource;
            this.rbLocal.Text = lang.Login_Local;
            this.rbServer.Text = lang.Login_Server;

            this.checkSaveUserName.Checked = Settings.Default.SaveUserName;
            if (this.checkSaveUserName.Checked)
                this.txtUserName.Text = Settings.Default.UserName;
        }

        public int UserID { get { return this.userID; } }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Settings.Default.SaveUserName = this.checkSaveUserName.Checked;
            if (this.checkSaveUserName.Checked)
                Settings.Default.UserName = this.txtUserName.Text;
            Settings.Default.Save();
            
            if (rbLocal.Checked)
                this.data = new SqlServerAdapter(Settings.Default.DatabaseLocalConnectionString);
            else if (rbServer.Checked)
                this.data = new SqlServerAdapter(Settings.Default.DBConnectionString);

            this.userID = data.User.Check(txtUserName.Text, txtPassword.Text);
            if (userID > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                ILanguage lang = Information.Languages[Settings.Default.CurrentLanguage];
                MessageBox.Show(
                    lang.Login_Failed,
                    lang.Login_FailedTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}