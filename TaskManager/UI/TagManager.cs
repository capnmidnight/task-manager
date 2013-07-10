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
    public partial class TagManagerDialog : Form
    {
        IDataAccess data;
        List<Tag> tags;
        public IDataAccess DataConnection
        {
            set
            {
                data = value;
            }
        }

        public TagManagerDialog()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.LoadTags();
        }

        private void LoadTags()
        {
            gvTags.Rows.Clear();
            if (data != null)
            {
                tags = data.GetAllTags();
                gvTags.SuspendLayout();
                if (tags != null)
                    foreach (Tag tag in tags)
                        gvTags.Rows.Add(tag.TagID, tag.IsDefault, tag.Name, tag.Description);
                gvTags.ResumeLayout();
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvTags_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs eventArguments)
        {
            if (data != null && eventArguments.Row.Cells["TagID"].Value != null)
                data.DeleteTag((int)eventArguments.Row.Cells["TagID"].Value);
        }

        private void gvTags_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (data != null && e.RowIndex >= 0)
            {
                string name = (string)gvTags["NameColumn", e.RowIndex].Value;
                string description = (string)gvTags["Description", e.RowIndex].Value;
                bool isDefault = (gvTags["IsDefault", e.RowIndex].Value != null) ? (bool)gvTags["IsDefault", e.RowIndex].Value : false;
                if (description == null) description = "N/A";
                if (name == null) name = "";
                if (gvTags["TagID", e.RowIndex].Value != null)
                {
                    int tagID = (int)gvTags["TagID", e.RowIndex].Value;
                    data.EditTag(tagID, name, description, isDefault);
                }
                else
                {
                    data.CreateTag(name, description, isDefault);
                    this.LoadTags();
                }
            }
        }
    }
}