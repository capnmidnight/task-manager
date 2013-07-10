using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using TaskManager.BusinessLogic;

namespace TaskManager.DataAccess
{
    /// <summary>
    /// An abstraction of a data source for the storing of task list information
    /// </summary>
    public abstract class InfoAdapter : IDisposable
    {
        protected ICommentAdapter commentAdapter;
        protected ITagAdapter tagAdapter;
        protected ITaskAdapter taskAdapter;
        protected IUserAdapter userAdapter;
        protected IAttachmentAdapter attachmentAdapter;

        public abstract void Dispose();

        // By seperating the data access methods in this way, it allows us to 
        // structure them by purpose, a sort of namespace aliasing within the
        // class itself.
        public ICommentAdapter Comment { get { return commentAdapter; } }
        public ITagAdapter Tag { get { return tagAdapter; } }
        public ITaskAdapter Task { get { return taskAdapter; } }
        public IUserAdapter User { get { return userAdapter; } }
        public IAttachmentAdapter Attachment { get { return attachmentAdapter; } }
    }
    /// <summary>
    /// An enumeration of the different types of data sources available to
    /// the application.
    /// </summary>
    public enum DataSourceTypes
    {
        Xml, SqlServer, SqlCompact
    }
}