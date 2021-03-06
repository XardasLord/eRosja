﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFeRosja
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICenyMiejscaService" in both code and config file together.
    [ServiceContract]
    public interface ICenyMiejscaService
    {
        [OperationContract(Name = "PobierzPrzejscia")]
        List<string> PobierzPrzejscia();


        [OperationContract(Name = "PobierzStacjeBenzynowe")]
        List<string> PobierzStacjeBenzynowe(string nazwaPrzejscia);


        [OperationContract(Name = "PobierzNazwyPaliw")]
        List<string> PobierzNazwyPaliw();


        [OperationContract(Name = "PobierzCenyPaliw")]
        Dictionary<int, decimal> PobierzCenyPaliw(string nazwaPrzejscia, string nazwaStacji);


        [OperationContract(Name = "PobierzCenyPaliwWszystkie")]
        Dictionary<int, decimal> PobierzCenyPaliwWszystkie();


        [OperationContract(Name = "PobierzCenePaliwa")]
        decimal PobierzCenePaliwa(string nazwaPrzejscia, string nazwaStacji, string rodzajPaliwa);


        [OperationContract(Name = "PobierzSklepy")]
        List<string> PobierzSklepy(string nazwaPrzejscia);


        [OperationContract(Name = "PobierzKursRubla")]
        Dictionary<DateTime, decimal> PobierzKursRubla();


        [OperationContract(Name = "PobierzKursEuro")]
        decimal PobierzKursEuro();


        [OperationContract(Name = "PobierzPapierosy")]
        List<PapierosyCeny> PobierzPapierosy(string nazwaPrzejscia, string nazwaSklepu);


        [OperationContract(Name = "PobierzCenyPapierosowWszystkiePakiet")]
        Dictionary<int, decimal> PobierzCenyPapierosowWszystkiePakiet();


        [OperationContract(Name = "PobierzCenyPapierosowWszystkiePaczka")]
        Dictionary<int, decimal> PobierzCenyPapierosowWszystkiePaczka();


        [OperationContract(Name = "PobierzAlkohole")]
        List<Alkohol> PobierzAlkohole(string nazwaPrzejscia, string nazwaSklepu);


        [OperationContract(Name = "PobierzDostepnePaliwa")]
        List<string> PobierzDostepnePaliwa(string nazwaPrzejscia, string nazwaStacji);


        List<PapierosyCeny> PrzetworzListePapierosowDlaKlienta(List<Papierosy_cenyEntity> listaPapierosowEntity);


        List<Alkohol> PrzetworzListeAlkoholiDlaKlienta(List<Alkohole_cenyEntity> listaAlkoholiEntity);

        long PobierzIDPrzejscia(string nazwaPrzejscia);

        long PobierzIDStacji(string nazwaStacji, long IdPrzejscia);

        long PobierzIDSklepu(string nazwaSklepu);


    }
}
