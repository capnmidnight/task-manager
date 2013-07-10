using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using TaskManager.DataAccess;
using TaskManager.Properties;

namespace TaskManager.UI
{
    public partial class UpdateUserDialog : Form
    {
        IDataAccess data;
        User currentUser;
        public IDataAccess DataConnection
        {
            set
            {
                data = value;
            }
        }
        public User User
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
                    data.EditUser(currentUser.UserID, password, email);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Passwords do not match",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Hand);
                }
            }
        }
    }
}