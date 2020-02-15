using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFeRosja
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IZmianyService" in both code and config file together.
    [ServiceContract]
    public interface IZmianyService
    {
        [OperationContract]
        Tuple<string, string> PobierzZmiane(DateTime dataSprawdzana);


        string WyliczZmianeDzien(DateTime dataSprawdzana, DateTime dataRozpoczeciaCyklu);

        string WyliczZmianeNoc(DateTime dataSprawdzana, DateTime dataRozpoczeciaCyklu);
    }
}
