using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TaskManager.DataAccess.SqlServer
{
    public class Tag : DataAdapter<Tag>, ITag
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
    public class TagAdapter : DataAccess, ITagAdapter
    {
        public TagAdapter(SqlConnection sqlConnection)
            : base(sqlConnection)
        {
        }

        public int Create(string name, string description, bool isDefault)
        {
            return this.Execute<int>("Tag_Create", SqlDbType.Int,
                new SqlParameter("@Name", name),
                new SqlParameter("@Description", description),
                new SqlParameter("@IsDefault", isDefault));
        }

        public void Delete(int tagID)
        {
            this.Execute("Tag_Delete", new SqlParameter("@TagID", tagID));
        }

        public void Edit(int tagID, string name, string description, bool isDefault)
        {
            this.Execute("Tag_Edit", 
                new SqlParameter("@TagID", tagID),
                new SqlParameter("@Name", name),
                new SqlParameter("@Description", description),
                new SqlParameter("@IsDefault", isDefault));
        }
        public List<ITag> GetAll()
        {
            return this.GetList<Tag, ITag>("Tag_GetAll");
        }
    }
}
