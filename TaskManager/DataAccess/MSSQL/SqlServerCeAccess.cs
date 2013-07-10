using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlServerCe;
using System.IO;
using System.Text;


namespace TaskManager.DataAccess.MSSQL
{
    public class SqlServerCeAccess : MSSQLCommandProcessor
    {
        
        public SqlServerCeAccess(string fileName)
        {
            string connectionString = string.Format("Data Source='{0}'; LCID=1033; Password='Lyks09tliCmjz'; Encrypt=TRUE; Mode=Exclusive", fileName);
            string fullPath = Path.GetFullPath(fileName);
            if (!File.Exists(fullPath))
            {
                using (SqlCeEngine engine = new SqlCeEngine(connectionString))
                    engine.CreateDatabase();
                this.sql = new SqlCeConnection(connectionString);
            }
            else
            {
                this.sql = new SqlCeConnection(connectionString);
            }
            if (this.sql.State == ConnectionState.Closed)
                this.sql.Open();
            this.RebuildTables();
        }

        protected override DbCommand NewCommand()
        {
            SqlCeCommand com = new SqlCeCommand();
            com.Disposed += new EventHandler(com_Disposed);
            return com;
        }

        void com_Disposed(object sender, EventArgs e)
        {
            Console.Write("Yeah!");
        }

        protected override DbDataAdapter NewDataAdapter(DbCommand command)
        {
            if (command is SqlCeCommand)
                return new SqlCeDataAdapter((SqlCeCommand)command);
            else
                throw new ArgumentException("Command provided was not of the right DB system type");
        }

        protected override DbParameter NewParameter(string name, SqlDbType type)
        {
            return new SqlCeParameter(name, type);
        }

        protected override DbParameter NewParameter(string name, object value)
        {
            return new SqlCeParameter(name, value);
        }

        private bool IsUserNameAvailable(string userName)
        {
            return this.GetListFromQuery<User>("SELECT * FROM Users WHERE UserName = @UserName",
                this.NewParameter("@UserName", userName)).Count == 0;
        }

        public override int CheckUser(string userName, string password)
        {
            int userID = base.CheckUser(userName, password);
            if (userID == 0 && this.IsUserNameAvailable(userName))
            {
                this.CreateUser(userName, password, "");
                userID = base.CheckUser(userName, password);
            }
            return userID;
        }
    }
}