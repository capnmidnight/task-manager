using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace TaskManager.DataAccess
{
    /// <summary>
    /// By instantiating with the default constructor, the
    /// new object becomes a factory for Object Relational
    /// mapped objects. By calling the Load(DataRow) method,
    /// the columns from the data table that match the field
    /// names from the concrete class automatically get copied.
    /// </summary>
    public abstract class DataAdapter<T> where T : DataAdapter<T>, new()
    {
        /// <summary>
        /// convert a SQL Server DataRow into an OR mapped object
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static explicit operator DataAdapter<T>(DataRow row)
        {
            T inst = default(T);
            if (row != null)
            {
                FieldInfo[] fields = typeof(T).GetFields();
                inst = new T();
                foreach (FieldInfo field in fields)
                    if (row.Table.Columns.Contains(field.Name))
                        field.SetValue(inst, row[field.Name]);
            }
            return inst;
        }
    }
}
