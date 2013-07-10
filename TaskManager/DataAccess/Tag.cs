using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TaskManager.DataAccess
{
    public class Tag : DataAdapter<Tag>
    {
        public int tagID;
        public string name;
        public string description;
        public bool isDefault;

        public int TagID { get { return tagID; } }
        public string Name { get { return name; } }
        public string Description { get { return description; } }
        public bool IsDefault { get { return isDefault; } }

        public override string ToString()
        {
            return name;
        }
    }
}
