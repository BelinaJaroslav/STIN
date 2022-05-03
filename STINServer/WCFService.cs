using STINInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace STINServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class WCFService : IWCFService
    {
        public HtmlDocument GetCurrentRate()
        {
            return GetCurrentRateStatic();
        }
        

        public static HtmlDocument GetCurrentRateStatic()
        {
            string answer;
            string URLString = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
            string rate = "unresolved";
            try
            {
                XmlReader reader = new XmlTextReader(URLString);
                rate = ExtractRate(reader);
            }
            catch (System.Net.WebException e)
            {
                Wrapper.Wrap(e);
            }

            answer = string.Format("Aktuální kurz EUR vůči CZK: {0}", rate);
            return Wrapper.Wrap(answer);
        }

        public HtmlDocument GetCurrentTime(TimeZone timeZone)
        {
            string answer;
            var val = DateTime.Now;
            answer = string.Format("Aktuální čas serveru je: {0}", val.ToString("HH:mm:ss"));
            return Wrapper.Wrap(answer);
        }

        public HtmlDocument GetUserID()
        {
            string answer;
            OperationContext context = OperationContext.Current;

            MessageProperties messageProperties = context.IncomingMessageProperties;

            RemoteEndpointMessageProperty endpointProperty =
                messageProperties[RemoteEndpointMessageProperty.Name]
                as RemoteEndpointMessageProperty;
            answer = endpointProperty.Address;
            return Wrapper.Wrap(answer);
        }

        public static string ExtractRate(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.HasAttributes)
                {
                    if (reader[0] == "CZK")
                    {
                        return reader[1];
                    }
                    reader.MoveToElement();
                }
            }
            return "0";
        }
    }
}
