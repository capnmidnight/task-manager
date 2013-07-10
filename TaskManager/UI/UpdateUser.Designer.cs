namespace TaskManager.UI
{
    partial class UpdateUserDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInstructions = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblUserName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblEmailLbl = new System.Windows.Forms.Label();
            this.lblPasswordLbl = new System.Windows.Forms.Label();
            this.lblPasswordConfirmLbl = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPass = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(1, 9);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(148, 13);
            this.lblInstructions.TabIndex = 0;
            this.lblInstructions.Text = "Update User Settings for User";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(116, 124);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(197, 124);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(12, 27);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(90, 20);
            this.lblUserName.TabIndex = 6;
            this.lblUserName.Text = "(username)";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 98F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.Controls.Add(this.lblEmailLbl, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPasswordLbl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPasswordConfirmLbl, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPassword, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtConfirmPass, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(268, 68);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // lblEmailLbl
            // 
            this.lblEmailLbl.AutoSize = true;
            this.lblEmailLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblEmailLbl.Location = new System.Drawing.Point(63, 0);
            this.lblEmailLbl.Name = "lblEmailLbl";
            this.lblEmailLbl.Size = new System.Drawing.Size(32, 20);
            this.lblEmailLbl.TabIndex = 0;
            this.lblEmailLbl.Text = "Email";
            // 
            // lblPasswordLbl
            // 
            this.lblPasswordLbl.AutoSize = true;
            this.lblPasswordLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPasswordLbl.Location = new System.Drawing.Point(17, 20);
            this.lblPasswordLbl.Name = "lblPasswordLbl";
            this.lblPasswordLbl.Size = new System.Drawing.Size(78, 20);
            this.lblPasswordLbl.TabIndex = 1;
            this.lblPasswordLbl.Text = "New Password";
            // 
            // lblPasswordConfirmLbl
            // 
            this.lblPasswordConfirmLbl.AutoSize = true;
            this.lblPasswordConfirmLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPasswordConfirmLbl.Location = new System.Drawing.Point(4, 40);
            this.lblPasswordConfirmLbl.Name = "lblPasswordConfirmLbl";
            this.lblPasswordConfirmLbl.Size = new System.Drawing.Size(91, 30);
            this.lblPasswordConfirmLbl.TabIndex = 2;
            this.lblPasswordConfirmLbl.Text = "Confirm Password";
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Location = new System.Drawing.Point(101, 3);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(164, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Location = new System.Drawing.Point(101, 23);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(164, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPass
            // 
            this.txtConfirmPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConfirmPass.Location = new System.Drawing.Point(101, 43);
            this.txtConfirmPass.Name = "txtConfirmPass";
            this.txtConfirmPass.Size = new System.Drawing.Size(164, 20);
            this.txtConfirmPass.TabIndex = 5;
            this.txtConfirmPass.UseSystemPasswordChar = true;
            // 
            // UpdateUserDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(274, 149);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblInstructions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateUserDialog";
            this.ShowInTaskbar = false;
            this.Text = "Update User";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblEmailLbl;
        private System.Windows.Forms.Label lblPasswordLbl;
        private System.Windows.Forms.Label lblPasswordConfirmLbl;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtConfirmPass;

    }
}