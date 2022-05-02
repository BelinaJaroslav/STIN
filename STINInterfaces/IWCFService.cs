﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace STINInterfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWCFService
    {
        [OperationContract]
        string GetUserID();

        [OperationContract]
        string GetCurrentTime();
        string GetCurrentTime(TimeZone timeZone);

        [OperationContract]
        string GetCurrentRate();
    }
}
