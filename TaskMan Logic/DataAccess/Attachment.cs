using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.DataAccess
{
    public interface IAttachmentReference
    {
        int AttachmentID { get;}
        int TaskID { get;}
        string FileName { get;}
    }

    public interface IAttachment : IAttachmentReference
    {
        byte[] FileData { get;}
    }


    public interface IAttachmentAdapter
    {
        int Create(int taskID, string filename, byte[] buffer);
        void Delete(int attachmentID);
        IAttachment Get(int attachmentID);
    }
}
