using System;

namespace TaskManager.DataAccess
{

    public class AttachmentReference : DataAdapter<AttachmentReference>
    {
        public int attachmentID, taskID;
        public string fileName;

        public int AttachmentID { get { return this.attachmentID; } }
        public int TaskID { get { return this.taskID; } }
        public string FileName { get { return this.fileName; } }

        public override string ToString()
        {
            return fileName;
        }
    }
}
