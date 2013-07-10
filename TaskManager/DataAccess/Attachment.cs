using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TaskManager.DataAccess
{
    public class Attachment : DataAdapter<Attachment>
    {
        public int attachmentID, taskID;
        public string fileName;
        public byte[] fileData;

        public int AttachmentID { get { return this.attachmentID; } }
        public int TaskID { get { return this.taskID; } }
        public string FileName { get { return this.fileName; } }
        public byte[] FileData { get { return this.fileData; } }
    }
}
