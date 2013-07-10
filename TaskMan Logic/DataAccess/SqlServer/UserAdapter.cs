using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TaskManager.DataAccess.SqlServer
{
    public class User : DataAdapter<User>, IUser
    {
        public int userID;
        public string userName;
        public string password;
        public string email;

        public int UserID { get { return userID; } }
        public string UserName { get { return userName; } }
        public string Password { get { return password; } }
        public string Email { get { return email; } }

        public override string ToString()
        {
            return userName;
        }
    }
    public class UserAdapter : DataAccess, IUserAdapter
    {
        public UserAdapter(SqlConnection sqlConnection)
            : base(sqlConnection)
        {
        }

        public int Create(string username, string password, string email)
        {
            return this.Execute<int>("User_Create", SqlDbType.Int,
                new SqlParameter("@UserName", username),
                new SqlParameter("@Password", password),
                new SqlParameter("@Email", email));
        }

        public void Edit(int userID, string password, string email)
        {
            this.Execute("User_Edit",
                new SqlParameter("@UserID", userID),
                new SqlParameter("@Password", password),
                new SqlParameter("@Email", email));
        }

        public IUser Get(int userID)
        {
            return this.GetOne<User, IUser>("User_Get", new SqlParameter("@UserID", userID));
        }

        public List<IUser> GetAll()
        {
            return this.GetList<User, IUser>("User_GetAll");
        }

        public int Check(string userName, string password)
        {
            return this.Execute<int>("User_Check", SqlDbType.Int,
                new SqlParameter("@UserName", userName),
                new SqlParameter("@Password", password));
        }
    }
}
