using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TaskManager.DataAccess
{
    /// <summary>
    /// A simple structure for encapsulating tag data
    /// </summary>
    public interface ITag
    {
        int TagID { get;}
        string Name { get;}
        string Description { get;}
        bool IsDefault { get;}
    }

    public interface ITagAdapter
    {
        List<ITag> GetAll();
        int Create(string name, string description, bool isDefault);
        void Delete(int tagID);
        void Edit(int tagID, string name, string description, bool isDefault);
    }
}
