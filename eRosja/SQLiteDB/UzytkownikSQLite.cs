﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eRosja.SQLiteDB
{
    class UzytkownikSQLite
    {
        public void ZarejestrujUzytkownika(string DB_PATH, string login, string haslo, string email)
        {
            using (SQLiteConnection conn = new SQLiteConnection(DB_PATH))
            {
                var uzytkownicy = conn.Table<uzytkownicy>().Select(u => u.id_uzytkownicy).ToList();

                // Rejestracja
                uzytkownicy uzytkownik = new uzytkownicy();
                uzytkownik.login = login;
                uzytkownik.haslo = haslo;
                uzytkownik.email = email;
                uzytkownik.zarejestrowano = DateTime.Now;
                uzytkownik.ostatnie_logowanie = DateTime.Now;
                uzytkownik.status = 0;
                uzytkownik.id_uzytkownicy = uzytkownicy.Count + 1;

                conn.BeginTransaction();
                conn.Insert(uzytkownik);
                conn.Commit();
            }
        }



        public bool ZalogujUzytkownika(string DB_PATH, string login, string haslo)
        {
            bool istnieje;

            using (SQLiteConnection conn = new SQLiteConnection(DB_PATH))
            {
                // Sprawdzenie czy istnieje w bazie użytkownik o podanym loginie i haśle
                int istnieje2 = conn.Table<uzytkownicy>().Count(u => u.login.Equals(login) && u.haslo.Equals(haslo));

                if (istnieje2 == 0)
                    istnieje = false;
                else
                    istnieje = true;
            }

            return istnieje;
        }
    }
}
