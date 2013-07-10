using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TaskManager.DataAccess
{
    public class User : DataAdapter<User>
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
}
