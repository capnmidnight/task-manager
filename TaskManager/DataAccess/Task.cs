using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TaskManager.DataAccess
{
    public class Task : DataAdapter<Task>
    {
        public string title, description;
        public DateTime dateCreated, dueDate;
        public int taskID, userCreator, userAssigned, priority, progress;

        public string Title { get { return title; } }
        public string Description { get { return description; } }
        public DateTime DateCreated { get { return dateCreated; } }
        public DateTime DueDate { get { return dueDate; } }
        public int TaskID { get { return taskID; } }
        public int UserCreator { get { return userCreator; } }
        public int UserAssigned { get { return userAssigned; } }
        public int Priority { get { return priority; } }
        public int Progress { get { return progress; } }
    }
}