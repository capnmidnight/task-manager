using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using TaskManager.BusinessLogic;

namespace TaskManager.DataAccess.MSSQL
{
    /// <summary>
    /// MS SQL Command Processor implements the necessary queries to operate with the
    /// Microsoft T-SQL engine used in both MS SQL Server and MS SQL Server Compact Edition.
    /// </summary>
    public abstract class MSSQLCommandProcessor : IDataAccess, IDisposable
    {
        protected DbConnection sql;
        protected abstract DbCommand NewCommand();
        protected abstract DbDataAdapter NewDataAdapter(DbCommand command);
        protected abstract DbParameter NewParameter(string name, SqlDbType type);
        protected abstract DbParameter NewParameter(string name, object value);
        /// <summary>
        /// Creates a stored procedure command call from a variable array of parameters
        /// </summary>
        /// <param name="procName">the stored procedure to use</param>
        /// <param name="parameters">a variable number of parameters to pass to the stored procedure.
        /// Null values are ignored.</param>
        /// <returns>a SqlCommand structure for encapsulating a stored procedure call</returns>
        protected DbCommand ConstructQueryCommand(string query, DbTransaction trans, params DbParameter[] parameters)
        {
            DbCommand command = this.NewCommand();
            if (trans != null)
                command.Transaction = trans;
            command.Connection = sql;
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            if (parameters != null)
                foreach (DbParameter parameter in parameters)
                    if (parameter.Value != null)
                        command.Parameters.Add(parameter);
            return command;
        }
        /// <summary>
        /// Creates a stored procedure command call from a variable array of parameters
        /// </summary>
        /// <param name="procName">the stored procedure to use</param>
        /// <param name="parameters">a variable number of parameters to pass to the stored procedure.
        /// Null values are ignored.</param>
        /// <returns>a SqlCommand structure for encapsulating a stored procedure call</returns>
        protected DbCommand ConstructQueryCommand(string query, bool useTransaction, params DbParameter[] parameters)
        {
            if (useTransaction)
                return this.ConstructQueryCommand(query, this.sql.BeginTransaction(), parameters);
            return this.ConstructQueryCommand(query, null, parameters);
        }
        /// <summary>
        /// Builds a stored procedure command call and executes it without returning any result set
        /// </summary>
        /// <param name="procName">the stored procedure to use</param>
        /// <param name="parameters">a variable number of parameters to pass to the stored procedure.
        /// Null values are ignored.</param>
        protected void ExecuteFromQuery(string query, DbTransaction trans, params DbParameter[] parameters)
        {
            using (DbCommand command = ConstructQueryCommand(query, trans, parameters))
                command.ExecuteNonQuery();
        }


        /// <summary>
        /// Builds a stored procedure command call and executes it without returning any result set
        /// </summary>
        /// <param name="query">the SQL text query to run</param>
        /// <param name="useTransaction">True if the method should supply its own transaction object</param>
        /// <param name="parameters">a variable number of parameters to pass to the stored procedure.
        /// Null values are ignored.</param>
        protected void ExecuteFromQuery(string query, params DbParameter[] parameters)
        {
            using (DbTransaction trans = this.sql.BeginTransaction())
            {
                try
                {
                    ExecuteFromQuery(query, trans, parameters);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// Cleans up the connection with the database.
        /// </summary>
        public virtual void Dispose()
        {
            if (sql != null)
            {
                if (sql.State == ConnectionState.Open)
                    sql.Close();
                sql.Dispose();
                sql = null;
            }
        }

        /// <summary>
        /// A generic method for executing stored procedures and OR factories to return an OR mapped
        /// result set
        /// </summary>
        /// <typeparam name="T">the OR type to return</typeparam>
        /// <param name="procName">the stored procedure to use</param>
        /// <param name="parameters">a variable number of parameters to pass to the stored procedure.
        /// Null values are ignored.</param>
        /// <returns></returns>
        protected List<T> GetListFromQuery<T>(string query, params DbParameter[] parameters) where T : DataAdapter<T>, new()
        {
            List<T> list = new List<T>();
            using (DbCommand command = ConstructQueryCommand(query, true, parameters))
            {
                using (DbDataAdapter adapter = this.NewDataAdapter(command))
                using (DataSet data = new DataSet())
                {
                    adapter.Fill(data);
                    if (Utility.HasData(data))
                        foreach (DataRow row in data.Tables[0].Rows)
                            list.Add((T)row);
                }
                command.Transaction.Commit();
            }
            return list;
        }
        private TOut SimpleTypeCast<TIn, TOut>(TIn val) where TIn : TOut
        {
            return (TOut)val;
        }
        protected List<TOut> GetListFromQuery<TIn, TOut>(string query, params DbParameter[] parameters) where TIn : DataAdapter<TIn>, TOut, new()
        {
            List<TIn> list = this.GetListFromQuery<TIn>(query, parameters);
            return list.ConvertAll<TOut>(new Converter<TIn, TOut>(SimpleTypeCast<TIn, TOut>));
        }

        /// <summary>
        /// A generic method for executing stored procedures and OR factories to return an OR mapped
        /// object
        /// </summary>
        /// <typeparam name="T">the OR type to return</typeparam>
        /// <param name="procName">the stored procedure to use</param>
        /// <param name="parameters">a variable number of parameters to pass to the stored procedure.
        /// Null values are ignored.</param>
        /// <returns></returns>
        protected T GetOneFromQuery<T>(string query, params DbParameter[] parameters) where T : DataAdapter<T>, new()
        {
            T result = null;
            List<T> list = GetListFromQuery<T>(query, parameters);
            if (list.Count > 0)
                result = list[0];
            return result;
        }

        /// <summary>
        /// Build the necessary tables for the TaskPad project
        /// </summary>
        protected void RebuildTables_New()
        {
            using (DbTransaction trans = this.sql.BeginTransaction())
            {
                try
                {
                    List<string> tables = new List<string>();
                    using (DbCommand cmd = this.NewCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = this.sql;
                        cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
                        using (DataSet ds = new DataSet())
                        {
                            using (DbDataAdapter adp = this.NewDataAdapter(cmd))
                                adp.Fill(ds);
                            if (Utility.HasData(ds))
                                foreach (DataRow row in ds.Tables[0].Rows)
                                    tables.Add(((string)row["TABLE_NAME"]).ToUpper());
                        }
                    }
                    // Create Attachments Table
                    if (!tables.Contains("ATTACHMENTS"))
                        this.ExecuteFromQuery(string.Format(@"CREATE TABLE Attachments(
    AttachmentID int IDENTITY(1,1) NOT NULL, 
    TaskID int NOT NULL, 
    FileName nvarchar(1000) NOT NULL, 
    FileData image NOT NULL,
             CONSTRAINT PK_Attachment PRIMARY KEY (AttachmentID))", short.MaxValue), trans);

                    //Create Comments Table
                    if (!tables.Contains("COMMENTS"))
                        this.ExecuteFromQuery(@"CREATE TABLE Comments(
	CommentID int IDENTITY(1,1) NOT NULL,
	UserName nvarchar(50) NOT NULL,
	TaskID int NOT NULL,
	Text nvarchar(1000) NOT NULL,
	DateCreated datetime NOT NULL CONSTRAINT DF_Comments_DateCreated  DEFAULT (getdate()),
 CONSTRAINT PK_Comments PRIMARY KEY (CommentID))", trans);

                    // Create Tags Table
                    if (!tables.Contains("TAGS"))
                        this.ExecuteFromQuery(@"CREATE TABLE Tags(
	TagID int IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	Description nvarchar(250) NOT NULL,
	IsDefault bit NOT NULL,
 CONSTRAINT PK_Tags PRIMARY KEY (TagID))", trans);

                    //Create TagsOnTasks Join Table
                    if (!tables.Contains("TAGSONTASKS"))
                        this.ExecuteFromQuery(@"CREATE TABLE TagsOnTasks(
	TaskID int NOT NULL,
	TagID int NOT NULL,
	DateTagged datetime NOT NULL CONSTRAINT DF_TagsOnTasks_DateTagged  DEFAULT (getdate()),
 CONSTRAINT PK_TagsOnTasks PRIMARY KEY (TaskID,	TagID))", trans);

                    // Create Table Tasks
                    if (!tables.Contains("TASKS"))
                        this.ExecuteFromQuery(@"CREATE TABLE Tasks(
	TaskID int IDENTITY(1,1) NOT NULL,
	Title nvarchar(50) NOT NULL,
	Description ntext NOT NULL,
	DateCreated datetime NOT NULL CONSTRAINT DF_Tasks_DateCreated  DEFAULT (getdate()),
	DueDate datetime NOT NULL,
	UserCreator nvarchar(50) NOT NULL,
	UserAssigned nvarchar(50) NOT NULL,
	Priority int NOT NULL,
	Progress int NOT NULL,
 CONSTRAINT PK_Tasks PRIMARY KEY(TaskID))", trans);

                    //Create Table Users
                    if (!tables.Contains("USERS"))
                        this.ExecuteFromQuery(@"CREATE TABLE Users(
	UserName nvarchar(50) NOT NULL,
	Password nvarchar(50) NOT NULL,
	Email nvarchar(50) NOT NULL,
 CONSTRAINT PK_Users PRIMARY KEY(UserName))", trans);

                    //Add foreign key contstraints
                    if (!tables.Contains("ATTACHMENTS") || !tables.Contains("TASKS"))
                        this.ExecuteFromQuery("ALTER TABLE Attachments ADD  CONSTRAINT FK_Attachment_Tasks FOREIGN KEY(TaskID) REFERENCES Tasks (TaskID)", trans);

                    if (!tables.Contains("COMMENTS") || !tables.Contains("TASKS"))
                        this.ExecuteFromQuery("ALTER TABLE Comments ADD  CONSTRAINT FK_Comments_Tasks FOREIGN KEY(TaskID) REFERENCES Tasks (TaskID)", trans);

                    if (!tables.Contains("COMMENTS") || !tables.Contains("USERS"))
                        this.ExecuteFromQuery("ALTER TABLE Comments ADD  CONSTRAINT FK_Comments_Users FOREIGN KEY(UserName) REFERENCES Users (UserName)", trans);

                    if (!tables.Contains("TAGSONTASKS") || !tables.Contains("TAGS"))
                        this.ExecuteFromQuery("ALTER TABLE TagsOnTasks ADD  CONSTRAINT FK_TagsOnTasks_Tags FOREIGN KEY(TagID) REFERENCES Tags (TagID)", trans);

                    if (!tables.Contains("TAGSONTASKS") || !tables.Contains("TASKS"))
                        this.ExecuteFromQuery("ALTER TABLE TagsOnTasks ADD  CONSTRAINT FK_TagsOnTasks_Tasks FOREIGN KEY(TaskID) REFERENCES Tasks (TaskID)", trans);

                    if (!tables.Contains("TASKS") || !tables.Contains("USERS"))
                    {
                        this.ExecuteFromQuery("ALTER TABLE Tasks ADD  CONSTRAINT FK_Tasks_Users_Assigned FOREIGN KEY(UserAssigned) REFERENCES Users (UserName)", trans);
                        this.ExecuteFromQuery("ALTER TABLE Tasks ADD  CONSTRAINT FK_Tasks_Users_Creator FOREIGN KEY(UserCreator) REFERENCES Users (UserName)", trans);
                    }

                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
        /// <summary>
        /// Build the necessary tables for the TaskPad project
        /// </summary>
        protected void RebuildTables()
        {
            using (DbTransaction trans = this.sql.BeginTransaction())
            {
                try
                {
                    List<string> tables = new List<string>();
                    using (DbCommand cmd = this.NewCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = this.sql;
                        cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES";
                        using (DataSet ds = new DataSet())
                        {
                            using (DbDataAdapter adp = this.NewDataAdapter(cmd))
                                adp.Fill(ds);
                            if (Utility.HasData(ds))
                                foreach (DataRow row in ds.Tables[0].Rows)
                                    tables.Add(((string)row["TABLE_NAME"]).ToUpper());
                        }
                    }
                    // Create Attachments Table
                    if (!tables.Contains("ATTACHMENTS"))
                        this.ExecuteFromQuery(string.Format(@"CREATE TABLE Attachments(
    AttachmentID int IDENTITY(1,1) NOT NULL, 
    TaskID int NOT NULL, 
    FileName nvarchar(1000) NOT NULL, 
    FileData image NOT NULL,
             CONSTRAINT PK_Attachment PRIMARY KEY (AttachmentID))", short.MaxValue), trans);

                    //Create Comments Table
                    if (!tables.Contains("COMMENTS"))
                        this.ExecuteFromQuery(@"CREATE TABLE Comments(
	CommentID int IDENTITY(1,1) NOT NULL,
	UserID int NOT NULL,
	TaskID int NOT NULL,
	Text nvarchar(1000) NOT NULL,
	DateCreated datetime NOT NULL CONSTRAINT DF_Comments_DateCreated  DEFAULT (getdate()),
 CONSTRAINT PK_Comments PRIMARY KEY (CommentID))", trans);

                    // Create Tags Table
                    if (!tables.Contains("TAGS"))
                        this.ExecuteFromQuery(@"CREATE TABLE Tags(
	TagID int IDENTITY(1,1) NOT NULL,
	Name nvarchar(50) NOT NULL,
	Description nvarchar(250) NOT NULL,
	IsDefault bit NOT NULL,
 CONSTRAINT PK_Tags PRIMARY KEY (TagID))", trans);

                    //Create TagsOnTasks Join Table
                    if (!tables.Contains("TAGSONTASKS"))
                        this.ExecuteFromQuery(@"CREATE TABLE TagsOnTasks(
	TaskID int NOT NULL,
	TagID int NOT NULL,
	DateTagged datetime NOT NULL CONSTRAINT DF_TagsOnTasks_DateTagged  DEFAULT (getdate()),
 CONSTRAINT PK_TagsOnTasks PRIMARY KEY (TaskID,	TagID))", trans);

                    // Create Table Tasks
                    if (!tables.Contains("TASKS"))
                        this.ExecuteFromQuery(@"CREATE TABLE Tasks(
	TaskID int IDENTITY(1,1) NOT NULL,
	Title nvarchar(50) NOT NULL,
	Description ntext NOT NULL,
	DateCreated datetime NOT NULL CONSTRAINT DF_Tasks_DateCreated  DEFAULT (getdate()),
	DueDate datetime NOT NULL,
	UserCreator int NOT NULL,
	UserAssigned int NOT NULL,
	Priority int NOT NULL,
	Progress int NOT NULL,
 CONSTRAINT PK_Tasks PRIMARY KEY(TaskID))", trans);

                    //Create Table Users
                    if (!tables.Contains("USERS"))
                        this.ExecuteFromQuery(@"CREATE TABLE Users(
	UserID int IDENTITY(1,1) NOT NULL,
	UserName nvarchar(50) NOT NULL,
	Password nvarchar(50) NOT NULL,
	Email nvarchar(50) NOT NULL,
 CONSTRAINT PK_Users PRIMARY KEY(UserID))", trans);

                    //Add foreign key contstraints
                    if (!tables.Contains("ATTACHMENTS") || !tables.Contains("TASKS"))
                        this.ExecuteFromQuery("ALTER TABLE Attachments ADD  CONSTRAINT FK_Attachment_Tasks FOREIGN KEY(TaskID) REFERENCES Tasks (TaskID)", trans);

                    if (!tables.Contains("COMMENTS") || !tables.Contains("TASKS"))
                        this.ExecuteFromQuery("ALTER TABLE Comments ADD  CONSTRAINT FK_Comments_Tasks FOREIGN KEY(TaskID) REFERENCES Tasks (TaskID)", trans);

                    if (!tables.Contains("COMMENTS") || !tables.Contains("USERS"))
                        this.ExecuteFromQuery("ALTER TABLE Comments ADD  CONSTRAINT FK_Comments_Users FOREIGN KEY(UserID) REFERENCES Users (UserID)", trans);

                    if (!tables.Contains("TAGSONTASKS") || !tables.Contains("TAGS"))
                        this.ExecuteFromQuery("ALTER TABLE TagsOnTasks ADD  CONSTRAINT FK_TagsOnTasks_Tags FOREIGN KEY(TagID) REFERENCES Tags (TagID)", trans);

                    if (!tables.Contains("TAGSONTASKS") || !tables.Contains("TASKS"))
                        this.ExecuteFromQuery("ALTER TABLE TagsOnTasks ADD  CONSTRAINT FK_TagsOnTasks_Tasks FOREIGN KEY(TaskID) REFERENCES Tasks (TaskID)", trans);

                    if (!tables.Contains("TASKS") || !tables.Contains("USERS"))
                    {
                        this.ExecuteFromQuery("ALTER TABLE Tasks ADD  CONSTRAINT FK_Tasks_Users_Assigned FOREIGN KEY(UserAssigned) REFERENCES Users (UserID)", trans);
                        this.ExecuteFromQuery("ALTER TABLE Tasks ADD  CONSTRAINT FK_Tasks_Users_Creator FOREIGN KEY(UserCreator) REFERENCES Users (UserID)", trans);
                    }

                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }
        public void CreateAttachment(int taskID, string fileName, byte[] fileData)
        {
            this.ExecuteFromQuery(@"INSERT INTO Attachments(TaskID, FileName, FileData) VALUES(@TaskID, @FileName, @FileData)",
                this.NewParameter("@TaskID", taskID),
                this.NewParameter("@FileName", fileName),
                this.NewParameter("@FileData", fileData));
        }

        public void DeleteAttachment(int attachmentID)
        {
            this.ExecuteFromQuery("DELETE FROM Attachments WHERE AttachmentID = @AttachmentID",
                this.NewParameter("@AttachmentID", attachmentID));
        }

        public Attachment GetAttachment(int attachmentID)
        {
            return this.GetOneFromQuery<Attachment>("SELECT * FROM Attachments WHERE AttachmentID = @AttachmentID",
                this.NewParameter("@AttachmentID", attachmentID));
        }

        public void AddComment(int userID, int taskID, string text)
        {
            this.ExecuteFromQuery("INSERT INTO Comments(UserID, TaskID, [Text]) VALUES(@UserID, @TaskID, @Text)",
                this.NewParameter("@UserID", userID),
                this.NewParameter("@TaskID", taskID),
                this.NewParameter("@Text", text));
        }

        public void DeleteComment(int commentID)
        {
            this.ExecuteFromQuery("DELETE FROM Comments WHERE CommentID = @CommentID",
                this.NewParameter("@CommentID", commentID));
        }

        public void CreateTag(string name, string description, bool isDefault)
        {
            this.ExecuteFromQuery("INSERT INTO Tags([Name], [Description], IsDefault) VALUES(@Name, @Description, @IsDefault)",
                this.NewParameter("@Name", name),
                this.NewParameter("@Description", description),
                this.NewParameter("@IsDefault", isDefault));
        }

        public void DeleteTag(int tagID)
        {
            using (DbTransaction trans = this.sql.BeginTransaction())
            {
                try
                {
                    this.ExecuteFromQuery("DELETE FROM TagsOnTasks WHERE TagID = @TagID", trans, this.NewParameter("@TagID", tagID));
                    this.ExecuteFromQuery("DELETE FROM Tags WHERE TagID = @TagID", trans, this.NewParameter("@TagID", tagID));
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public void EditTag(int tagID, string name, string description, bool isDefault)
        {
            this.ExecuteFromQuery(@"UPDATE Tags SET [Name] = @Name, [Description] = @Description, IsDefault = @IsDefault WHERE TagID = @TagID",
                this.NewParameter("@TagID", tagID),
                this.NewParameter("@Name", name),
                this.NewParameter("@Description", description),
                this.NewParameter("@IsDefault", isDefault));
        }

        public List<Tag> GetAllTags()
        {
            return this.GetListFromQuery<Tag>("SELECT *	FROM Tags ORDER BY [Name] ASC");
        }

        public void CreateTask(string title, string description, int userCreator, int userAssigned, int priority, int progress, DateTime dueDate, List<int> tagIDs)
        {
            using (DbTransaction trans = this.sql.BeginTransaction())
            {
                try
                {
                    this.ExecuteFromQuery(@"INSERT INTO Tasks(
		Title,
		[Description],
		UserCreator,
		DueDate,
		UserAssigned,
		Priority,
		Progress)
	VALUES(
		@Title,
		@Description,
		@UserCreator,
		@DueDate,
		@UserAssigned,
		@Priority,
		@Progress)",
                   trans,
                        this.NewParameter("@Title", title),
                        this.NewParameter("@Description", description),
                        this.NewParameter("@UserCreator", userCreator),
                        this.NewParameter("@UserAssigned", userAssigned),
                        this.NewParameter("@Priority", priority),
                        this.NewParameter("@Progress", progress),
                        this.NewParameter("@DueDate", dueDate));

                    int taskID = 0;
                    using (DbCommand cmd = this.ConstructQueryCommand("SELECT @@IDENTITY", trans))
                    {
                        object obj = cmd.ExecuteScalar();
                        taskID = (int)((decimal)obj);
                    }

                    foreach (int tagID in tagIDs)
                        this.AddTagToTask(tagID, taskID, trans);
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public void DeleteTask(int taskID)
        {
            using (DbTransaction trans = this.sql.BeginTransaction())
            {
                try
                {
                    this.ExecuteFromQuery("DELETE FROM Comments WHERE TaskID = @TaskID", trans, this.NewParameter("@TaskID", taskID));
                    this.ExecuteFromQuery("DELETE FROM TagsOnTasks WHERE TaskID = @TaskID", trans, this.NewParameter("@TaskID", taskID));
                    this.ExecuteFromQuery("DELETE FROM Attachments WHERE TaskID = @TaskID", trans, this.NewParameter("@TaskID", taskID));
                    this.ExecuteFromQuery("DELETE FROM Tasks WHERE TaskID = @TaskID", trans, this.NewParameter("@TaskID", taskID));
                    trans.Commit();
                }
                catch (Exception)
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public void EditTask(int taskID, string title, string description, int userAssigned, int priority, int progress, DateTime dueDate)
        {
            this.ExecuteFromQuery(@"UPDATE Tasks 
SET 
    Title = @Title, 
    [Description] = @Description,
    UserAssigned = @UserAssigned,
    DueDate = @DueDate,
    Priority = @Priority,
    Progress = @Progress 
WHERE TaskID = @TaskID",
                this.NewParameter("@TaskID", taskID),
                this.NewParameter("@Title", title),
                this.NewParameter("@Description", description),
                this.NewParameter("@UserAssigned", userAssigned),
                this.NewParameter("@Priority", priority),
                this.NewParameter("@Progress", progress),
                this.NewParameter("@DueDate", dueDate));
        }

        public List<Comment> GetCommentsOnTask(int taskID)
        {
            return this.GetListFromQuery<Comment>(@"SELECT * FROM Comments WHERE TaskID = @TaskID ORDER BY DateCreated ASC",
                this.NewParameter("@TaskID", taskID));
        }

        public List<Tag> GetTagsOnTask(int taskID)
        {
            return this.GetListFromQuery<Tag>(@"SELECT * FROM Tags a JOIN TagsOnTasks b	ON a.TagID = b.TagID WHERE b.TaskID = @TaskID",
                this.NewParameter("@TaskID", taskID));
        }

        public Task GetTask(int taskID)
        {
            return this.GetOneFromQuery<Task>("SELECT * FROM Tasks WHERE TaskID = @TaskID",
                this.NewParameter("@TaskID", taskID));
        }

        public List<Task> FindTasks(List<int> tagIDs, int userAssignedID, DateTime dueDate)
        {
            List<Task> result = new List<Task>();
            using (DbCommand sqlCmd = this.NewCommand())
            {
                sqlCmd.Connection = sql;
                sqlCmd.CommandType = CommandType.Text;

                StringBuilder query = new StringBuilder();
                query.AppendLine("SELECT * FROM Tasks");
                string conjunction = "WHERE";
                if (tagIDs.Count > 0)
                {
                    List<int> taskIDs = new List<int>();
                    bool first = true;
                    foreach (int tagID in tagIDs)
                    {
                        sqlCmd.CommandText = string.Format("SELECT TaskID FROM TagsOnTasks WHERE TagID = {0}", tagID);
                        using (DbDataAdapter adapter = this.NewDataAdapter(sqlCmd))
                        using (DataSet output = new DataSet())
                        {
                            adapter.Fill(output);
                            if (first)
                            {
                                foreach (DataRow row in output.Tables[0].Rows)
                                    taskIDs.Add((int)row[0]);
                                first = false;
                            }
                            else
                            {
                                List<int> temp = new List<int>();
                                foreach (DataRow row in output.Tables[0].Rows)
                                    temp.Add((int)row[0]);
                                for (int index = taskIDs.Count - 1; index >= 0; --index)
                                    if (!temp.Contains(taskIDs[index]))
                                        taskIDs.RemoveAt(index);
                            }
                        }
                    }
                    if (taskIDs.Count > 0)
                    {
                        query.Append(string.Format("{0} TaskID IN (", conjunction));
                        for (int index = 0; index < taskIDs.Count; ++index)
                        {
                            query.Append(taskIDs[index]);
                            if (index < taskIDs.Count - 1)
                                query.Append(", ");
                        }
                        query.AppendLine(")");
                        conjunction = "AND";
                    }
                }
                if (userAssignedID > 0)
                {
                    query.AppendLine(string.Format("{0} UserAssigned = {1}", conjunction, userAssignedID));
                    conjunction = "AND";
                }
                query.AppendLine(string.Format("{0} DateCreated < '{1}'", conjunction, dueDate));
                conjunction = "AND";
                query.AppendLine("ORDER BY DateCreated DESC");

                sqlCmd.CommandText = query.ToString();
                using (DbDataAdapter adapter = this.NewDataAdapter(sqlCmd))
                using (DataSet output = new DataSet())
                {
                    adapter.Fill(output);
                    foreach (DataRow row in output.Tables[0].Rows)
                        result.Add((Task)row);
                }
            }
            return result;
        }

        public void AddTagToTask(int tagID, int taskID)
        {
            this.ExecuteFromQuery("INSERT INTO TagsOnTasks(TagID, TaskID) VALUES(@TagID, @TaskID)",
                this.NewParameter("@TagID", tagID),
                this.NewParameter("@TaskID", taskID));
        }


        private void AddTagToTask(int tagID, int taskID, DbTransaction trans)
        {
            this.ExecuteFromQuery("INSERT INTO TagsOnTasks(TagID, TaskID) VALUES(@TagID, @TaskID)",
                trans,
                this.NewParameter("@TagID", tagID),
                this.NewParameter("@TaskID", taskID));
        }

        public void RemoveTagFromTask(int tagID, int taskID)
        {
            this.ExecuteFromQuery(@"DELETE FROM TagsOnTasks WHERE TagID = @TagID AND TaskID = @TaskID",
                this.NewParameter("@TagID", tagID),
                this.NewParameter("@TaskID", taskID));
        }

        public List<AttachmentReference> GetAttachmentsOnTask(int taskID)
        {
            return this.GetListFromQuery<AttachmentReference, AttachmentReference>("SELECT AttachmentID, TaskID, FileName FROM Attachments WHERE TaskID = @TaskID",
                this.NewParameter("@TaskID", taskID));
        }

        public void CreateUser(string username, string password, string email)
        {
            this.ExecuteFromQuery(@"INSERT INTO Users(UserName, Password, Email) VALUES(@UserName, @Password, @Email)",
                this.NewParameter("@UserName", username),
                this.NewParameter("@Password", password),
                this.NewParameter("@Email", email));
        }

        public void EditUser(int userID, string password, string email)
        {
            this.ExecuteFromQuery(@"UPDATE Users SET [Password] = @Password, Email = @Email WHERE UserID = @UserID",
                this.NewParameter("@UserID", userID),
                this.NewParameter("@Password", password),
                this.NewParameter("@Email", email));
        }

        public User GetUser(int userID)
        {
            return this.GetOneFromQuery<User>("SELECT * FROM Users WHERE UserID = @UserID", this.NewParameter("@UserID", userID));
        }

        public List<User> GetAllUsers()
        {
            return this.GetListFromQuery<User>("SELECT * FROM Users");
        }

        public virtual int CheckUser(string userName, string password)
        {
            List<User> users = this.GetListFromQuery<User>("SELECT * FROM Users WHERE UserName = @UserName AND Password = @Password",
                this.NewParameter("@UserName", userName),
                this.NewParameter("@Password", password));
            if (users.Count == 1)
                return users[0].UserID;
            return 0;
        }
    }
}