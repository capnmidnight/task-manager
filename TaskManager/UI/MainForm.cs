using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using TaskManager.BusinessLogic;
using TaskManager.DataAccess;
using TaskManager.Properties;

namespace TaskManager.UI
{
    public partial class MainForm : Form
    {
        private static Color COLOR_LATE, COLOR_DUE, COLOR_DEFAULT;
        static MainForm()
        {
            COLOR_DEFAULT = Color.White;
            COLOR_DUE = Color.SpringGreen;
            COLOR_LATE = Color.Salmon;
        }
        private IDataAccess data;
        private TagManagerDialog tagManager;
        private CreateTaskDialog createTask;
        private UpdateUserDialog updateUser;
        private OptionsDialog options;
        private LoginDialog login;

        private bool saveSemaphor;
        private Task currentTask;
        private User currentUser;
        private EventHandler deleteComment;
        public MainForm()
        {
            this.InitializeComponent();
            this.login = new LoginDialog();
            this.tagManager = new TagManagerDialog();
            this.createTask = new CreateTaskDialog();
            this.updateUser = new UpdateUserDialog();
            this.options = new OptionsDialog();
            this.currentTask = null;
            this.saveSemaphor = false;
            this.SetIsLoggedIn(false);
            this.deleteComment = new EventHandler(cc_Delete);
            BuildTaskTrayMenu();
        }
        private void BuildTaskTrayMenu()
        {
            notifyIcon1.ContextMenu = new ContextMenu();
            MenuItem min = new MenuItem("Minize to Task Tray", new EventHandler(minimizeToTaskTrayToolStripMenuItem_Click));
            minimizeToTaskTrayToolStripMenuItem.Checked = min.Checked = Settings.Default.MinimizeToTray;
            notifyIcon1.ContextMenu.MenuItems.Add(min);
            notifyIcon1.ContextMenu.MenuItems.Add(new MenuItem("Restore", new EventHandler(notifyIcon1_Click)));
        }
        private void LoadUsers()
        {
            this.LoadUsers(comboUserAssigned);
            this.LoadUsers(comboFilterAssignUser);
        }

        private void LoadUsers(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            List<User> users = this.data.GetAllUsers();
            comboBox.Items.AddRange(users.ToArray());
        }

        private void LoadTags(bool checkDefaults)
        {
            this.LoadTags(lstTags, checkDefaults);
            this.LoadTags(lstTagsOnTask, false);
        }

        private void LoadTags(CheckedListBox listBox, bool checkDefaults)
        {
            listBox.Items.Clear();
            List<Tag> tags = this.data.GetAllTags();
            if (tags != null)
                listBox.Items.AddRange(tags.ToArray());
            if (checkDefaults)
                for (int i = 0; i < listBox.Items.Count; ++i)
                    listBox.SetItemChecked(i, ((Tag)listBox.Items[i]).isDefault);
        }

        private void LoadTasks()
        {
            if (!saveSemaphor)
            {
                //Get the current task search expression
                List<int> tagIDs = new List<int>();
                foreach (Tag tag in this.lstTags.CheckedItems)
                    tagIDs.Add(tag.tagID);

                //find out if a assigned user was selected for a search parameter
                int userID = 0;
                if (this.comboFilterAssignUser.SelectedIndex > -1)
                    userID = ((User)this.comboFilterAssignUser.SelectedItem).userID;

                //perform the search
                List<Task> tasks = this.data.FindTasks(tagIDs, userID, DateTimePicker.MaximumDateTime);
                lblSearchCount.Text = string.Format("{0} Task{1} found", tasks.Count, tasks.Count == 1 ? "s" : "");
                int index = -1; //will hold the row number of the currently selected task
                DateTime today = DateTime.Now;

                this.gvTasks.SuspendLayout();
                int scroll = this.gvTasks.VerticalScrollingOffset;
                this.gvTasks.Rows.Clear();
                foreach (Task task in tasks)
                {
                    int insertedIndex = this.gvTasks.Rows.Add(task.taskID, task.priority, task.progress, task.title, task.dateCreated, task.dueDate);

                    //determine the due date coloring
                    foreach (DataGridViewCell cell in this.gvTasks.Rows[insertedIndex].Cells)
                        if (task.dueDate.Year == today.Year && task.dueDate.Month == today.Month && task.dueDate.Day == today.Day)
                            cell.Style.BackColor = COLOR_DUE;
                        else if (task.dueDate < today)
                            cell.Style.BackColor = COLOR_LATE;
                        else
                            cell.Style.BackColor = COLOR_DEFAULT;

                    //record the currently selected task
                    if (currentTask != null && task.taskID == currentTask.TaskID)
                        index = insertedIndex;
                }

                //unselect any selected rows
                foreach (DataGridViewRow row in this.gvTasks.Rows)
                    foreach (DataGridViewCell cell in row.Cells)
                        cell.Selected = false;

                //reselect the previously selected task, or wipe out the task display if there is none
                if (index == -1)
                    this.ClearTask();
                else
                {
                    this.gvTasks.Rows[index].Selected = true;
                    this.gvTasks.FirstDisplayedScrollingRowIndex = index;
                }
                this.gvTasks.ResumeLayout();
            }
        }

        private void ClearTask()
        {
            this.currentTask = null;
            this.txtDescription.Text = "";
            for (int index = 0; index < this.lstTagsOnTask.Items.Count; ++index)
                this.lstTagsOnTask.SetItemChecked(index, false);
            this.comboUserAssigned.SelectedIndex = -1;
            this.flowComments.Controls.Clear();
            this.listFileAttachments.Items.Clear();
        }

        private void ShowTask(int taskID)
        {
            if (this.data != null)
            {
                this.saveSemaphor = true;
                if (taskID > 0)
                {
                    this.currentTask = this.data.GetTask(taskID);
                    this.txtDescription.Text = this.currentTask.Description;
                    this.lblCreator.Text = this.data.GetUser(this.currentTask.UserCreator).UserName;
                    this.numPriority.Value = this.currentTask.Priority;
                    this.trackProgress.Value = this.currentTask.Progress;
                    if (this.currentTask.DueDate >= DateTimePicker.MinimumDateTime && this.currentTask.DueDate <= DateTimePicker.MaximumDateTime)
                        this.datePickDueDate.Value = this.currentTask.DueDate;
                    this.ShowTagsForTask();
                    this.SelectAssignedUser();
                    this.ShowComments();
                    this.ShowAttachments();
                }
                else
                {
                    this.txtDescription.Text = "";
                    for (int index = 0; index < this.lstTagsOnTask.Items.Count; ++index)
                        this.lstTagsOnTask.SetItemChecked(index, false);
                    this.comboUserAssigned.SelectedIndex = 0;
                    this.lblCreator.Text = "";
                    this.flowComments.Controls.Clear();
                }
                this.saveSemaphor = false;
            }
        }

        private void ShowAttachments()
        {
            List<AttachmentReference> attachments = this.data.GetAttachmentsOnTask(this.currentTask.TaskID);
            listFileAttachments.SuspendLayout();
            listFileAttachments.Items.Clear();
            listFileAttachments.Items.AddRange(attachments.ToArray());
            listFileAttachments.ResumeLayout();
        }

        private void SelectAssignedUser()
        {
            for (int index = 0; index < this.comboUserAssigned.Items.Count; ++index)
                if (this.currentTask.UserAssigned == ((User)this.comboUserAssigned.Items[index]).userID)
                    this.comboUserAssigned.SelectedIndex = index;
        }

        private void ShowTagsForTask()
        {
            List<Tag> tagsOnTask = this.data.GetTagsOnTask(currentTask.TaskID);
            for (int index = 0; index < this.lstTagsOnTask.Items.Count; ++index)
            {
                this.lstTagsOnTask.SetItemChecked(index, false);
                foreach (Tag tag in tagsOnTask)
                    if (tag.tagID == ((Tag)lstTagsOnTask.Items[index]).tagID)
                        this.lstTagsOnTask.SetItemChecked(index, true);
            }
        }

        private void ShowComments()
        {
            this.flowComments.Controls.Clear();
            if (this.data != null)
            {
                List<Comment> comments = this.data.GetCommentsOnTask(currentTask.TaskID);
                foreach (Comment comment in comments)
                {
                    CommentControl cc = new CommentControl();
                    cc.Text = comment.Text;
                    cc.UserName = data.GetUser(comment.UserID).UserName;
                    cc.CommentDate = comment.DateCreated;
                    cc.CommentID = comment.CommentID;
                    cc.Width = flowComments.Width - 25;
                    cc.Delete += deleteComment;
                    this.flowComments.Controls.Add(cc);
                }
            }
        }

        void cc_Delete(object sender, EventArgs e)
        {
            if (sender is CommentControl)
            {
                CommentControl cc = sender as CommentControl;
                this.data.DeleteComment(cc.CommentID);
                this.ShowComments();
            }
        }

        private void SaveCurrentTask()
        {
            if (!this.saveSemaphor && this.currentTask != null)
            {
                int userAssigned = 0, priority, progress;
                string title = "", description;
                DateTime dueDate;
                if (this.comboUserAssigned.SelectedItem != null)
                    userAssigned = ((User)this.comboUserAssigned.SelectedItem).userID;
                priority = (int)numPriority.Value;
                progress = trackProgress.Value;
                foreach (DataGridViewRow row in this.gvTasks.Rows)
                {
                    if ((int)row.Cells["TaskID"].Value == this.currentTask.TaskID)
                    {
                        title = (string)row.Cells["Title"].Value;
                        break;
                    }
                }
                description = this.txtDescription.Text;
                DateTime temp = this.datePickDueDate.Value;
                dueDate = new DateTime(temp.Year, temp.Month, temp.Day, 23, 59, 59);
                if (this.data != null)
                {
                    this.data.EditTask(
                        this.currentTask.TaskID,
                        title,
                        description,
                        userAssigned,
                        priority,
                        progress,
                        dueDate);

                    this.currentTask = this.data.GetTask(this.currentTask.TaskID);

                    List<Tag> tags = this.data.GetTagsOnTask(this.currentTask.TaskID);
                    List<int> tagIDs = new List<int>();
                    foreach (Tag tag in tags) tagIDs.Add(tag.TagID);
                    for (int index = 0; index < this.lstTagsOnTask.Items.Count; ++index)
                    {
                        int tagID = ((Tag)this.lstTagsOnTask.Items[index]).tagID;
                        if (this.lstTagsOnTask.GetItemChecked(index))
                        {
                            if (!tagIDs.Contains(tagID))
                                this.data.AddTagToTask(tagID, this.currentTask.TaskID);
                        }
                        else
                            if (tagIDs.Contains(tagID))
                                this.data.RemoveTagFromTask(((Tag)this.lstTagsOnTask.Items[index]).tagID, this.currentTask.TaskID);
                    }
                }
            }
        }

        private void lstTags_SelectedIndexChanged(object sender, EventArgs eventArguments)
        {
            this.LoadTasks();
        }

        private void gvTasks_CellClick(object sender, DataGridViewCellEventArgs eventArguments)
        {
            if (eventArguments.RowIndex > -1)
                this.ShowTask((int)this.gvTasks.Rows[eventArguments.RowIndex].Cells["TaskID"].Value);
        }

        private void gvTasks_SelectionChanged(object sender, EventArgs eventArguments)
        {
            if (this.gvTasks.SelectedRows.Count > 0 && this.gvTasks.SelectedRows[0].Index > -1)
                this.ShowTask((int)this.gvTasks.Rows[this.gvTasks.SelectedRows[0].Index].Cells["TaskID"].Value);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            if (this.data != null)
                this.SetIsLoggedIn(false);
            Application.Exit();
        }

        private void manageTagsToolStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            this.tagManager.ShowDialog();
            this.LoadTags(true);
        }

        private void splitBottomLeftRight_SplitterMoved(object sender, SplitterEventArgs eventArguments)
        {
            this.splitTopLeftRight.SplitterDistance = this.splitBottomLeftRight.SplitterDistance;
        }

        private void splitTopLeftRight_SplitterMoved(object sender, SplitterEventArgs eventArguments)
        {
            this.splitBottomLeftRight.SplitterDistance = this.splitTopLeftRight.SplitterDistance;
        }

        private void addTaskToolStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            this.createTask.ShowDialog();
            this.LoadTasks();
        }

        private void lstTagsOnTask_SelectedIndexChanged(object sender, EventArgs eventArguments)
        {
            this.SaveCurrentTask();
            this.LoadTasks();
        }

        private void comboUserAssigned_SelectedIndexChanged(object sender, EventArgs eventArguments)
        {
            this.SaveCurrentTask();
        }

        private void txtDescription_TextChanged(object sender, EventArgs eventArguments)
        {
            this.SaveCurrentTask();
        }

        private void gvTasks_CellValueChanged(object sender, DataGridViewCellEventArgs eventArguments)
        {
            this.SaveCurrentTask();
        }

        private void datePickDueDate_ValueChanged(object sender, EventArgs e)
        {
            this.SaveCurrentTask();
            this.LoadTasks();
        }

        private void btnClearComment_Click(object sender, EventArgs eventArguments)
        {
            this.txtComment.Text = "";
        }

        private void btnAddComment_Click(object sender, EventArgs eventArguments)
        {
            if (this.data != null)
            {
                string commentText = this.txtComment.Text.Trim();
                if (this.currentTask != null && commentText.Length > 0)
                {
                    this.data.AddComment(this.currentUser.UserID, this.currentTask.TaskID, commentText);
                    this.txtComment.Text = "";
                    this.ShowComments();
                }
            }
        }

        private void gvTasks_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs eventArguments)
        {
            if (this.data != null && eventArguments.Row.Cells["TaskID"].Value != null)
            {
                this.data.DeleteTask((int)eventArguments.Row.Cells["TaskID"].Value);
                this.currentTask = null;
                this.LoadTasks();
                this.ShowTask(0);
                eventArguments.Cancel = true;
            }
        }

        private void editUserDetailsToolStripMenuItem_Click(object sender, EventArgs eventArguments)
        {
            this.updateUser.ShowDialog();
        }

        private void comboFilterAssignUser_SelectedIndexChanged(object sender, EventArgs eventArguments)
        {
            this.LoadTasks();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.data == null)
            {
                try
                {
                    if (this.login.ShowDialog() == DialogResult.OK)
                    {
                        this.data = this.login.DataConnection;
                        this.FirstSetup(login.UserID);
                        this.SaveUserCredentials();
                    }
                    else
                    {
                        this.SetIsLoggedIn(false);
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(
                        Utility.PrepareErrorMessage(exp),
                        "FATAL ERROR!",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void FirstSetup(int userID)
        {
            this.currentUser = data.GetUser(userID);
            this.createTask.CurrentUser = currentUser;
            this.updateUser.User = currentUser;
            this.LoadTags(true);
            this.LoadTasks();
            this.LoadUsers();
            this.SetIsLoggedIn(true);
        }

        private void SetIsLoggedIn(bool value)
        {
            if (!value)
            {
                this.comboFilterAssignUser.Items.Clear();
                this.comboUserAssigned.Items.Clear();
                this.currentTask = null;
                this.currentUser = null;
                this.flowComments.Controls.Clear();
                this.gvTasks.Rows.Clear();
                this.lblCreator.Text = "";
                this.lstTags.Items.Clear();
                this.lstTagsOnTask.Items.Clear();
                this.txtComment.Text = "";
                this.txtDescription.Text = "";
                if (this.data != null)
                {
                    try
                    {
                        this.data.Dispose();
                    }
                    finally
                    {
                        this.data = null;
                    }
                }
            }
            this.tagManager.DataConnection = this.data;
            this.createTask.DataConnection = this.data;
            this.updateUser.DataConnection = this.data;
            this.loginToolStripMenuItem.Enabled = !value;
            this.logoutToolStripMenuItem.Enabled = value;
            this.addTaskToolStripMenuItem.Enabled = value;
            this.manageTagsToolStripMenuItem.Enabled = value;
            this.importToolStripMenuItem.Enabled = value;
            this.exportToolStripMenuItem.Enabled = value;
            this.editUserDetailsToolStripMenuItem.Enabled = value;
            this.panTop.Enabled = value;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SetIsLoggedIn(false);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("unimplemented");
        }

        private void numPriority_ValueChanged(object sender, EventArgs e)
        {
            this.SaveCurrentTask();
            this.LoadTasks();
        }

        private void trackProgress_ValueChanged(object sender, EventArgs e)
        {
            this.SaveCurrentTask();
            this.LoadTasks();
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            if (this.currentTask != null
                && this.openFileDialog1.ShowDialog() == DialogResult.OK
                && File.Exists(this.openFileDialog1.FileName))
            {
                byte[] buffer = File.ReadAllBytes(this.openFileDialog1.FileName);
                data.CreateAttachment(currentTask.TaskID, Path.GetFileName(this.openFileDialog1.FileName), buffer);
                this.ShowAttachments();
            }
        }

        private void btnSaveAttachment_Click(object sender, EventArgs e)
        {
            if (this.listFileAttachments.SelectedItem != null
                && this.data != null)
            {
                AttachmentReference refAttach = this.listFileAttachments.SelectedItem as AttachmentReference;
                this.saveFileDialog1.FileName = refAttach.FileName;
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Attachment attach = this.data.GetAttachment(refAttach.AttachmentID);
                    File.WriteAllBytes(this.saveFileDialog1.FileName, attach.FileData);
                }
            }
        }

        private void btnDeleteAttachment_Click(object sender, EventArgs e)
        {
            if (this.listFileAttachments.SelectedItem != null
                && this.data != null
                && MessageBox.Show("Are you sure you want to delete the file?",
                    "File delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                AttachmentReference refAttach = this.listFileAttachments.SelectedItem as AttachmentReference;
                this.data.DeleteAttachment(refAttach.AttachmentID);
                this.ShowAttachments();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }

        private void minimizeToTaskTrayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            minimizeToTaskTrayToolStripMenuItem.Checked = !minimizeToTaskTrayToolStripMenuItem.Checked;
            notifyIcon1.ContextMenu.MenuItems[0].Checked = minimizeToTaskTrayToolStripMenuItem.Checked;
            Settings.Default.MinimizeToTray = minimizeToTaskTrayToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && this.minimizeToTaskTrayToolStripMenuItem.Checked)
                this.Hide();
            else
                this.Show();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Focus();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.options.ShowDialog() == DialogResult.OK)
                if (this.currentUser != null)
                    this.SaveUserCredentials();
        }

        private void SaveUserCredentials()
        {
            if (Settings.Default.SaveUserName)
                Settings.Default.UserName = currentUser.UserName;
            if (Settings.Default.SavePassword)
                Settings.Default.Password = currentUser.Password;
            Settings.Default.Save();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (Settings.Default.AutoLogin && Settings.Default.SaveUserName && Settings.Default.SavePassword)
            {
                this.Cursor = Cursors.WaitCursor;
                if (Settings.Default.UseRemoteConnection)
                    this.data = new TaskManager.DataAccess.MSSQL.SqlServerAccess(Settings.Default.DBConnectionString);
                else
                    this.data = new TaskManager.DataAccess.MSSQL.SqlServerCeAccess("tasks.sdf");
                this.login.DataConnection = this.data;
                int userID = data.CheckUser(Settings.Default.UserName, Settings.Default.Password);
                if (userID > 0)
                    this.FirstSetup(userID);
                else
                    this.SetIsLoggedIn(false);
                this.Cursor = Cursors.Default;
            }
        }
    }
}