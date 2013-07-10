using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TaskManager.DataAccess.SqlServer
{
    public class Task : DataAdapter<Task>, ITask
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

    public class TaskAdapter : DataAccess, ITaskAdapter
    {
        public TaskAdapter(SqlConnection sqlConnection)
            : base(sqlConnection)
        {
        }

        public int Create(string title, string description, int userCreator, int userAssigned, int priority, int progress, DateTime dueDate)
        {
            return this.Execute<int>("Task_Create", SqlDbType.Int,
                new SqlParameter("@Title", title),
                new SqlParameter("@Description", description),
                new SqlParameter("@UserCreator", userCreator),
                new SqlParameter("@UserAssigned", userAssigned),
                new SqlParameter("@Priority", priority),
                new SqlParameter("@Progress", progress),
                new SqlParameter("@DueDate", dueDate));
        }

        public void Delete(int taskID)
        {
            this.Execute("Task_Delete", new SqlParameter("@TaskID", taskID));
        }

        public void Edit(int taskID, string title, string description, int userAssigned, int priority, int progress, DateTime dueDate)
        {
            this.Execute("Task_Edit",
                new SqlParameter("@TaskID", taskID),
                new SqlParameter("@Title", title),
                new SqlParameter("@Description", description),
                new SqlParameter("@UserAssigned", userAssigned),
                new SqlParameter("@Priority", priority),
                new SqlParameter("@Progress", progress),
                new SqlParameter("@DueDate", dueDate));
        }

        public List<IComment> GetComments(int taskID)
        {
            return this.GetList<Comment, IComment>("Task_GetComments", new SqlParameter("@TaskID", taskID));
        }

        public List<ITag> GetTags(int taskID)
        {
            return this.GetList<Tag, ITag>("Task_GetTags", new SqlParameter("@TaskID", taskID));
        }

        public ITask Get(int taskID)
        {
            return this.GetOne<Task, ITask>("Task_Get", new SqlParameter("@TaskID", taskID));
        }

        //TODO add duedate search
        [Obsolete]
        public List<ITask> Find(List<int> tagIDs, int userAssignedID, DateTime dueDate)
        {
            List<ITask> result = new List<ITask>();
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.Connection = sql;
                if (tagIDs.Count == 0)
                {
                    sqlCmd.CommandText = "Task_GetAll";
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userAssignedID;
                }
                else if (tagIDs.Count > 0)
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine(@"SELECT * 
FROM Tasks
WHERE TaskID IN
	(");
                    for (int index = 0; index < tagIDs.Count; ++index)
                    {
                        query.AppendFormat(@"(SELECT TaskID FROM TagsOnTasks
WHERE TagID = {0})
", tagIDs[index]);
                        if (index < tagIDs.Count - 1)
                            query.AppendLine("INTERSECT");
                    }
                    query.AppendLine(")");
                    if (userAssignedID > 0)
                        query.AppendFormat("AND UserAssigned={0}\n", userAssignedID);
                    query.Append("ORDER BY DateCreated DESC");
                    sqlCmd.CommandText = query.ToString();
                    sqlCmd.CommandType = CommandType.Text;
                }
                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd))
                {
                    using (DataSet output = new DataSet())
                    {
                        adapter.Fill(output);
                        foreach (DataRow row in output.Tables[0].Rows)
                            result.Add((Task)row);
                    }
                }
            }
            return result;
        }

        public void AddTag(int tagID, int taskID)
        {
            this.Execute("TagOnTask_Add", 
                new SqlParameter("@TagID", tagID), 
                new SqlParameter("@TaskID", taskID));
        }

        public void RemoveTag(int tagID, int taskID)
        {
            this.Execute("TagOnTask_Delete",
                new SqlParameter("@TagID", tagID),
                new SqlParameter("@TaskID", taskID));
        }

        public List<IAttachmentReference> GetAttachments(int taskID)
        {
            return this.GetList<AttachmentReference, IAttachmentReference>("Task_GetAttachments", new SqlParameter("@TaskID", taskID));
        }
    }
}
