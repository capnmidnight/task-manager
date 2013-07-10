using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TaskManager.DataAccess
{
    /// <summary>
    /// A simple structure for encapsulating task data
    /// </summary>
    public interface ITask
    {
        string Title { get;}
        string Description { get;}
        DateTime DateCreated { get;}
        DateTime DueDate { get;}
        int TaskID { get;}
        int UserCreator { get;}
        int UserAssigned { get;}
        int Priority { get;}
        int Progress { get;}
    }

    public interface ITaskAdapter
    {
        ITask Get(int taskID);
        int Create(string title, string description, int userCreator, int userAssigned, int priority, int progress, DateTime dueDate);
        void Delete(int taskID);
        void Edit(int taskID, string title, string description, int userAssigned, int priority, int progress, DateTime dueDate);
        List<IComment> GetComments(int taskID);
        List<ITag> GetTags(int taskID);
        List<IAttachmentReference> GetAttachments(int taskID);
        List<ITask> Find(List<int> tagIDs, int userAssignedID, DateTime dueDate);
        void AddTag(int tagID, int taskID);
        void RemoveTag(int tagID, int taskID);
    }
}