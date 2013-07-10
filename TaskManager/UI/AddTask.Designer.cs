namespace TaskManager.UI
{
    partial class CreateTaskDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateTaskDialog));
            this.tableAddTask = new System.Windows.Forms.TableLayoutPanel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.numPriority = new System.Windows.Forms.NumericUpDown();
            this.comboUserAssigned = new System.Windows.Forms.ComboBox();
            this.flowControls = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lstTags = new System.Windows.Forms.CheckedListBox();
            this.lblUserAssignedLbl = new System.Windows.Forms.Label();
            this.lblPriorityLbl = new System.Windows.Forms.Label();
            this.lblDueDateLbl = new System.Windows.Forms.Label();
            this.datePickDueDate = new System.Windows.Forms.DateTimePicker();
            this.tableAddTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
            this.flowControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableAddTask
            // 
            this.tableAddTask.ColumnCount = 4;
            this.tableAddTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableAddTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableAddTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableAddTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204F));
            this.tableAddTask.Controls.Add(this.txtTitle, 0, 0);
            this.tableAddTask.Controls.Add(this.numPriority, 1, 1);
            this.tableAddTask.Controls.Add(this.comboUserAssigned, 3, 1);
            this.tableAddTask.Controls.Add(this.flowControls, 3, 4);
            this.tableAddTask.Controls.Add(this.txtDescription, 2, 3);
            this.tableAddTask.Controls.Add(this.lstTags, 0, 3);
            this.tableAddTask.Controls.Add(this.lblUserAssignedLbl, 2, 1);
            this.tableAddTask.Controls.Add(this.lblPriorityLbl, 0, 1);
            this.tableAddTask.Controls.Add(this.lblDueDateLbl, 0, 2);
            this.tableAddTask.Controls.Add(this.datePickDueDate, 1, 2);
            this.tableAddTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableAddTask.Location = new System.Drawing.Point(0, 0);
            this.tableAddTask.Name = "tableAddTask";
            this.tableAddTask.RowCount = 5;
            this.tableAddTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableAddTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableAddTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableAddTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableAddTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableAddTask.Size = new System.Drawing.Size(401, 424);
            this.tableAddTask.TabIndex = 0;
            // 
            // txtTitle
            // 
            this.tableAddTask.SetColumnSpan(this.txtTitle, 4);
            this.txtTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTitle.Location = new System.Drawing.Point(3, 3);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(395, 20);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Enter += new System.EventHandler(this.txtTitle_Enter);
            // 
            // numPriority
            // 
            this.numPriority.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numPriority.Location = new System.Drawing.Point(64, 28);
            this.numPriority.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPriority.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPriority.Name = "numPriority";
            this.numPriority.Size = new System.Drawing.Size(54, 20);
            this.numPriority.TabIndex = 1;
            this.numPriority.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboUserAssigned
            // 
            this.comboUserAssigned.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboUserAssigned.FormattingEnabled = true;
            this.comboUserAssigned.Location = new System.Drawing.Point(200, 28);
            this.comboUserAssigned.Name = "comboUserAssigned";
            this.comboUserAssigned.Size = new System.Drawing.Size(198, 21);
            this.comboUserAssigned.TabIndex = 1;
            // 
            // flowControls
            // 
            this.flowControls.Controls.Add(this.btnCancel);
            this.flowControls.Controls.Add(this.btnOK);
            this.flowControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowControls.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowControls.Location = new System.Drawing.Point(200, 387);
            this.flowControls.Name = "flowControls";
            this.flowControls.Size = new System.Drawing.Size(198, 34);
            this.flowControls.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(120, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(39, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.AcceptsReturn = true;
            this.txtDescription.AcceptsTab = true;
            this.tableAddTask.SetColumnSpan(this.txtDescription, 2);
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(124, 78);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(274, 303);
            this.txtDescription.TabIndex = 2;
            // 
            // lstTags
            // 
            this.lstTags.CheckOnClick = true;
            this.tableAddTask.SetColumnSpan(this.lstTags, 2);
            this.lstTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTags.FormattingEnabled = true;
            this.lstTags.Location = new System.Drawing.Point(3, 78);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(115, 289);
            this.lstTags.TabIndex = 5;
            this.lstTags.ThreeDCheckBoxes = true;
            // 
            // lblUserAssignedLbl
            // 
            this.lblUserAssignedLbl.AutoSize = true;
            this.lblUserAssignedLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblUserAssignedLbl.Location = new System.Drawing.Point(128, 25);
            this.lblUserAssignedLbl.Name = "lblUserAssignedLbl";
            this.lblUserAssignedLbl.Size = new System.Drawing.Size(66, 25);
            this.lblUserAssignedLbl.TabIndex = 6;
            this.lblUserAssignedLbl.Text = "Assigned To";
            // 
            // lblPriorityLbl
            // 
            this.lblPriorityLbl.AutoSize = true;
            this.lblPriorityLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblPriorityLbl.Location = new System.Drawing.Point(20, 25);
            this.lblPriorityLbl.Name = "lblPriorityLbl";
            this.lblPriorityLbl.Size = new System.Drawing.Size(38, 25);
            this.lblPriorityLbl.TabIndex = 7;
            this.lblPriorityLbl.Text = "Priority";
            // 
            // lblDueDateLbl
            // 
            this.lblDueDateLbl.AutoSize = true;
            this.lblDueDateLbl.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblDueDateLbl.Location = new System.Drawing.Point(5, 50);
            this.lblDueDateLbl.Name = "lblDueDateLbl";
            this.lblDueDateLbl.Size = new System.Drawing.Size(53, 25);
            this.lblDueDateLbl.TabIndex = 8;
            this.lblDueDateLbl.Text = "Due Date";
            // 
            // datePickDueDate
            // 
            this.tableAddTask.SetColumnSpan(this.datePickDueDate, 3);
            this.datePickDueDate.Location = new System.Drawing.Point(64, 53);
            this.datePickDueDate.Name = "datePickDueDate";
            this.datePickDueDate.Size = new System.Drawing.Size(200, 20);
            this.datePickDueDate.TabIndex = 9;
            // 
            // CreateTaskDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 424);
            this.Controls.Add(this.tableAddTask);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateTaskDialog";
            this.ShowInTaskbar = false;
            this.Text = "Add Task";
            this.Shown += new System.EventHandler(this.CreateTaskDialog_Shown);
            this.tableAddTask.ResumeLayout(false);
            this.tableAddTask.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
            this.flowControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableAddTask;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.NumericUpDown numPriority;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox comboUserAssigned;
        private System.Windows.Forms.FlowLayoutPanel flowControls;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckedListBox lstTags;
        private System.Windows.Forms.Label lblUserAssignedLbl;
        private System.Windows.Forms.Label lblPriorityLbl;
        private System.Windows.Forms.Label lblDueDateLbl;
        private System.Windows.Forms.DateTimePicker datePickDueDate;
    }
}