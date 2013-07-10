using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

using TaskManager.DataAccess;
//using TaskManager.DataAccess.MSSQL.SqlServer;
using TaskManager.Properties;

namespace TaskManager.UI
{
    public partial class LoginDialog : Form
    {
        IDataAccess data;
        int userID;
        public IDataAccess DataConnection
        {
            get { return data; }
            set { this.data = value; }
        }

        public LoginDialog()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.checkSaveUserName.Checked = Settings.Default.SaveUserName;
            if (this.checkSaveUserName.Checked)
                this.txtUserName.Text = Settings.Default.UserName;
            if (Settings.Default.SavePassword)
                this.txtPassword.Text = Settings.Default.Password;
        }

        public int UserID { get { return this.userID; } }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            Settings.Default.SaveUserName = this.checkSaveUserName.Checked;
            Settings.Default.Save();
            if (Settings.Default.UseRemoteConnection)
                this.data = new TaskManager.DataAccess.MSSQL.SqlServerAccess(Settings.Default.DBConnectionString);
            else
                this.data = new TaskManager.DataAccess.MSSQL.SqlServerCeAccess("tasks.sdf");

            this.userID = data.CheckUser(txtUserName.Text, txtPassword.Text);
            this.Cursor = Cursors.Default;
            Application.DoEvents();
            if (userID > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Login Failed: unrecognized username or password.",
                    "Access Denied",
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