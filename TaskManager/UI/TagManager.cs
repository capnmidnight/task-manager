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
    public partial class TagManagerDialog : Form
    {
        InfoAdapter data;
        List<ITag> tags;
        public InfoAdapter DataConnection
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
            ILanguage lang = Information.Languages[Settings.Default.CurrentLanguage];
            this.btnOK.Text = lang.OK;
            this.Text = lang.TagManager_Title;
            this.NameColumn.HeaderText = lang.TagManager_NameHeader;
            this.Description.HeaderText = lang.TagManager_DescriptionHeader;
            this.lblChkDefaultLabel.Text = lang.TagManager_ChkDefaultLabel;
            this.LoadTags();
        }

        private void LoadTags()
        {
            gvTags.Rows.Clear();
            if (data != null)
            {
                tags = data.Tag.GetAll();
                gvTags.SuspendLayout();
                if (tags != null)
                    foreach (ITag tag in tags)
                        gvTags.Rows.Add(tag.TagID, tag.IsDefault, tag.Name, tag.Description);
                gvTags.ResumeLayout();
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void gvTags_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs eventArguments)
        {
            if (data != null && eventArguments.Row.Cells["TagID"].Value != null)
                data.Tag.Delete((int)eventArguments.Row.Cells["TagID"].Value);
        }

        private void gvTags_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (data != null && e.RowIndex > 0)
            {
                string name = (string)gvTags["NameColumn", e.RowIndex].Value;
                string description = (string)gvTags["Description", e.RowIndex].Value;
                bool isDefault = (bool)gvTags["IsDefault", e.RowIndex].Value;
                if (description == null) description = "N/A";
                if (name == null) name = "";
                if (gvTags["TagID", e.RowIndex].Value != null)
                {
                    int tagID = (int)gvTags["TagID", e.RowIndex].Value;
                    data.Tag.Edit(tagID, name, description, isDefault);
                }
                else
                {
                    int tagID = data.Tag.Create(name, description, isDefault);
                    gvTags["TagID", e.RowIndex].Value = tagID;
                }
            }
        }
    }
}