namespace TaskManager.UI
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lstTags = new System.Windows.Forms.CheckedListBox();
            this.lstTagsOnTask = new System.Windows.Forms.CheckedListBox();
            this.gvTasks = new System.Windows.Forms.DataGridView();
            this.TaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Progress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panTop = new System.Windows.Forms.Panel();
            this.splitLeftRight = new System.Windows.Forms.SplitContainer();
            this.splitTopBottom = new System.Windows.Forms.SplitContainer();
            this.splitTopLeftRight = new System.Windows.Forms.SplitContainer();
            this.tableFilterControls = new System.Windows.Forms.TableLayoutPanel();
            this.lblSearchTagsLbl = new System.Windows.Forms.Label();
            this.lblFilterUserLbl = new System.Windows.Forms.Label();
            this.comboFilterAssignUser = new System.Windows.Forms.ComboBox();
            this.splitBottomLeftRight = new System.Windows.Forms.SplitContainer();
            this.tabTaskInfo = new System.Windows.Forms.TabControl();
            this.tabTaskDetails = new System.Windows.Forms.TabPage();
            this.tableTaskDetail = new System.Windows.Forms.TableLayoutPanel();
            this.datePickDueDate = new System.Windows.Forms.DateTimePicker();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblCreatorLbl = new System.Windows.Forms.Label();
            this.lblCreator = new System.Windows.Forms.Label();
            this.lblUserAssignedLbl = new System.Windows.Forms.Label();
            this.comboUserAssigned = new System.Windows.Forms.ComboBox();
            this.lblDueDateLbl = new System.Windows.Forms.Label();
            this.lblPriorityLabel = new System.Windows.Forms.Label();
            this.numPriority = new System.Windows.Forms.NumericUpDown();
            this.lblProgressLabel = new System.Windows.Forms.Label();
            this.trackProgress = new System.Windows.Forms.TrackBar();
            this.tabTaskAttachments = new System.Windows.Forms.TabPage();
            this.tableFileAttachments = new System.Windows.Forms.TableLayoutPanel();
            this.listFileAttachments = new System.Windows.Forms.ListBox();
            this.flowAttachmentControls = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAttach = new System.Windows.Forms.Button();
            this.btnSaveAttachment = new System.Windows.Forms.Button();
            this.btnDeleteAttachment = new System.Windows.Forms.Button();
            this.tableComments = new System.Windows.Forms.TableLayoutPanel();
            this.flowComments = new System.Windows.Forms.FlowLayoutPanel();
            this.tableCommentControl = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClearComment = new System.Windows.Forms.Button();
            this.btnAddComment = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblAddCommentLbl = new System.Windows.Forms.Label();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.minimizeToTaskTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.editUserDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitStatusFromMain = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblSearchCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gvTasks)).BeginInit();
            this.panTop.SuspendLayout();
            this.splitLeftRight.Panel1.SuspendLayout();
            this.splitLeftRight.Panel2.SuspendLayout();
            this.splitLeftRight.SuspendLayout();
            this.splitTopBottom.Panel1.SuspendLayout();
            this.splitTopBottom.Panel2.SuspendLayout();
            this.splitTopBottom.SuspendLayout();
            this.splitTopLeftRight.Panel1.SuspendLayout();
            this.splitTopLeftRight.Panel2.SuspendLayout();
            this.splitTopLeftRight.SuspendLayout();
            this.tableFilterControls.SuspendLayout();
            this.splitBottomLeftRight.Panel1.SuspendLayout();
            this.splitBottomLeftRight.Panel2.SuspendLayout();
            this.splitBottomLeftRight.SuspendLayout();
            this.tabTaskInfo.SuspendLayout();
            this.tabTaskDetails.SuspendLayout();
            this.tableTaskDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackProgress)).BeginInit();
            this.tabTaskAttachments.SuspendLayout();
            this.tableFileAttachments.SuspendLayout();
            this.flowAttachmentControls.SuspendLayout();
            this.tableComments.SuspendLayout();
            this.tableCommentControl.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.splitStatusFromMain.Panel1.SuspendLayout();
            this.splitStatusFromMain.Panel2.SuspendLayout();
            this.splitStatusFromMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTags
            // 
            this.lstTags.CheckOnClick = true;
            this.lstTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTags.FormattingEnabled = true;
            this.lstTags.Location = new System.Drawing.Point(3, 23);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(165, 154);
            this.lstTags.TabIndex = 0;
            this.lstTags.ThreeDCheckBoxes = true;
            this.lstTags.SelectedIndexChanged += new System.EventHandler(this.lstTags_SelectedIndexChanged);
            // 
            // lstTagsOnTask
            // 
            this.lstTagsOnTask.CheckOnClick = true;
            this.lstTagsOnTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTagsOnTask.FormattingEnabled = true;
            this.lstTagsOnTask.Location = new System.Drawing.Point(0, 0);
            this.lstTagsOnTask.Name = "lstTagsOnTask";
            this.lstTagsOnTask.Size = new System.Drawing.Size(171, 244);
            this.lstTagsOnTask.TabIndex = 3;
            this.lstTagsOnTask.ThreeDCheckBoxes = true;
            this.lstTagsOnTask.SelectedIndexChanged += new System.EventHandler(this.lstTagsOnTask_SelectedIndexChanged);
            // 
            // gvTasks
            // 
            this.gvTasks.AllowUserToAddRows = false;
            this.gvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskID,
            this.Priority,
            this.Progress,
            this.Title,
            this.DateCreated,
            this.DueDate});
            this.gvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvTasks.Location = new System.Drawing.Point(0, 0);
            this.gvTasks.Name = "gvTasks";
            this.gvTasks.Size = new System.Drawing.Size(501, 234);
            this.gvTasks.TabIndex = 1;
            this.gvTasks.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gvTasks_UserDeletingRow);
            this.gvTasks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvTasks_CellClick);
            this.gvTasks.SelectionChanged += new System.EventHandler(this.gvTasks_SelectionChanged);
            // 
            // TaskID
            // 
            this.TaskID.HeaderText = "#";
            this.TaskID.Name = "TaskID";
            this.TaskID.ReadOnly = true;
            this.TaskID.Width = 30;
            // 
            // Priority
            // 
            this.Priority.HeaderText = "P";
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            this.Priority.Width = 20;
            // 
            // Progress
            // 
            this.Progress.HeaderText = "%";
            this.Progress.Name = "Progress";
            this.Progress.ReadOnly = true;
            this.Progress.Width = 30;
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.Width = 170;
            // 
            // DateCreated
            // 
            this.DateCreated.HeaderText = "Created";
            this.DateCreated.Name = "DateCreated";
            this.DateCreated.ReadOnly = true;
            this.DateCreated.Width = 120;
            // 
            // DueDate
            // 
            this.DueDate.HeaderText = "Due";
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            this.DueDate.Width = 120;
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.splitLeftRight);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(970, 493);
            this.panTop.TabIndex = 3;
            // 
            // splitLeftRight
            // 
            this.splitLeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLeftRight.Location = new System.Drawing.Point(0, 0);
            this.splitLeftRight.Name = "splitLeftRight";
            // 
            // splitLeftRight.Panel1
            // 
            this.splitLeftRight.Panel1.Controls.Add(this.splitTopBottom);
            // 
            // splitLeftRight.Panel2
            // 
            this.splitLeftRight.Panel2.Controls.Add(this.tableComments);
            this.splitLeftRight.Size = new System.Drawing.Size(970, 493);
            this.splitLeftRight.SplitterDistance = 680;
            this.splitLeftRight.TabIndex = 3;
            // 
            // splitTopBottom
            // 
            this.splitTopBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTopBottom.Location = new System.Drawing.Point(0, 0);
            this.splitTopBottom.Name = "splitTopBottom";
            this.splitTopBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitTopBottom.Panel1
            // 
            this.splitTopBottom.Panel1.Controls.Add(this.splitTopLeftRight);
            // 
            // splitTopBottom.Panel2
            // 
            this.splitTopBottom.Panel2.Controls.Add(this.splitBottomLeftRight);
            this.splitTopBottom.Size = new System.Drawing.Size(680, 493);
            this.splitTopBottom.SplitterDistance = 236;
            this.splitTopBottom.TabIndex = 2;
            // 
            // splitTopLeftRight
            // 
            this.splitTopLeftRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitTopLeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTopLeftRight.Location = new System.Drawing.Point(0, 0);
            this.splitTopLeftRight.Name = "splitTopLeftRight";
            // 
            // splitTopLeftRight.Panel1
            // 
            this.splitTopLeftRight.Panel1.Controls.Add(this.tableFilterControls);
            // 
            // splitTopLeftRight.Panel2
            // 
            this.splitTopLeftRight.Panel2.Controls.Add(this.gvTasks);
            this.splitTopLeftRight.Size = new System.Drawing.Size(680, 236);
            this.splitTopLeftRight.SplitterDistance = 173;
            this.splitTopLeftRight.TabIndex = 0;
            this.splitTopLeftRight.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitTopLeftRight_SplitterMoved);
            // 
            // tableFilterControls
            // 
            this.tableFilterControls.ColumnCount = 1;
            this.tableFilterControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableFilterControls.Controls.Add(this.lstTags, 0, 1);
            this.tableFilterControls.Controls.Add(this.lblSearchTagsLbl, 0, 0);
            this.tableFilterControls.Controls.Add(this.lblFilterUserLbl, 0, 2);
            this.tableFilterControls.Controls.Add(this.comboFilterAssignUser, 0, 3);
            this.tableFilterControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableFilterControls.Location = new System.Drawing.Point(0, 0);
            this.tableFilterControls.Name = "tableFilterControls";
            this.tableFilterControls.RowCount = 4;
            this.tableFilterControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.4F));
            this.tableFilterControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.6F));
            this.tableFilterControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableFilterControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableFilterControls.Size = new System.Drawing.Size(171, 234);
            this.tableFilterControls.TabIndex = 0;
            // 
            // lblSearchTagsLbl
            // 
            this.lblSearchTagsLbl.AutoSize = true;
            this.lblSearchTagsLbl.Location = new System.Drawing.Point(3, 0);
            this.lblSearchTagsLbl.Name = "lblSearchTagsLbl";
            this.lblSearchTagsLbl.Size = new System.Drawing.Size(83, 13);
            this.lblSearchTagsLbl.TabIndex = 1;
            this.lblSearchTagsLbl.Text = "Search By Tags";
            // 
            // lblFilterUserLbl
            // 
            this.lblFilterUserLbl.AutoSize = true;
            this.lblFilterUserLbl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFilterUserLbl.Location = new System.Drawing.Point(3, 195);
            this.lblFilterUserLbl.Name = "lblFilterUserLbl";
            this.lblFilterUserLbl.Size = new System.Drawing.Size(165, 13);
            this.lblFilterUserLbl.TabIndex = 2;
            this.lblFilterUserLbl.Text = "Filter By Assigned User";
            // 
            // comboFilterAssignUser
            // 
            this.comboFilterAssignUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboFilterAssignUser.FormattingEnabled = true;
            this.comboFilterAssignUser.Location = new System.Drawing.Point(3, 211);
            this.comboFilterAssignUser.Name = "comboFilterAssignUser";
            this.comboFilterAssignUser.Size = new System.Drawing.Size(165, 21);
            this.comboFilterAssignUser.TabIndex = 3;
            this.comboFilterAssignUser.SelectedIndexChanged += new System.EventHandler(this.comboFilterAssignUser_SelectedIndexChanged);
            // 
            // splitBottomLeftRight
            // 
            this.splitBottomLeftRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitBottomLeftRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitBottomLeftRight.Location = new System.Drawing.Point(0, 0);
            this.splitBottomLeftRight.Name = "splitBottomLeftRight";
            // 
            // splitBottomLeftRight.Panel1
            // 
            this.splitBottomLeftRight.Panel1.Controls.Add(this.lstTagsOnTask);
            // 
            // splitBottomLeftRight.Panel2
            // 
            this.splitBottomLeftRight.Panel2.Controls.Add(this.tabTaskInfo);
            this.splitBottomLeftRight.Size = new System.Drawing.Size(680, 253);
            this.splitBottomLeftRight.SplitterDistance = 173;
            this.splitBottomLeftRight.TabIndex = 0;
            this.splitBottomLeftRight.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitBottomLeftRight_SplitterMoved);
            // 
            // tabTaskInfo
            // 
            this.tabTaskInfo.Controls.Add(this.tabTaskDetails);
            this.tabTaskInfo.Controls.Add(this.tabTaskAttachments);
            this.tabTaskInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTaskInfo.Location = new System.Drawing.Point(0, 0);
            this.tabTaskInfo.Name = "tabTaskInfo";
            this.tabTaskInfo.SelectedIndex = 0;
            this.tabTaskInfo.Size = new System.Drawing.Size(501, 251);
            this.tabTaskInfo.TabIndex = 5;
            // 
            // tabTaskDetails
            // 
            this.tabTaskDetails.Controls.Add(this.tableTaskDetail);
            this.tabTaskDetails.Location = new System.Drawing.Point(4, 22);
            this.tabTaskDetails.Name = "tabTaskDetails";
            this.tabTaskDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabTaskDetails.Size = new System.Drawing.Size(493, 225);
            this.tabTaskDetails.TabIndex = 0;
            this.tabTaskDetails.Text = "Task Details";
            this.tabTaskDetails.UseVisualStyleBackColor = true;
            // 
            // tableTaskDetail
            // 
            this.tableTaskDetail.ColumnCount = 4;
            this.tableTaskDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableTaskDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTaskDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableTaskDetail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableTaskDetail.Controls.Add(this.datePickDueDate, 1, 2);
            this.tableTaskDetail.Controls.Add(this.txtDescription, 0, 3);
            this.tableTaskDetail.Controls.Add(this.lblCreatorLbl, 0, 0);
            this.tableTaskDetail.Controls.Add(this.lblCreator, 1, 0);
            this.tableTaskDetail.Controls.Add(this.lblUserAssignedLbl, 0, 1);
            this.tableTaskDetail.Controls.Add(this.comboUserAssigned, 1, 1);
            this.tableTaskDetail.Controls.Add(this.lblDueDateLbl, 0, 2);
            this.tableTaskDetail.Controls.Add(this.lblPriorityLabel, 2, 0);
            this.tableTaskDetail.Controls.Add(this.numPriority, 3, 0);
            this.tableTaskDetail.Controls.Add(this.lblProgressLabel, 2, 2);
            this.tableTaskDetail.Controls.Add(this.trackProgress, 3, 2);
            this.tableTaskDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableTaskDetail.Location = new System.Drawing.Point(3, 3);
            this.tableTaskDetail.Name = "tableTaskDetail";
            this.tableTaskDetail.RowCount = 4;
            this.tableTaskDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableTaskDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableTaskDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableTaskDetail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableTaskDetail.Size = new System.Drawing.Size(487, 219);
            this.tableTaskDetail.TabIndex = 4;
            // 
            // datePickDueDate
            // 
            this.datePickDueDate.Location = new System.Drawing.Point(99, 48);
            this.datePickDueDate.Name = "datePickDueDate";
            this.datePickDueDate.Size = new System.Drawing.Size(187, 20);
            this.datePickDueDate.TabIndex = 5;
            this.datePickDueDate.ValueChanged += new System.EventHandler(this.datePickDueDate_ValueChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.AcceptsReturn = true;
            this.txtDescription.AcceptsTab = true;
            this.tableTaskDetail.SetColumnSpan(this.txtDescription, 4);
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(3, 81);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(481, 135);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            // 
            // lblCreatorLbl
            // 
            this.lblCreatorLbl.AutoSize = true;
            this.lblCreatorLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblCreatorLbl.Location = new System.Drawing.Point(46, 0);
            this.lblCreatorLbl.Name = "lblCreatorLbl";
            this.lblCreatorLbl.Size = new System.Drawing.Size(47, 20);
            this.lblCreatorLbl.TabIndex = 5;
            this.lblCreatorLbl.Text = "Creator: ";
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCreator.Location = new System.Drawing.Point(99, 0);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(46, 20);
            this.lblCreator.TabIndex = 1;
            this.lblCreator.Text = "(creator)";
            // 
            // lblUserAssignedLbl
            // 
            this.lblUserAssignedLbl.AutoSize = true;
            this.lblUserAssignedLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUserAssignedLbl.Location = new System.Drawing.Point(21, 20);
            this.lblUserAssignedLbl.Name = "lblUserAssignedLbl";
            this.lblUserAssignedLbl.Size = new System.Drawing.Size(72, 25);
            this.lblUserAssignedLbl.TabIndex = 0;
            this.lblUserAssignedLbl.Text = "Assigned To: ";
            // 
            // comboUserAssigned
            // 
            this.tableTaskDetail.SetColumnSpan(this.comboUserAssigned, 3);
            this.comboUserAssigned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboUserAssigned.FormattingEnabled = true;
            this.comboUserAssigned.Location = new System.Drawing.Point(99, 23);
            this.comboUserAssigned.Name = "comboUserAssigned";
            this.comboUserAssigned.Size = new System.Drawing.Size(385, 21);
            this.comboUserAssigned.TabIndex = 4;
            this.comboUserAssigned.SelectedIndexChanged += new System.EventHandler(this.comboUserAssigned_SelectedIndexChanged);
            // 
            // lblDueDateLbl
            // 
            this.lblDueDateLbl.AutoSize = true;
            this.lblDueDateLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDueDateLbl.Location = new System.Drawing.Point(34, 45);
            this.lblDueDateLbl.Name = "lblDueDateLbl";
            this.lblDueDateLbl.Size = new System.Drawing.Size(59, 33);
            this.lblDueDateLbl.TabIndex = 6;
            this.lblDueDateLbl.Text = "Due Date: ";
            // 
            // lblPriorityLabel
            // 
            this.lblPriorityLabel.AutoSize = true;
            this.lblPriorityLabel.Location = new System.Drawing.Point(292, 0);
            this.lblPriorityLabel.Name = "lblPriorityLabel";
            this.lblPriorityLabel.Size = new System.Drawing.Size(38, 13);
            this.lblPriorityLabel.TabIndex = 7;
            this.lblPriorityLabel.Text = "Priority";
            // 
            // numPriority
            // 
            this.numPriority.Location = new System.Drawing.Point(350, 3);
            this.numPriority.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPriority.Name = "numPriority";
            this.numPriority.Size = new System.Drawing.Size(38, 20);
            this.numPriority.TabIndex = 8;
            this.numPriority.ValueChanged += new System.EventHandler(this.numPriority_ValueChanged);
            // 
            // lblProgressLabel
            // 
            this.lblProgressLabel.AutoSize = true;
            this.lblProgressLabel.Location = new System.Drawing.Point(292, 45);
            this.lblProgressLabel.Name = "lblProgressLabel";
            this.lblProgressLabel.Size = new System.Drawing.Size(48, 13);
            this.lblProgressLabel.TabIndex = 9;
            this.lblProgressLabel.Text = "Progress";
            // 
            // trackProgress
            // 
            this.trackProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackProgress.Location = new System.Drawing.Point(350, 48);
            this.trackProgress.Maximum = 100;
            this.trackProgress.Name = "trackProgress";
            this.trackProgress.Size = new System.Drawing.Size(134, 27);
            this.trackProgress.TabIndex = 10;
            this.trackProgress.TickFrequency = 5;
            this.trackProgress.ValueChanged += new System.EventHandler(this.trackProgress_ValueChanged);
            // 
            // tabTaskAttachments
            // 
            this.tabTaskAttachments.Controls.Add(this.tableFileAttachments);
            this.tabTaskAttachments.Location = new System.Drawing.Point(4, 22);
            this.tabTaskAttachments.Name = "tabTaskAttachments";
            this.tabTaskAttachments.Padding = new System.Windows.Forms.Padding(3);
            this.tabTaskAttachments.Size = new System.Drawing.Size(493, 225);
            this.tabTaskAttachments.TabIndex = 1;
            this.tabTaskAttachments.Text = "File Attachments";
            this.tabTaskAttachments.UseVisualStyleBackColor = true;
            // 
            // tableFileAttachments
            // 
            this.tableFileAttachments.ColumnCount = 2;
            this.tableFileAttachments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableFileAttachments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableFileAttachments.Controls.Add(this.listFileAttachments, 0, 0);
            this.tableFileAttachments.Controls.Add(this.flowAttachmentControls, 1, 0);
            this.tableFileAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableFileAttachments.Location = new System.Drawing.Point(3, 3);
            this.tableFileAttachments.Name = "tableFileAttachments";
            this.tableFileAttachments.RowCount = 1;
            this.tableFileAttachments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableFileAttachments.Size = new System.Drawing.Size(487, 219);
            this.tableFileAttachments.TabIndex = 0;
            // 
            // listFileAttachments
            // 
            this.listFileAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFileAttachments.FormattingEnabled = true;
            this.listFileAttachments.Location = new System.Drawing.Point(3, 3);
            this.listFileAttachments.Name = "listFileAttachments";
            this.listFileAttachments.Size = new System.Drawing.Size(392, 212);
            this.listFileAttachments.TabIndex = 0;
            // 
            // flowAttachmentControls
            // 
            this.flowAttachmentControls.Controls.Add(this.btnAttach);
            this.flowAttachmentControls.Controls.Add(this.btnSaveAttachment);
            this.flowAttachmentControls.Controls.Add(this.btnDeleteAttachment);
            this.flowAttachmentControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowAttachmentControls.Location = new System.Drawing.Point(401, 3);
            this.flowAttachmentControls.Name = "flowAttachmentControls";
            this.flowAttachmentControls.Size = new System.Drawing.Size(83, 213);
            this.flowAttachmentControls.TabIndex = 1;
            // 
            // btnAttach
            // 
            this.btnAttach.Location = new System.Drawing.Point(3, 3);
            this.btnAttach.Name = "btnAttach";
            this.btnAttach.Size = new System.Drawing.Size(75, 23);
            this.btnAttach.TabIndex = 2;
            this.btnAttach.Text = "Attach";
            this.btnAttach.UseVisualStyleBackColor = true;
            this.btnAttach.Click += new System.EventHandler(this.btnAttach_Click);
            // 
            // btnSaveAttachment
            // 
            this.btnSaveAttachment.Location = new System.Drawing.Point(3, 32);
            this.btnSaveAttachment.Name = "btnSaveAttachment";
            this.btnSaveAttachment.Size = new System.Drawing.Size(75, 23);
            this.btnSaveAttachment.TabIndex = 0;
            this.btnSaveAttachment.Text = "Save";
            this.btnSaveAttachment.UseVisualStyleBackColor = true;
            this.btnSaveAttachment.Click += new System.EventHandler(this.btnSaveAttachment_Click);
            // 
            // btnDeleteAttachment
            // 
            this.btnDeleteAttachment.Location = new System.Drawing.Point(3, 61);
            this.btnDeleteAttachment.Name = "btnDeleteAttachment";
            this.btnDeleteAttachment.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAttachment.TabIndex = 1;
            this.btnDeleteAttachment.Text = "Delete";
            this.btnDeleteAttachment.UseVisualStyleBackColor = true;
            this.btnDeleteAttachment.Click += new System.EventHandler(this.btnDeleteAttachment_Click);
            // 
            // tableComments
            // 
            this.tableComments.ColumnCount = 1;
            this.tableComments.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableComments.Controls.Add(this.flowComments, 0, 0);
            this.tableComments.Controls.Add(this.tableCommentControl, 0, 1);
            this.tableComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableComments.Location = new System.Drawing.Point(0, 0);
            this.tableComments.Name = "tableComments";
            this.tableComments.RowCount = 2;
            this.tableComments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.76471F));
            this.tableComments.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.23529F));
            this.tableComments.Size = new System.Drawing.Size(286, 493);
            this.tableComments.TabIndex = 0;
            // 
            // flowComments
            // 
            this.flowComments.AutoScroll = true;
            this.flowComments.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowComments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowComments.Location = new System.Drawing.Point(3, 3);
            this.flowComments.Name = "flowComments";
            this.flowComments.Size = new System.Drawing.Size(280, 347);
            this.flowComments.TabIndex = 0;
            // 
            // tableCommentControl
            // 
            this.tableCommentControl.ColumnCount = 1;
            this.tableCommentControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableCommentControl.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableCommentControl.Controls.Add(this.txtComment, 0, 1);
            this.tableCommentControl.Controls.Add(this.lblAddCommentLbl, 0, 0);
            this.tableCommentControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableCommentControl.Location = new System.Drawing.Point(3, 356);
            this.tableCommentControl.Name = "tableCommentControl";
            this.tableCommentControl.RowCount = 3;
            this.tableCommentControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableCommentControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableCommentControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableCommentControl.Size = new System.Drawing.Size(280, 134);
            this.tableCommentControl.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnClearComment);
            this.flowLayoutPanel1.Controls.Add(this.btnAddComment);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 103);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(280, 31);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnClearComment
            // 
            this.btnClearComment.Location = new System.Drawing.Point(202, 3);
            this.btnClearComment.Name = "btnClearComment";
            this.btnClearComment.Size = new System.Drawing.Size(75, 23);
            this.btnClearComment.TabIndex = 0;
            this.btnClearComment.Text = "Clear";
            this.btnClearComment.UseVisualStyleBackColor = true;
            this.btnClearComment.Click += new System.EventHandler(this.btnClearComment_Click);
            // 
            // btnAddComment
            // 
            this.btnAddComment.Location = new System.Drawing.Point(121, 3);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(75, 23);
            this.btnAddComment.TabIndex = 1;
            this.btnAddComment.Text = "Add";
            this.btnAddComment.UseVisualStyleBackColor = true;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // txtComment
            // 
            this.txtComment.AcceptsReturn = true;
            this.txtComment.AcceptsTab = true;
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComment.Location = new System.Drawing.Point(3, 20);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(274, 80);
            this.txtComment.TabIndex = 3;
            // 
            // lblAddCommentLbl
            // 
            this.lblAddCommentLbl.AutoSize = true;
            this.lblAddCommentLbl.Location = new System.Drawing.Point(3, 0);
            this.lblAddCommentLbl.Name = "lblAddCommentLbl";
            this.lblAddCommentLbl.Size = new System.Drawing.Size(73, 13);
            this.lblAddCommentLbl.TabIndex = 4;
            this.lblAddCommentLbl.Text = "Add Comment";
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(970, 24);
            this.menuMain.TabIndex = 4;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.toolStripSeparator2,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator1,
            this.minimizeToTaskTrayToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.loginToolStripMenuItem.Text = "&Login...";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.logoutToolStripMenuItem.Text = "L&ogout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(187, 6);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.importToolStripMenuItem.Text = "&Import...";
            this.importToolStripMenuItem.Visible = false;
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exportToolStripMenuItem.Text = "&Export...";
            this.exportToolStripMenuItem.Visible = false;
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // minimizeToTaskTrayToolStripMenuItem
            // 
            this.minimizeToTaskTrayToolStripMenuItem.Name = "minimizeToTaskTrayToolStripMenuItem";
            this.minimizeToTaskTrayToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.minimizeToTaskTrayToolStripMenuItem.Text = "&Minimize to Task Tray";
            this.minimizeToTaskTrayToolStripMenuItem.Click += new System.EventHandler(this.minimizeToTaskTrayToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(187, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTaskToolStripMenuItem,
            this.manageTagsToolStripMenuItem,
            this.toolStripSeparator3,
            this.editUserDetailsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // addTaskToolStripMenuItem
            // 
            this.addTaskToolStripMenuItem.Name = "addTaskToolStripMenuItem";
            this.addTaskToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.addTaskToolStripMenuItem.Text = "&Add Task";
            this.addTaskToolStripMenuItem.Click += new System.EventHandler(this.addTaskToolStripMenuItem_Click);
            // 
            // manageTagsToolStripMenuItem
            // 
            this.manageTagsToolStripMenuItem.Name = "manageTagsToolStripMenuItem";
            this.manageTagsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.manageTagsToolStripMenuItem.Text = "&Manage Tags";
            this.manageTagsToolStripMenuItem.Click += new System.EventHandler(this.manageTagsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(155, 6);
            // 
            // editUserDetailsToolStripMenuItem
            // 
            this.editUserDetailsToolStripMenuItem.Name = "editUserDetailsToolStripMenuItem";
            this.editUserDetailsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.editUserDetailsToolStripMenuItem.Text = "Edit &User Details";
            this.editUserDetailsToolStripMenuItem.Click += new System.EventHandler(this.editUserDetailsToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "&About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // splitStatusFromMain
            // 
            this.splitStatusFromMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitStatusFromMain.Location = new System.Drawing.Point(0, 24);
            this.splitStatusFromMain.Name = "splitStatusFromMain";
            this.splitStatusFromMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitStatusFromMain.Panel1
            // 
            this.splitStatusFromMain.Panel1.Controls.Add(this.panTop);
            // 
            // splitStatusFromMain.Panel2
            // 
            this.splitStatusFromMain.Panel2.Controls.Add(this.statusStrip1);
            this.splitStatusFromMain.Size = new System.Drawing.Size(970, 528);
            this.splitStatusFromMain.SplitterDistance = 493;
            this.splitStatusFromMain.TabIndex = 6;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSearchCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 9);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(970, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // lblSearchCount
            // 
            this.lblSearchCount.Name = "lblSearchCount";
            this.lblSearchCount.Size = new System.Drawing.Size(0, 17);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "TaskPad v1.0";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 552);
            this.Controls.Add(this.splitStatusFromMain);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "TaskPad v1.0";
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gvTasks)).EndInit();
            this.panTop.ResumeLayout(false);
            this.splitLeftRight.Panel1.ResumeLayout(false);
            this.splitLeftRight.Panel2.ResumeLayout(false);
            this.splitLeftRight.ResumeLayout(false);
            this.splitTopBottom.Panel1.ResumeLayout(false);
            this.splitTopBottom.Panel2.ResumeLayout(false);
            this.splitTopBottom.ResumeLayout(false);
            this.splitTopLeftRight.Panel1.ResumeLayout(false);
            this.splitTopLeftRight.Panel2.ResumeLayout(false);
            this.splitTopLeftRight.ResumeLayout(false);
            this.tableFilterControls.ResumeLayout(false);
            this.tableFilterControls.PerformLayout();
            this.splitBottomLeftRight.Panel1.ResumeLayout(false);
            this.splitBottomLeftRight.Panel2.ResumeLayout(false);
            this.splitBottomLeftRight.ResumeLayout(false);
            this.tabTaskInfo.ResumeLayout(false);
            this.tabTaskDetails.ResumeLayout(false);
            this.tableTaskDetail.ResumeLayout(false);
            this.tableTaskDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackProgress)).EndInit();
            this.tabTaskAttachments.ResumeLayout(false);
            this.tableFileAttachments.ResumeLayout(false);
            this.flowAttachmentControls.ResumeLayout(false);
            this.tableComments.ResumeLayout(false);
            this.tableCommentControl.ResumeLayout(false);
            this.tableCommentControl.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.splitStatusFromMain.Panel1.ResumeLayout(false);
            this.splitStatusFromMain.Panel2.ResumeLayout(false);
            this.splitStatusFromMain.Panel2.PerformLayout();
            this.splitStatusFromMain.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox lstTags;
        private System.Windows.Forms.DataGridView gvTasks;
        private System.Windows.Forms.CheckedListBox lstTagsOnTask;
        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTagsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editUserDetailsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitTopBottom;
        private System.Windows.Forms.SplitContainer splitTopLeftRight;
        private System.Windows.Forms.SplitContainer splitBottomLeftRight;
        private System.Windows.Forms.SplitContainer splitLeftRight;
        private System.Windows.Forms.TableLayoutPanel tableComments;
        private System.Windows.Forms.FlowLayoutPanel flowComments;
        private System.Windows.Forms.TableLayoutPanel tableCommentControl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnClearComment;
        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblAddCommentLbl;
        private System.Windows.Forms.TableLayoutPanel tableFilterControls;
        private System.Windows.Forms.Label lblSearchTagsLbl;
        private System.Windows.Forms.Label lblFilterUserLbl;
        private System.Windows.Forms.ComboBox comboFilterAssignUser;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitStatusFromMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Progress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabControl tabTaskInfo;
        private System.Windows.Forms.TabPage tabTaskDetails;
        private System.Windows.Forms.TableLayoutPanel tableTaskDetail;
        private System.Windows.Forms.DateTimePicker datePickDueDate;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblCreatorLbl;
        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.Label lblUserAssignedLbl;
        private System.Windows.Forms.ComboBox comboUserAssigned;
        private System.Windows.Forms.Label lblDueDateLbl;
        private System.Windows.Forms.Label lblPriorityLabel;
        private System.Windows.Forms.NumericUpDown numPriority;
        private System.Windows.Forms.Label lblProgressLabel;
        private System.Windows.Forms.TrackBar trackProgress;
        private System.Windows.Forms.TabPage tabTaskAttachments;
        private System.Windows.Forms.TableLayoutPanel tableFileAttachments;
        private System.Windows.Forms.ListBox listFileAttachments;
        private System.Windows.Forms.FlowLayoutPanel flowAttachmentControls;
        private System.Windows.Forms.Button btnSaveAttachment;
        private System.Windows.Forms.Button btnDeleteAttachment;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToTaskTrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.ToolStripStatusLabel lblSearchCount;
    }
}

