using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace STINClient
{
    class Wrapper
    {
        public static string Wrap(string val)
        {
            var xDocument = new XDocument(
            new XDocumentType("html", null, null, null),
            new XElement("html",
                new XElement("head"),
                new XElement("body",
                    new XElement("p", val)
                    )
                )
            );
            return xDocument.ToString();
        }
    }
}