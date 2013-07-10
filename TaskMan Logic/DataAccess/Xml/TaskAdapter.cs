using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TaskManager.DataAccess.Xml
{
    public class TaskAdapter : ITaskAdapter
    {
        XmlDocumentAlterer document;
        List<Exception> errors;
        public TaskAdapter(XmlDocumentAlterer document, List<Exception> errors)
        {
            this.document = document;
            this.errors = errors;
        }

        public static Task CreateTask(XmlNode node)
        {
            Task task = new Task();
            int.TryParse(node.Attributes["TaskID"].Value, out task.taskID);
            task.title = node.Attributes["Title"].Value;
            task.description = node.Attributes["Description"].Value;
            DateTime.TryParse(node.Attributes["DateCreated"].Value, out task.dateCreated);
            int.TryParse(node.Attributes["UserCreator"].Value, out task.userCreator);
            int.TryParse(node.Attributes["UserAssigned"].Value, out task.userAssigned);
            int.TryParse(node.Attributes["Priority"].Value, out task.priority);
            int.TryParse(node.Attributes["Progress"].Value, out task.progress);
            return task;
        }

        public int Create(string title, string description, int userCreator, int userAssigned, int priority, int progress, DateTime dueDate)
        {
            int taskID = BusinessLogic.Utility.NextID();
            string baseExp = string.Format("/TaskManager/Tasks/Task[@TaskID={0}]/", taskID);
            this.document.SetValue(baseExp + "Title", title);
            this.document.SetValue(baseExp + "Description", description);
            this.document.SetValue(baseExp + "UserCreator", userCreator.ToString());
            this.document.SetValue(baseExp + "UserAssigned", userAssigned.ToString());
            this.document.SetValue(baseExp + "Priority", priority.ToString());
            this.document.SetValue(baseExp + "Progress", progress.ToString());
            this.document.SetValue(baseExp + "DueDate", dueDate.ToString());
            return taskID;
        }

        public void Delete(int taskID)
        {
            try
            {
                this.document.Document.SelectSingleNode("/TaskManager/Tasks").RemoveChild(
                    this.document.Document.SelectSingleNode(
                        string.Format("/TaskManager/Tasks/Task[@TaskID={0}]", taskID)));
            }
            catch (Exception exp)
            {
                this.errors.Add(exp);
            }
        }

        public void Edit(Task task)
        {
            string baseExp = string.Format("/TaskManager/Tasks/Task[@TaskID={0}]/", task.taskID);
            this.document.SetValue(baseExp + "Title", task.title);
            this.document.SetValue(baseExp + "Description", task.description);
            this.document.SetValue(baseExp + "UserAssigned", task.userAssigned.ToString());
            this.document.SetValue(baseExp + "Priority", task.priority.ToString());
            this.document.SetValue(baseExp + "Progress", task.progress.ToString());
            this.document.SetValue(baseExp + "DueDate", task.dueDate.ToString());
        }

        public List<Comment> GetComments(int taskID)
        {
            List<Comment> result = new List<Comment>();
            try
            {
                foreach (XmlNode node in this.document.SelectNodes(new Expression(
                    string.Format("/TaskManager/Comments/Comment[@TaskID={0}]", taskID))))
                    result.Add(CommentAdapter.CreateComment(node));
            }
            catch (Exception exp)
            {
                this.errors.Add(exp);
            }
            return result;
        }

        public List<Tag> GetTags(int taskID)
        {
            List<Tag> result = new List<Tag>();
            try
            {
                foreach (XmlNode node in this.document.SelectNodes(new Expression(
                    string.Format("/TaskManager/TagsOnTasks/TagOnTask[@TaskID={0}]", taskID))))
                    result.Add(TagAdapter.CreateTag(
                        this.document.Document.SelectSingleNode(
                        string.Format("/TaskManager/Tags/Tag[@TagID={0}]", node.Attributes["TagID"].Value))));
            }
            catch (Exception exp)
            {
                this.errors.Add(exp);
            }
            return result;
        }

        public Task Get(int taskID)
        {
            Task result = null;
            try
            {
                result = TaskAdapter.CreateTask(
                    this.document.Document.SelectSingleNode(
                        string.Format("/TaskManager/Tasks/Task[@TaskID={0}]", taskID)));
            }
            catch (Exception exp)
            {
                this.errors.Add(exp);
            }
            return result;
        }

        public List<Task> Find(List<int> tagIDs, int userAssignedID, DateTime dueDate)
        {
            List<Task> result = new List<Task>();
            try
            {
                foreach (XmlNode node in this.document.SelectNodes(new Expression("/TaskManager/Tasks/Task")))
                {
                    bool hasAll = true;
                    foreach (int tagID in tagIDs)
                        if (this.document.SelectNodes(new Expression(string.Format("/TaskManager/TagsOnTasks/TagOnTask[@TagID={0}, @TaskID={1}", tagID, node.Attributes["TaskID"].Value))).Count == 0)
                            hasAll = false;
                    if (hasAll
                        && (userAssignedID == 0
                        || node.Attributes["UserAssignedID"].Value.Equals(
                        userAssignedID.ToString())))
                        result.Add(TaskAdapter.CreateTask(node));
                }
            }
            catch (Exception exp)
            {
                this.errors.Add(exp);
            }
            return result;
        }
        public void AddTag(int tagID, int taskID)
        {
            Expression xpath = new Expression(string.Format("/TaskManager/TagsOnTasks/TagOnTask[@TagID={0}, @TaskID={1}]", tagID, taskID));
            if (this.document.CountNodes(xpath) == 0)
                this.document.FillIn(xpath);
        }

        public void RemoveTag(int tagID, int taskID)
        {
            try
            {
                this.document.Document.SelectSingleNode("/TaskManager/TagsOnTasks").RemoveChild(
                    this.document.Document.SelectSingleNode(
                    string.Format("/TaskManager/TagsOnTasks/TagOnTask[@TagID={0}, @TaskID={1}]", tagID, taskID)));
            }
            catch (Exception exp)
            {
                this.errors.Add(exp);
            }
        }
    }
}
