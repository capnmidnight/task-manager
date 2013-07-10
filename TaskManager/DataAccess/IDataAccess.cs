using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace TaskManager.DataAccess
{
    public interface IDataAccess : IDisposable
    {
        void CreateAttachment(int taskID, string fileName, byte[] fileData);
        Attachment GetAttachment(int attachmentID);
        void DeleteAttachment(int attachmentID);

        void AddComment(int userID, int taskID, string text);
        void DeleteComment(int commentID);

        void CreateTag(string name, string description, bool isDefault);
        void DeleteTag(int tagID);
        void EditTag(int tagID, string name, string description, bool isDefault);
        List<Tag> GetAllTags();

        void CreateTask(string title, string description, int userCreator, int userAssigned, int priority, int progress, DateTime dueDate, List<int> tagIDs);
        void DeleteTask(int taskID);
        void EditTask(int taskID, string title, string description, int userAssigned, int priority, int progress, DateTime dueDate);
        List<Comment> GetCommentsOnTask(int taskID);
        List<Tag> GetTagsOnTask(int taskID);
        Task GetTask(int taskID);
        List<Task> FindTasks(List<int> tagIDs, int userAssignedID, DateTime dueDate);
        void AddTagToTask(int tagID, int taskID);
        void RemoveTagFromTask(int tagID, int taskID);
        List<AttachmentReference> GetAttachmentsOnTask(int taskID);

        void CreateUser(string username, string password, string email);
        void EditUser(int userID, string password, string email);
        User GetUser(int userID);
        List<User> GetAllUsers();
        int CheckUser(string userName, string password);
    }
}