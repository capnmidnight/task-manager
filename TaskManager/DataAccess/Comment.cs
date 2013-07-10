using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TaskManager.DataAccess
{
    public class Comment : DataAdapter<Comment>
    {
        public int commentID, taskID, userID;
        public string text, UserName;
        public DateTime dateCreated;

        public int CommentID { get { return commentID; } }
        public int UserID { get { return userID; } }
        public int TaskID { get { return taskID; } }
        public string Text { get { return text; } }
        public DateTime DateCreated { get { return dateCreated; } }
    }
}