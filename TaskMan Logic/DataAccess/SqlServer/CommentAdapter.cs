using System;
using System.Data;
using System.Data.SqlClient;

namespace TaskManager.DataAccess.SqlServer
{
    public class Comment : DataAdapter<Comment>, IComment
    {
        public int commentID, taskID, userID;
        public string text;
        public DateTime dateCreated;

        public int CommentID { get { return commentID; } }
        public int UserID { get { return userID; } }
        public int TaskID { get { return taskID; } }
        public string Text { get { return text; } }
        public DateTime DateCreated { get { return dateCreated; } }
    }
    public class CommentAdapter : DataAccess, ICommentAdapter
    {
        public CommentAdapter(SqlConnection sqlConnection)
            : base(sqlConnection)
        {
        }

        public void Add(int userID, int taskID, string text)
        {
            this.Execute("Comment_Add", new SqlParameter("@UserID", userID),
                new SqlParameter("@TaskID", taskID),
                new SqlParameter("@Text", text));
        }

        public void Delete(int commentID)
        {
            this.Execute("Comment_Delete", new SqlParameter("@CommentID", commentID));
        }
    }
}
