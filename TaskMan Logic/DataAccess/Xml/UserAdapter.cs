using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TaskManager.DataAccess.Xml
{
    public class UserAdapter : IUserAdapter
    {
        XmlDocumentAlterer document;
        List<Exception> errors;
        public UserAdapter(XmlDocumentAlterer document, List<Exception> errors)
        {
            this.document = document;
            this.errors = errors;
        }


        public static User CreateUser(XmlNode node)
        {
            User user = new User();
            int.TryParse(node.Attributes["UserID"].Value, out user.userID);
            user.userName = node.Attributes["UserName"].Value;
            user.password = node.Attributes["Password"].Value;
            user.email = node.Attributes["Email"].Value;
            return user;
        }

        public int Create(string username, string password, string email)
        {
            int newUserID = BusinessLogic.Utility.NextID();
            this.document.SetValue(string.Format("/TaskManager/Users/User[@UserID={0}]/@UserName", newUserID), username.ToLower());
            this.document.SetValue(string.Format("/TaskManager/Users/User[@UserID={0}]/@Password", newUserID), password);
            this.document.SetValue(string.Format("/TaskManager/Users/User[@UserID={0}]/@Email", newUserID), email);
            return newUserID;
        }

        public void Edit(User user)
        {
            this.document.SetValue(string.Format("/TaskManager/Users/User[@UserID={0}]/@Password", user.userID), user.password);
            this.document.SetValue(string.Format("/TaskManager/Users/User[@UserID={0}]/@Email", user.userID), user.email);
        }

        public User Get(int userID)
        {
            User result = null;
            try
            {
                XmlNodeList nodes = this.document.SelectNodes(new Expression(
                        string.Format("/TaskManager/Users/User[@UserID={0}]", userID)));
                if (nodes.Count == 1)
                    result = UserAdapter.CreateUser(nodes[0]);
            }
            catch (Exception exp)
            {
                this.errors.Add(exp);
            }
            return result;
        }

        public List<User> GetAll()
        {
            List<User> result = null;
            try
            {
                result = new List<User>();
                foreach (XmlNode node in this.document.SelectNodes(new Expression("/TaskManager/Users/User")))
                    result.Add(UserAdapter.CreateUser(node));
            }
            catch (Exception exp)
            {
                this.errors.Add(exp);
            }
            return result;
        }

        public int Check(string userName, string password)
        {
            int userID = -1;
            try
            {
                XmlNodeList nodes = this.document.SelectNodes(new Expression(string.Format("/TaskManager/Users/User[@UserName='{0}']", userName.ToLower())));
                if (nodes.Count == 1 && nodes[0].Attributes["Password"].Value == password)
                    int.TryParse(nodes[0].Attributes["UserID"].Value, out userID);
            }
            catch (Exception exp)
            {
                this.errors.Add(exp);
            }
            return userID;
        }
    }
}
