using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;


namespace TaskManager.DataAccess.MSSQL
{
    public class SqlServerAccess : MSSQLCommandProcessor
    {
        public SqlServerAccess(string connectionString)
        {
            this.sql = new SqlConnection(connectionString);
            if (this.sql.State == ConnectionState.Closed)
                this.sql.Open();
        }

        protected override DbCommand NewCommand()
        {
            return new SqlCommand();
        }

        protected override DbDataAdapter NewDataAdapter(DbCommand command)
        {
            if (command is SqlCommand)
                return new SqlDataAdapter((SqlCommand)command);
            else
                throw new ArgumentException("Command provided was not of the right DB system type");
        }

        protected override DbParameter NewParameter(string name, SqlDbType type)
        {
            return new SqlParameter(name, type);
        }

        protected override DbParameter NewParameter(string name, object value)
        {
            return new SqlParameter(name, value);
        }
    }
}