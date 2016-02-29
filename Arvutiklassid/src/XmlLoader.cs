using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Arvutiklassid.src
{
    class XmlLoader
    {
        public static XDocument SafeLoadXDocument(string xmlDocumentPath, string xsdSchemaPath)
        {
            XDocument xDocument = XDocument.Load(xmlDocumentPath);

            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", xsdSchemaPath);


            xDocument.Validate(schemas, (o, e) =>
                {
                    throw new Exception(e.Message);
                }
            );

            return xDocument;
        }
    }
}
