using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TaskManager.UI
{
    public partial class OptionsDialog : Form
    {
        bool saveName, savePass, autoLogin, useRemote;
        string connectionString;
        public OptionsDialog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveUserName = this.chkSaveName.Checked;
            Properties.Settings.Default.SavePassword = this.chkSavePassword.Checked;
            Properties.Settings.Default.AutoLogin = this.chkAutoLogin.Checked;
            Properties.Settings.Default.DBConnectionString = this.txtConnectionString.Text;
            Properties.Settings.Default.UseRemoteConnection = this.chkUseRemote.Checked;
            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SaveUserName = saveName;
            Properties.Settings.Default.SavePassword = savePass;
            Properties.Settings.Default.AutoLogin = autoLogin;
            Properties.Settings.Default.DBConnectionString = connectionString;
            Properties.Settings.Default.UseRemoteConnection = useRemote;
            Properties.Settings.Default.Save();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Options_Shown(object sender, EventArgs e)
        {
            saveName = this.chkSaveName.Checked = Properties.Settings.Default.SaveUserName;
            savePass = this.chkSavePassword.Checked = Properties.Settings.Default.SavePassword;
            autoLogin = this.chkAutoLogin.Checked = Properties.Settings.Default.AutoLogin;
            connectionString = this.txtConnectionString.Text = Properties.Settings.Default.DBConnectionString;
            useRemote = this.chkUseRemote.Checked = Properties.Settings.Default.UseRemoteConnection;
        }

        private void chkSaveName_CheckedChanged(object sender, EventArgs e)
        {
            this.chkSavePassword.Enabled = this.chkSaveName.Checked;
            this.chkAutoLogin.Enabled = this.chkSaveName.Checked && this.chkSavePassword.Checked;
            if (!this.chkSaveName.Checked)
            {
                this.chkSavePassword.Checked = false;
                this.chkAutoLogin.Checked = false;
            }
        }

        private void chkSavePassword_CheckedChanged(object sender, EventArgs e)
        {
            this.chkAutoLogin.Enabled = this.chkSavePassword.Checked;
            if (!this.chkSavePassword.Checked)
                this.chkAutoLogin.Checked = false;
        }

        private void chkUseRemote_CheckedChanged(object sender, EventArgs e)
        {
            this.label1.Enabled = this.chkUseRemote.Checked;
            this.txtConnectionString.Enabled = this.chkUseRemote.Checked;
        }
    }
}