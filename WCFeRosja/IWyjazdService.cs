﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFeRosja
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWyjazdyService" in both code and config file together.
    [ServiceContract]
    public interface IWyjazdService
    {
        [OperationContract(Name="DodajWyjazd")]
        Task<bool> DodajWyjazd(Wyjazd daneWyjazdu);

        [OperationContract(Name = "PobierzWyjazdy")]
        List<Wyjazd> PobierzWyjazdy(string loginUzytkownika);


        WyjazdyEntity PrzetworzWyjazdDlaBazy(Wyjazd daneWyjazdu);

        List<Wyjazd> PrzetworzWyjazdyDlaKlienta(List<WyjazdyEntity> listaWyjazdowEntity);
    }
}
