using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TaskManager.DataAccess;
using TaskManager.Localization;
using TaskManager.Properties;

namespace TaskManager.UI
{
    public partial class UpdateUserDialog : Form
    {
        InfoAdapter data;
        IUser currentUser;
        public InfoAdapter DataConnection
        {
            set
            {
                data = value;
            }
        }
        public IUser User
        {
            set
            {
                this.currentUser = value;
                this.lblUserName.Text = currentUser.UserName;
                this.txtEmail.Text = currentUser.Email;
            }
        }
        public UpdateUserDialog()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            ILanguage lang = Information.Languages[Settings.Default.CurrentLanguage];
            this.btnOK.Text = lang.OK;
            this.btnCancel.Text = lang.Cancel;
            this.lblInstructions.Text = lang.UpdateUser_Instructions;
            this.lblEmailLbl.Text = lang.UpdateUser_EmailLabel;
            this.lblPasswordLbl.Text = lang.UpdateUser_PasswordLabel;
            this.lblPasswordConfirmLbl.Text = lang.UpdateUser_PasswordConfirmLabel;
            this.Text = lang.UpdateUser_Title;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (data != null)
            {
                if (txtPassword.Text == txtConfirmPass.Text)
                {
                    string password = txtPassword.Text;
                    string email = txtEmail.Text;
                    data.User.Edit(currentUser.UserID, password, email);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ILanguage lang = Information.Languages[Settings.Default.CurrentLanguage];
                    MessageBox.Show(
                        lang.UpdateUser_ErrorPassword,
                        lang.Warning,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}