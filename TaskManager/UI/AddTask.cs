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
    /// <summary>
    /// A modal dialog box for creating a new task in the database.<br/>
    /// Before showing the dialog box, set the DataConnection and CurrentUser properties.
    /// </summary>
    public partial class CreateTaskDialog : Form
    {
        InfoAdapter data;
        IUser curUser;

        /// <summary>
        /// The data adapter to use for creating tasks. Data adapters can read and write data
        /// to any type of data source.
        /// </summary>
        public InfoAdapter DataConnection
        {
            set
            {
                this.data = value;
            }
        }

        public IUser CurrentUser
        {
            set
            {
                this.curUser = value;
            }
        }

        public CreateTaskDialog()
        {
            InitializeComponent();
        }

        private void txtTitle_Enter(object sender, EventArgs e)
        {
            if (txtTitle.Text == Information.Languages[Settings.Default.CurrentLanguage].AddTask_DefaultTitle)
                txtTitle.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboUserAssigned.SelectedItem == null)
            {
                MessageBox.Show(Information.Languages[Settings.Default.CurrentLanguage].AddTask_MissingUserValue, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (data != null)
                {

                    DateTime a = datePickDueDate.Value;
                    a = new DateTime(a.Year, a.Month, a.Day, 23, 59, 59);
                    int taskID = data.Task.Create(txtTitle.Text, txtDescription.Text, curUser.UserID, ((IUser)comboUserAssigned.SelectedItem).UserID, (int)numPriority.Value, 0, a);
                    foreach (ITag tag in lstTags.CheckedItems)
                        data.Task.AddTag(tag.TagID, taskID);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// closes the dialog box without creating a new task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CreateTaskDialog_Shown(object sender, EventArgs e)
        {
            ILanguage lang = Information.Languages[Settings.Default.CurrentLanguage];
            this.btnCancel.Text = lang.Cancel;
            this.btnOK.Text = lang.OK;
            this.lblUserAssignedLbl.Text = lang.AddTask_UserAssignedLabel;
            this.lblPriorityLbl.Text = lang.AddTask_PriorityLabel;
            this.lblDueDateLbl.Text = lang.AddTask_DueDateLabel;
            this.Text = lang.AddTask_Title;
            this.txtTitle.Text = lang.AddTask_DefaultTitle;
            this.txtDescription.Text = lang.AddTask_DefaultDescription;
            this.numPriority.Value = 1;
            this.datePickDueDate.Value = DateTime.Now.AddDays(14);
            if (this.data != null)
            {
                this.comboUserAssigned.Items.Clear();
                this.lstTags.Items.Clear();
                if (this.data != null)
                {
                    this.comboUserAssigned.Items.AddRange(this.data.User.GetAll().ToArray());
                    this.lstTags.Items.AddRange(this.data.Tag.GetAll().ToArray());
                }
            }
            this.comboUserAssigned.SelectedIndex = 0;
            for (int index = 0; index < this.lstTags.Items.Count; ++index)
                this.lstTags.SetItemChecked(index, ((ITag)this.lstTags.Items[index]).IsDefault);
        }
    }
}