using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFeRosja
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUzytkownikService
    {
        [OperationContract(Name = "ZarejestrujUzytkownika")]
        bool ZarejestrujUzytkownika(string login, string haslo, string email);

        [OperationContract(Name = "ZalogujUzytkownika")]
        bool ZalogujUzytkownika(string login, string haslo);

        [OperationContract(Name = "PobierzID")]
        long PobierzID(string login, string haslo);


        bool SprawdzCzyIstniejeLogin(string login);
    }
}
