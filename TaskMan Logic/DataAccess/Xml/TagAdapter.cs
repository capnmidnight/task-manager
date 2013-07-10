using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TaskManager.DataAccess.Xml
{
    public class TagAdapter : ITagAdapter
    {
        XmlDocumentAlterer document;
        List<Exception> errors;
        public TagAdapter(XmlDocumentAlterer document, List<Exception> errors)
        {
            this.document = document;
            this.errors = errors;
        }


        public static Tag CreateTag(XmlNode node)
        {
            Tag tag = new Tag();
            int.TryParse(node.Attributes["TagID"].Value, out tag.tagID);
            tag.name = node.Attributes["Name"].Value;
            tag.description = node.Attributes["Description"].Value;
            tag.isDefault = node.Attributes["IsDefault"].Value.ToLower().Equals("true");
            return tag;
        }

        public int Create(string name, string description, bool isDefault)
        {
            int tagID = BusinessLogic.Utility.NextID();
            this.Edit(tagID, name, description, isDefault);
            return tagID;
        }
        public void Delete(int tagID)
        {
            try
            {
                this.document.Document.SelectSingleNode("/TaskManager/Tags").RemoveChild(
                    this.document.Document.SelectSingleNode(
                    string.Format("/TaskManager/Tags/Tag[@TagID={0}]", tagID)));
            }
            catch (Exception exp)
            {
                this.errors.Add(exp);
            }
        }
        public void Edit(Tag tag)
        {
            string baseExp = string.Format("/TaskManager/Tags/Tag[@TagID={0}]/", tag.tagID);
            this.document.SetValue(baseExp + "@Name", tag.name);
            this.document.SetValue(baseExp + "@Description", tag.description);
            this.document.SetValue(baseExp + "@IsDefault", tag.isDefault.ToString());
        }
        public List<Tag> GetAll()
        {
            List<Tag> result = null;
            try
            {
                result = new List<Tag>();
                foreach (XmlNode node in this.document.SelectNodes(new Expression("/TaskManager/Tags/Tag")))
                    result.Add(TagAdapter.CreateTag(node));
            }
            catch (Exception exp)
            {
                this.errors.Add(exp);
            }

            return result;
        }
    }
}
