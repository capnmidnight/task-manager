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
    /// <summary>
    /// A modal dialog box for creating a new task in the database.<br/>
    /// Before showing the dialog box, set the DataConnection and CurrentUser properties.
    /// </summary>
    public partial class CreateTaskDialog : Form
    {
        IDataAccess data;
        User curUser;

        /// <summary>
        /// The data adapter to use for creating tasks. Data adapters can read and write data
        /// to any type of data source.
        /// </summary>
        public IDataAccess DataConnection
        {
            set
            {
                this.data = value;
            }
        }

        public User CurrentUser
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
            if (txtTitle.Text == "(title)")
                txtTitle.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (comboUserAssigned.SelectedItem == null)
            {
                MessageBox.Show("An assigned user must be selected.", "Missing Value", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                if (data != null)
                {

                    DateTime a = datePickDueDate.Value;
                    a = new DateTime(a.Year, a.Month, a.Day, 23, 59, 59);
                    List<int> tagIDs = new List<int>();
                    foreach (Tag tag in lstTags.CheckedItems)
                        tagIDs.Add(tag.TagID);

                    data.CreateTask(txtTitle.Text, txtDescription.Text, curUser.UserID, ((User)comboUserAssigned.SelectedItem).UserID, (int)numPriority.Value, 0, a, tagIDs);
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
            this.numPriority.Value = 1;
            this.datePickDueDate.Value = DateTime.Now.AddDays(14);
            if (this.data != null)
            {
                this.comboUserAssigned.Items.Clear();
                this.lstTags.Items.Clear();
                if (this.data != null)
                {
                    this.comboUserAssigned.Items.AddRange(this.data.GetAllUsers().ToArray());
                    this.lstTags.Items.AddRange(this.data.GetAllTags().ToArray());
                }
            }
            this.comboUserAssigned.SelectedIndex = 0;
            for (int index = 0; index < this.lstTags.Items.Count; ++index)
                this.lstTags.SetItemChecked(index, ((Tag)this.lstTags.Items[index]).IsDefault);
        }
    }
}