using System;
using Xunit;
using STINServer;
using System.Xml;
using System.IO;
using System.ServiceModel.Channels;

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
            string URLString = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
            Assert.Matches(".*[0-9.]+.*", string.Format("{0}", WCFService.GetCurrentRateStatic(URLString)));
            Assert.DoesNotMatch(".*[0-9.]+.*", string.Format("{0}", WCFService.GetCurrentRateStatic(URLString + "2")));
        }

        [Fact]
        public void test3()
        {
            DateTime time = DateTime.Parse("12:00:00");
            TimeSpan offset = TimeSpan.FromHours(2.0);
            Assert.Matches(".*14:00:00.*", WCFService.GetCurrentTimeStatic(offset, time));
            Assert.DoesNotMatch(".*12:50:00.*", WCFService.GetCurrentTimeStatic(offset, time));
            Assert.Matches(".*[0-9]+:[0-9]+:[0-9]+.*", WCFService.GetCurrentTimeStatic(offset));
        }

        [Fact]
        public void test4()
        {
            RemoteEndpointMessageProperty endpointProperty = new RemoteEndpointMessageProperty("25.25.25.25", 5858);
            Assert.Matches(".*25.25.25.25.*", WCFService.GetUserIDStatic(endpointProperty));

        }
    }
}
