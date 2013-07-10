namespace TaskManager.UI
{
    partial class OptionsDialog
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
            this.chkSaveName = new System.Windows.Forms.CheckBox();
            this.chkAutoLogin = new System.Windows.Forms.CheckBox();
            this.chkSavePassword = new System.Windows.Forms.CheckBox();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkUseRemote = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkSaveName
            // 
            this.chkSaveName.AutoSize = true;
            this.chkSaveName.Location = new System.Drawing.Point(6, 19);
            this.chkSaveName.Name = "chkSaveName";
            this.chkSaveName.Size = new System.Drawing.Size(107, 17);
            this.chkSaveName.TabIndex = 0;
            this.chkSaveName.Text = "Save User Name";
            this.chkSaveName.UseVisualStyleBackColor = true;
            this.chkSaveName.CheckedChanged += new System.EventHandler(this.chkSaveName_CheckedChanged);
            // 
            // chkAutoLogin
            // 
            this.chkAutoLogin.AutoSize = true;
            this.chkAutoLogin.Location = new System.Drawing.Point(6, 65);
            this.chkAutoLogin.Name = "chkAutoLogin";
            this.chkAutoLogin.Size = new System.Drawing.Size(171, 17);
            this.chkAutoLogin.TabIndex = 1;
            this.chkAutoLogin.Text = "Login Automatically On Startup";
            this.chkAutoLogin.UseVisualStyleBackColor = true;
            // 
            // chkSavePassword
            // 
            this.chkSavePassword.AutoSize = true;
            this.chkSavePassword.Location = new System.Drawing.Point(6, 42);
            this.chkSavePassword.Name = "chkSavePassword";
            this.chkSavePassword.Size = new System.Drawing.Size(100, 17);
            this.chkSavePassword.TabIndex = 2;
            this.chkSavePassword.Text = "Save Password";
            this.chkSavePassword.UseVisualStyleBackColor = true;
            this.chkSavePassword.CheckedChanged += new System.EventHandler(this.chkSavePassword_CheckedChanged);
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Enabled = false;
            this.txtConnectionString.Location = new System.Drawing.Point(6, 56);
            this.txtConnectionString.Multiline = true;
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(162, 77);
            this.txtConnectionString.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Remote Server Connection String";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(11, 246);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(99, 246);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSaveName);
            this.groupBox1.Controls.Add(this.chkSavePassword);
            this.groupBox1.Controls.Add(this.chkAutoLogin);
            this.groupBox1.Location = new System.Drawing.Point(0, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 90);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Options";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkUseRemote);
            this.groupBox2.Controls.Add(this.txtConnectionString);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 139);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Options";
            // 
            // chkUseRemote
            // 
            this.chkUseRemote.AutoSize = true;
            this.chkUseRemote.Location = new System.Drawing.Point(9, 20);
            this.chkUseRemote.Name = "chkUseRemote";
            this.chkUseRemote.Size = new System.Drawing.Size(142, 17);
            this.chkUseRemote.TabIndex = 5;
            this.chkUseRemote.Text = "Use Remote Connection";
            this.chkUseRemote.UseVisualStyleBackColor = true;
            this.chkUseRemote.CheckedChanged += new System.EventHandler(this.chkUseRemote_CheckedChanged);
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 273);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsDialog";
            this.Text = "Options";
            this.Shown += new System.EventHandler(this.Options_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkSaveName;
        private System.Windows.Forms.CheckBox chkAutoLogin;
        private System.Windows.Forms.CheckBox chkSavePassword;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkUseRemote;
    }
}