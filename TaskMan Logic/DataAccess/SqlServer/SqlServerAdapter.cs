using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace TaskManager.DataAccess.SqlServer
{
    public class SqlServerAdapter : InfoAdapter
    {
        SqlConnection sqlConnection;
        public SqlServerAdapter(string connectionString)
            : base()
        {
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            commentAdapter = new CommentAdapter(sqlConnection);
            tagAdapter = new TagAdapter(sqlConnection);
            taskAdapter = new TaskAdapter(sqlConnection);
            userAdapter = new UserAdapter(sqlConnection);
            attachmentAdapter = new AttachmentAdapter(sqlConnection);
        }

        public override void Dispose()
        {
            if (sqlConnection != null)
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }
    }
}
