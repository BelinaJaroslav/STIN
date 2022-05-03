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
            string testString = "<Cube time=\"2022 - 05 - 02\">" +
                                "<Cube currency = \"USD\" rate = \"1.0524\"" +
                                "<Cube currency = \"CZK\" rate = \"24.671\" />" +
                                "<Cube currency = \"DKK\" rate = \"7.4391\" />";

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
