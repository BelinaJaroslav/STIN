using System;
using Xunit;
using STINServer;
using System.Xml;
using System.IO;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string testString = "<?xml version = \"1.0\" encoding = \"UTF-8\" ?>\n" +
                                "<Cube time=\"2022 - 05 - 02\">\n" +
                                "<Cube currency = \"USD\" rate = \"1.0524\"/>\n" +
                                "<Cube currency = \"CZK\" rate = \"24.671\" />\n" +
                                "<Cube currency = \"DKK\" rate = \"7.4391\" />\n" +
                                "</Cube>";
                                

            XmlReader xmlReader = XmlReader.Create(new StringReader(testString));
            Assert.Equal("24.671", WCFService.ExtractRate(xmlReader));
        }

        [Fact]
        public void Test2()
        { 
            Assert.Matches(".*[0-9.]+.*",string.Format("{0}", WCFService.GetCurrentRateStatic()));
        }

    }
}
