using eRosja.WyjazdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace eRosja.SQLiteDB
{
    class WyjazdSQLite
    {

        public List<Wyjazd> PobierzWyjazdy(string DB_PATH, string loginUzytkownika)
        {
            List<Wyjazd> listaWyjazdow = new List<Wyjazd>();
            List<wyjazdy> listaWyjazdowEntity = new List<wyjazdy>();


            using (SQLiteConnection conn = new SQLiteConnection(DB_PATH))
            {
                var uzytkownicy = conn.Table<uzytkownicy>().Where(u => u.login.Equals(loginUzytkownika)).First();
                listaWyjazdowEntity = conn.Table<wyjazdy>().Where(w => w.id_uzytkownicy == uzytkownicy.id_uzytkownicy).ToList();
            }

            // Przekształca listę pobraną bezpośrednio z bazy na listę nazw (zamiast ID) dla klienta
            listaWyjazdow = PrzetworzWyjazdyDlaKlienta(DB_PATH, listaWyjazdowEntity);


            return listaWyjazdow;
        }


        public bool DodajWyjazd(string DB_PATH, Wyjazd daneWyjazdu)
        {
            wyjazdy wyjazd = new wyjazdy(); // local entity
            wyjazd = PrzetworzWyjazdDlaBazy(DB_PATH, daneWyjazdu);


            using (SQLiteConnection conn = new SQLiteConnection(DB_PATH))
            {
                conn.BeginTransaction();
                conn.Insert(wyjazd);
                conn.Commit();
            }

            return true;
        }


        /* Przetwarza dane wyjazdu pobrane z bazy (ID) na NAZWY dla klienta
           Konwersja:
           ID - NAZWY */
        private List<Wyjazd> PrzetworzWyjazdyDlaKlienta(string DB_PATH, List<wyjazdy> listaWyjazdowEntity)
        {
            List<Wyjazd> listaWyjazdow = new List<Wyjazd>();


            using (SQLiteConnection conn = new SQLiteConnection(DB_PATH))
            {
                // Przejście przez każdy z wyjazdów
                for (int i = 0; i < listaWyjazdowEntity.Count; i++)
                {
                    Wyjazd wyjazd = new Wyjazd();
                    Paliwo paliwo = new Paliwo();
                    Alkohol alkohol = new Alkohol();
                    Papierosy papierosy = new Papierosy();
                    wyjazd.Paliwo = paliwo;
                    wyjazdy wyjazdEntity = new wyjazdy();

                    wyjazdEntity = listaWyjazdowEntity[i];

                    // Zamiana każdego z wyjazdów na wyjazd dla klienta
                    // ID - NAZWY
                    var uzytkownicy = conn.Table<uzytkownicy>().Where(u => u.id_uzytkownicy == wyjazdEntity.id_uzytkownicy).First();
                    wyjazd.LoginUzytkownika = uzytkownicy.login;

                    var przejscia = conn.Table<przejscia>().Where(p => p.id_przejscia == wyjazdEntity.id_przejscia).First();
                    wyjazd.Przejscie = przejscia.nazwa;

                    var stacje = conn.Table<stacje_benzynowe>().Where(s => s.id_stacje_benzynowe == wyjazdEntity.id_stacje_benzynowe).First();
                    wyjazd.Paliwo.Stacja = stacje.nazwa;

                    var paliwa = conn.Table<paliwa>().Where(p => p.id_paliwa == wyjazdEntity.id_paliwa).First();
                    wyjazd.Paliwo.RodzajPaliwa = paliwa.nazwa;

                    wyjazd.Paliwo.IloscPaliwa = wyjazdEntity.ilosc_paliwa;


                    if (wyjazdEntity.id_sklepy_papierosy != null)
                    {
                        wyjazd.Papierosy = papierosy;

                        var sklepy = conn.Table<sklepy>().Where(s => s.id_sklepy == wyjazdEntity.id_sklepy_papierosy).First();
                        wyjazd.Papierosy.Sklep = sklepy.nazwa;

                        var papierosySQLite = conn.Table<papierosy>().Where(p => p.id_papierosy == wyjazdEntity.id_papierosy).First();
                        wyjazd.Papierosy.Nazwa = papierosySQLite.nazwa;

                        wyjazd.Papierosy.Ilosc = (int)wyjazdEntity.ilosc_papierosow;
                    }

                    if (wyjazdEntity.id_sklepy_alkohole != null)
                    {
                        wyjazd.Alkohol = alkohol;

                        var sklepy = conn.Table<sklepy>().Where(s => s.id_sklepy == wyjazdEntity.id_sklepy_alkohole).First();
                        wyjazd.Alkohol.Sklep = sklepy.nazwa;

                        var alkoholeSQLite = conn.Table<alkohole>().Where(a => a.id_alkohole == wyjazdEntity.id_alkohole).First();
                        wyjazd.Alkohol.Nazwa = alkoholeSQLite.nazwa;

                        wyjazd.Alkohol.Ilosc = (decimal)wyjazdEntity.ilosc_alkoholu;
                    }

                    wyjazd.Data = wyjazdEntity.data;

                    if (wyjazdEntity.kanal == 1)
                        wyjazd.Kanal = true;
                    else
                        wyjazd.Kanal = false;

                    if (wyjazdEntity.mandat == 1)
                        wyjazd.Mandat = true;
                    else
                        wyjazd.Mandat = false;

                    // Dodanie przetworzonego wyjazdu dla klienta do listy
                    listaWyjazdow.Add(wyjazd);
                }
            }

            return listaWyjazdow;
        }


        /* Przetwarza dane wyjazdu przesłane przez użytkownika w nazwach na ID, żeby móc zapisać do bazy
           Konwersja:
           NAZWY - ID */
        public wyjazdy PrzetworzWyjazdDlaBazy(string DB_PATH, Wyjazd daneWyjazdu)
        {
            int kanal = 0;
            int mandat = 0;
            bool papierosy = true;
            bool alkohol = true;

            if (daneWyjazdu.Kanal == true)
                kanal = 1;
            if (daneWyjazdu.Mandat == true)
                mandat = 1;
            if (daneWyjazdu.Papierosy == null)
                papierosy = false;
            if (daneWyjazdu.Alkohol == null)
                alkohol = false;

            wyjazdy wyjazd = new wyjazdy();


            using (SQLiteConnection conn = new SQLiteConnection(DB_PATH))
            {
                var przejscia = conn.Table<przejscia>().Where(p => p.nazwa.Equals(daneWyjazdu.Przejscie)).First();
                wyjazd.id_przejscia = przejscia.id_przejscia;

                var stacje = conn.Table<stacje_benzynowe>().Where(s => s.nazwa.Equals(daneWyjazdu.Paliwo.Stacja) && s.id_przejscia == przejscia.id_przejscia).First();
                wyjazd.id_stacje_benzynowe = stacje.id_stacje_benzynowe;

                var uzytkownicy = conn.Table<uzytkownicy>().Where(u => u.login.Equals(daneWyjazdu.LoginUzytkownika)).First();
                wyjazd.id_uzytkownicy = uzytkownicy.id_uzytkownicy;

                var paliwoNazwy = conn.Table<paliwa>().Where(p => p.nazwa.Equals(daneWyjazdu.Paliwo.RodzajPaliwa)).First();
                var paliwa = conn.Table<paliwo_ceny>().Where(p => p.id_paliwa == paliwoNazwy.id_paliwa && p.id_stacje_benzynowe == stacje.id_stacje_benzynowe).First();
                wyjazd.id_paliwa = paliwa.id_paliwa;
                wyjazd.ilosc_paliwa = daneWyjazdu.Paliwo.IloscPaliwa;


                if (papierosy == true)
                {
                    var sklepyPapierosy = conn.Table<sklepy>().Where(s => s.nazwa.Equals(daneWyjazdu.Papierosy.Sklep) && s.id_przejscia == przejscia.id_przejscia).First();
                    wyjazd.id_sklepy_papierosy = sklepyPapierosy.id_sklepy;

                    var papierosyNazwa = conn.Table<papierosy>().Where(p => p.nazwa.Equals(daneWyjazdu.Papierosy.Nazwa)).First();                    
                    var papierosy2 = conn.Table<papierosy_ceny>().Where(p => p.id_papierosy == papierosyNazwa.id_papierosy &&
                                                                  p.id_przejscia == przejscia.id_przejscia &&
                                                                  p.id_sklepy == wyjazd.id_sklepy_papierosy).First();
                    wyjazd.id_papierosy = papierosy2.id_papierosy;
                    wyjazd.ilosc_papierosow = daneWyjazdu.Papierosy.Ilosc;
                }


                if (alkohol == true)
                {
                    var sklepyAlkohol = conn.Table<sklepy>().Where(s => s.nazwa.Equals(daneWyjazdu.Alkohol.Sklep) && s.id_przejscia == przejscia.id_przejscia).First();
                    wyjazd.id_sklepy_alkohole = sklepyAlkohol.id_sklepy;

                    var alkoholNazwa = conn.Table<alkohole>().Where(a => a.nazwa.Equals(daneWyjazdu.Alkohol.Nazwa)).First();                    
                    var alkohol2 = conn.Table<alkohol_ceny>().Where(a => a.id_alkohole == alkoholNazwa.id_alkohole &&
                                                                  a.id_przejscia == przejscia.id_przejscia &&
                                                                  a.id_sklepy == wyjazd.id_sklepy_alkohole).First();
                    wyjazd.id_alkohole = alkohol2.id_alkohole;
                    wyjazd.ilosc_alkoholu = daneWyjazdu.Alkohol.Ilosc;
                }


                wyjazd.data = daneWyjazdu.Data;
                wyjazd.kanal = kanal;
                wyjazd.mandat = mandat;


                return wyjazd;
            }
        }
    }
}
