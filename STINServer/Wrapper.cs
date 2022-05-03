using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace STINServer
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
                    new XElement("p",
                        "This paragraph contains ", new XElement("b", "bold"), " text."
                    ),
                    new XElement("p",
                        "This paragraph has just plain text."
                        )
                    )
                )
            );
            return xDocument.ToString();
        }


        public static string Wrap(Exception val)
        {
            throw new NotImplementedException();
        }


    }
}