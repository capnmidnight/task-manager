using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TaskManager.DataAccess
{
    /// <summary>
    /// A simple structure for encapsulating comment data
    /// </summary>
    public interface IComment
    {
        int CommentID{get;}
        int UserID{get;}
        int TaskID{get;}
        string Text { get;}
        DateTime DateCreated { get;}
    }

    public interface ICommentAdapter
    {
        void Add(int userID, int taskID, string text);
        void Delete(int commentID);
    }
}