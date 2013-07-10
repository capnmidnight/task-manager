using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TaskManager.BusinessLogic;

namespace TaskManager.DataAccess.SqlServer
{
    /// <summary>
    /// A class for building an object relational mapping with the database
    /// </summary>
    public abstract class DataAccess : IDisposable
    {
        protected SqlConnection sql;

        /// <summary>
        /// creates and opens a connection to the database specified by the connectionString parameter
        /// </summary>
        /// <param name="connectionString">a SQL Server connection string</param>
        public DataAccess(string connectionString)
            : this(new SqlConnection(connectionString))
        {
        }

        public DataAccess(SqlConnection sql)
        {
            this.sql = sql;
            if (this.sql.State == ConnectionState.Closed)
                this.sql.Open();
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
        /// Creates a stored procedure command call from a variable array of parameters
        /// </summary>
        /// <param name="procName">the stored procedure to use</param>
        /// <param name="parameters">a variable number of parameters to pass to the stored procedure.
        /// Null values are ignored.</param>
        /// <returns>a SqlCommand structure for encapsulating a stored procedure call</returns>
        protected SqlCommand ConstructCommand(string procName, params SqlParameter[] parameters)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = sql;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            if (parameters != null)
                foreach (SqlParameter parameter in parameters)
                    if (parameter.Value != null)
                        command.Parameters.Add(parameter);
            return command;
        }

        /// <summary>
        /// Builds a stored procedure command call and executes it without returning any result set
        /// </summary>
        /// <param name="procName">the stored procedure to use</param>
        /// <param name="parameters">a variable number of parameters to pass to the stored procedure.
        /// Null values are ignored.</param>
        protected void Execute(string procName, params SqlParameter[] parameters)
        {
            using (SqlCommand command = ConstructCommand(procName, parameters))
                command.ExecuteNonQuery();
        }

        protected T Execute<T>(string procName, SqlDbType type, params SqlParameter[] parameters)
        {
            T val = default(T);
            using (SqlCommand command = ConstructCommand(procName, parameters))
            {
                SqlParameter retVal = new SqlParameter("@RETURN_VALUE", type);
                retVal.Direction = ParameterDirection.ReturnValue;
                command.Parameters.Add(retVal);
                command.ExecuteNonQuery();
                val = (T)retVal.Value;
            }
            return val;
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
        protected List<T> GetList<T>(string procName, params SqlParameter[] parameters) where T : DataAdapter<T>, new()
        {
            List<T> list = new List<T>();
            using (SqlCommand command = ConstructCommand(procName, parameters))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    using (DataSet data = new DataSet())
                    {
                        adapter.Fill(data);
                        if (Utility.HasData(data))
                            foreach (DataRow row in data.Tables[0].Rows)
                                list.Add((T)row);
                    }
                }
            }
            return list;
        }
        private TOut SimpleTypeCast<TIn, TOut>(TIn val) where TIn : TOut
        {
            return (TOut)val;
        }
        protected List<TOut> GetList<TIn, TOut>(string procName, params SqlParameter[] parameters) where TIn : DataAdapter<TIn>, TOut, new()
        {
            List<TIn> list = this.GetList<TIn>(procName, parameters);
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
        protected T GetOne<T>(string procName, params SqlParameter[] parameters) where T : DataAdapter<T>, new()
        {
            T result = null;
            List<T> list = GetList<T>(procName, parameters);
            if (list.Count > 0)
                result = list[0];
            return result;
        }

        protected TOut GetOne<TIn, TOut>(string procName, params SqlParameter[] parameters) where TIn : DataAdapter<TIn>, TOut, new()
        {
            return (TOut)this.GetOne<TIn>(procName, parameters);
        }

    }
}
