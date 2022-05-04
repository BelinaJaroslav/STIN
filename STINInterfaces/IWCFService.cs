using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace STINInterfaces
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IWCFService
    {
        [OperationContract]
        string GetUserID();

        [OperationContract]
        string GetCurrentTime(TimeSpan offset, DateTime time=default(DateTime));

        [OperationContract]
        string GetCurrentRate();
    }
}
