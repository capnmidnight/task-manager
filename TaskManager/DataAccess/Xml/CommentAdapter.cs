using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TaskManager.DataAccess.Xml
{
    public class CommentAdapter : ICommentAdapter
    {
        XmlDocument document;
        List<Exception> errors;
        public CommentAdapter(XmlDocument document, List<Exception> errors)
        {
            this.document = document;
            this.errors = errors;
        }

        
        public static Comment CreateComment(XmlNode node)
        {
            Comment comment = new Comment();
            int.TryParse(node.Attributes["CommentID"].Value, out comment.commentID);
            int.TryParse(node.Attributes["UserID"].Value, out comment.userID);
            int.TryParse(node.Attributes["TaskID"].Value, out comment.taskID);
            comment.text = node.Attributes["Text"].Value;
            DateTime.TryParse(node.Attributes["DateCreated"].Value, out comment.dateCreated);
            return comment;
        }

        public void Add(int userID, int taskID, string text)
        {
            try
            {
                XmlNode node = this.document.CreateElement("Comment");
                node.Attributes["UserID"].Value = userID.ToString();
                node.Attributes["TaskID"].Value = taskID.ToString();
                node.InnerText = text;
                this.document.SelectSingleNode("/TaskManager/Comments").AppendChild(node);
            }
            catch (Exception exp)
            {
                this.errors.Add(exp);
            }
        }

        public void Delete(int commentID)
        {
            try
            {
                this.document.SelectSingleNode("/TaskManager/Comments").RemoveChild(
                    this.document.SelectSingleNode(
                    string.Format("/TaskManager/Comments/Comment[@CommentID={0}]", commentID)));
            }
            catch (Exception exp)
            {
                this.errors.Add(exp);
            }
        }
    }
}
