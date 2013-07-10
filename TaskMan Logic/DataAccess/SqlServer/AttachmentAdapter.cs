using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TaskManager.DataAccess.SqlServer
{
    public class AttachmentReference : DataAdapter<AttachmentReference>, IAttachmentReference
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
    public class Attachment : DataAdapter<Attachment>, IAttachment
    {
        public int attachmentID, taskID;
        public string fileName;
        public byte[] fileData;

        public int AttachmentID { get { return this.attachmentID; } }
        public int TaskID { get { return this.taskID; } }
        public string FileName { get { return this.fileName; } }
        public byte[] FileData { get { return this.fileData; } }
    }
    public class AttachmentAdapter : DataAccess, IAttachmentAdapter
    {
        public AttachmentAdapter(SqlConnection sql)
            : base(sql)
        {
        }

        public int Create(int taskID, string fileName, byte[] fileData)
        {
            return this.Execute<int>("Attachment_Create", SqlDbType.Int, new SqlParameter("@TaskID", taskID),
                new SqlParameter("@FileName", fileName),
                new SqlParameter("@FileData", fileData));
        }

        public IAttachment Get(int attachmentID)
        {
            return this.GetOne<Attachment>("Attachment_Get", new SqlParameter("@AttachmentID", attachmentID));
        }

        public void Delete(int attachmentID)
        {
            this.GetOne<Attachment>("Attachment_Delete", new SqlParameter("@AttachmentID", attachmentID));
        }
    }
}
