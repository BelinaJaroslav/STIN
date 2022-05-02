using STINInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace STINServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class WCFService : IWCFService
    {
        public string GetCurrentRate()
        {
            throw new NotImplementedException();
        }

        public string GetCurrentTime()
        {
            throw new NotImplementedException();
        }

        public string GetCurrentTime(TimeZone timeZone)
        {
            throw new NotImplementedException();
        }

        public string GetUserID()
        {
            throw new NotImplementedException();
        }
    }
}
