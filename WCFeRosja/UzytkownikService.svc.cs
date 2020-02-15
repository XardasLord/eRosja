using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace WCFeRosja
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UzytkownikService : IUzytkownikService
    {

        public bool ZarejestrujUzytkownika(string login, string haslo, string email)
        {
            using (eRosjaEntities eRosja = new eRosjaEntities())
            {
                bool istnieje = SprawdzCzyIstniejeLogin(login);

                if (istnieje == false)
                {
                    // Rejestracja
                    UzytkownicyEntity uzytkownik = new UzytkownicyEntity();
                    uzytkownik.login = login;
                    uzytkownik.haslo = haslo;
                    uzytkownik.email = email;
                    uzytkownik.zarejestrowano = DateTime.Now;
                    uzytkownik.ostatnie_logowanie = DateTime.Now;
                    uzytkownik.status = 0;

                    eRosja.uzytkownicy.Add(uzytkownik);
                    eRosja.SaveChanges();
                    return true;
                }

                return false;
            }   
        }

        public bool ZalogujUzytkownika(string login, string haslo)
        {
            bool istnieje; 

            using (eRosjaEntities eRosja = new eRosjaEntities())
            {
                // Sprawdzenie czy istnieje w bazie użytkownik o podanym loginie i haśle
                int istnieje2 = eRosja.uzytkownicy.Count(u => u.login.Equals(login) && u.haslo.Equals(haslo));

                if (istnieje2 == 0)
                    istnieje = false;
                else
                    istnieje = true;
            }

            return istnieje;
        }


        public long PobierzID(string login, string haslo)
        {
            long ID;

            using (eRosjaEntities eRosja = new eRosjaEntities())
            {
                ID = eRosja.uzytkownicy.First(u => u.login.Equals(login) && u.haslo.Equals(haslo)).id_uzytkownicy;
            }

            return ID;            
        }


        public bool SprawdzCzyIstniejeLogin(string login)
        {
            bool istnieje = false;

            using (eRosjaEntities eRosja = new eRosjaEntities())
            {
                istnieje = eRosja.uzytkownicy.Any(u => u.login.Equals(login));
            }

            return istnieje;
        }
    }
}
