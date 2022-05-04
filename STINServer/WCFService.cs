using STINInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace STINServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class WCFService : IWCFService
    {
        public string GetCurrentRate()
        {
            string URLString = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml";
            return GetCurrentRateStatic(URLString);
        }


        public static string GetCurrentRateStatic(string URLString)
        {
            Console.WriteLine("GetCurrentRate Called");
            string answer;

            string rate = "unresolved";
            try
            {
                XmlReader reader = new XmlTextReader(URLString);
                rate = ExtractRate(reader);
            }
            catch (System.Net.WebException)
            {
                Wrapper.Wrap("Chyba při získávání informací o kurzu");
            }

            answer = string.Format("Aktuální kurz EUR vůči CZK: {0}", rate);
            return Wrapper.Wrap(answer);
        }

        public string GetCurrentTime(TimeSpan offset, DateTime time = default(DateTime))
        {
            return GetCurrentTimeStatic(offset);
        }

        public static string GetCurrentTimeStatic(TimeSpan offset, DateTime time = default(DateTime))
        {
            if (time == default(DateTime))
            {
                time = DateTime.Now;
                time = TimeZone.CurrentTimeZone.ToUniversalTime(time);
            }
            Console.WriteLine("GetCurrentTime Called");
            string answer;
            int hours = offset.Hours;
            var val = time.AddHours(hours);
            answer = string.Format("Aktuální čas serveru je: {0}", val.ToString("HH:mm:ss"));
            return Wrapper.Wrap(answer);
        }

        public string GetUserID()
        {
            return GetUserIDStatic();
        }

        public static string GetUserIDStatic(RemoteEndpointMessageProperty endpointProperty = null)
        {
            Console.WriteLine("GetUserID Called");
            string answer;
            string ip = "ID nenalezeno";
            if (endpointProperty == null)
            {
                var props = OperationContext.Current.IncomingMessageProperties;
                endpointProperty = props[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            }
            if (endpointProperty != null)
            {
                ip = endpointProperty.Address;
            }

            answer = string.Format("ID clienta je: {0}", ip);
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
