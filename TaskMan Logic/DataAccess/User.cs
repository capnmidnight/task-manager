using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TaskManager.DataAccess
{
    /// <summary>
    /// A simple structure for encapsulating user data
    /// </summary>
    public interface IUser
    {
        int UserID { get;}
        string UserName { get;}
        string Password { get;}
        string Email { get;}
    }

    public interface IUserAdapter
    {
        void Edit(int userID, string password, string email);
        int Create(string username, string password, string email);
        IUser Get(int userID);
        List<IUser> GetAll();
        int Check(string userName, string password);
    }
}
