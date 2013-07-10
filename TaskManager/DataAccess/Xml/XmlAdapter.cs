using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace TaskManager.DataAccess.Xml
{
    public class XmlAdapter : DataAdapter
    {
        XmlDocumentAlterer document;
        public XmlAdapter(XmlDocument document)
            : base()
        {
            this.document = new XmlDocumentAlterer(document);
        }

        public override void Dispose()
        {
            //nothing
        }
    }
}
