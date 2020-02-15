using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace eRosja.SQLiteDB
{
    class ZmianySQLite
    {
        public Tuple<string, string> PobierzZmiane(string DB_PATH, DateTime dataSprawdzana)
        {
            
            DateTime? dataRozpoczeciaCyklu;
            string zmianaDzien, zmianaNoc;


            using (SQLiteConnection conn = new SQLiteConnection(DB_PATH))
            {
                var cyklZmian = conn.Table<cykl_zmian>().Where(c => c.data_poczatkowa != null).First();
                dataRozpoczeciaCyklu = cyklZmian.data_poczatkowa;
            }


            zmianaDzien = WyliczZmianeDzien(DB_PATH, dataSprawdzana, (DateTime)dataRozpoczeciaCyklu);
            zmianaNoc = WyliczZmianeNoc(DB_PATH, dataSprawdzana, (DateTime)dataRozpoczeciaCyklu);    
            
            var zmiana = new Tuple<string, string>(zmianaDzien, zmianaNoc);

            return zmiana;
        }



        public string WyliczZmianeDzien(string DB_PATH, DateTime dataSprawdzana, DateTime dataRozpoczeciaCyklu)
        {           
            int wynik = 0;
            bool przyszlosc = true;

            if(dataSprawdzana >= dataRozpoczeciaCyklu)
            // data z przyszłości w stosunku do tej z bazy
            {
                int dzien = 1;

                // algorytm wyliczający liczbę, dzięki której będę mógł sprawdzić kto miał dzień
                wynik = Math.Abs((dataSprawdzana.Subtract(dataRozpoczeciaCyklu).Days)) * 2 + dzien;
            }
            else
            {
                // data z przeszłości
                wynik = Math.Abs((dataSprawdzana.Subtract(dataRozpoczeciaCyklu).Days)) * 2;
                przyszlosc = false;
            }

            // dzięki tej zmiennej będę wiedział które ID w bazie odpowiada za zmianę tego dnia
            int id = 0;

            while(wynik != 0)
            {
                if((wynik - 8) >= 0)
                {
                    wynik = wynik - 8;
                    id = 8;
                }
                else if((wynik - 7) >= 0)
                {
                    wynik = wynik - 7;
                    id = 7;
                }
                else if ((wynik - 6) >= 0)
                {
                    wynik = wynik - 6;
                    id = 6;
                }
                else if ((wynik - 5) >= 0)
                {
                    wynik = wynik - 5;
                    id = 5;
                }
                else if ((wynik - 4) >= 0)
                {
                    wynik = wynik - 4;
                    id = 4;
                }
                else if ((wynik - 3) >= 0)
                {
                    wynik = wynik - 3;
                    id = 3;
                }
                else if ((wynik - 2) >= 0)
                {
                    wynik = wynik - 2;
                    id = 2;
                }
                else if ((wynik - 1) >= 0)
                {
                    wynik = wynik - 1;
                    id = 1;
                }
            }


            if (przyszlosc == false)
            {
                // jeśli data jest z przeszłości
                id = 9 - id;
            }


            string zmianaDzien = "";


            using (SQLiteConnection conn = new SQLiteConnection(DB_PATH))
            {
                var cyklZmian = conn.Table<cykl_zmian>().Where(c => c.id_cykl_zmian == id).First();
                var idZmiany = cyklZmian.id_zmiany;
                var zmiany = conn.Table<zmiany>().Where(z => z.id_zmiany == idZmiany).First();
                
                zmianaDzien = zmiany.nazwa;
            }

            return zmianaDzien;
        }





        public string WyliczZmianeNoc(string DB_PATH, DateTime dataSprawdzana, DateTime dataRozpoczeciaCyklu)
        {
            int wynik = 0;
            bool przyszlosc = true;

            if (dataSprawdzana >= dataRozpoczeciaCyklu)
            // data z przyszłości w stosunku do tej z bazy
            {
                int noc = 2;

                // algorytm wyliczający liczbę, dzięki której będę mógł sprawdzić kto miał dzień
                wynik = Math.Abs((dataSprawdzana.Subtract(dataRozpoczeciaCyklu).Days)) * 2 + noc;
            }
            else
            {
                // data z przeszłości
                int noc = 1;

                wynik = Math.Abs((dataSprawdzana.Subtract(dataRozpoczeciaCyklu).Days)) * 2 - noc;
                przyszlosc = false;
            }

            // dzięki tej zmiennej będę wiedział które ID w bazie odpowiada za zmianę tego dnia
            int id = 0;

            while (wynik != 0)
            {
                if ((wynik - 8) >= 0)
                {
                    wynik = wynik - 8;
                    id = 8;
                }
                else if ((wynik - 7) >= 0)
                {
                    wynik = wynik - 7;
                    id = 7;
                }
                else if ((wynik - 6) >= 0)
                {
                    wynik = wynik - 6;
                    id = 6;
                }
                else if ((wynik - 5) >= 0)
                {
                    wynik = wynik - 5;
                    id = 5;
                }
                else if ((wynik - 4) >= 0)
                {
                    wynik = wynik - 4;
                    id = 4;
                }
                else if ((wynik - 3) >= 0)
                {
                    wynik = wynik - 3;
                    id = 3;
                }
                else if ((wynik - 2) >= 0)
                {
                    wynik = wynik - 2;
                    id = 2;
                }
                else if ((wynik - 1) >= 0)
                {
                    wynik = wynik - 1;
                    id = 1;
                }
            }


            if (przyszlosc == false)
            {
                // jeśli data jest z przeszłości
                id = 9 - id;
            }


            string zmiananoc = "";


            using (SQLiteConnection conn = new SQLiteConnection(DB_PATH))
            {
                var cyklZmian = conn.Table<cykl_zmian>().Where(c => c.id_cykl_zmian == id).First();
                var idZmiany = cyklZmian.id_zmiany;
                var zmiany = conn.Table<zmiany>().Where(z => z.id_zmiany == idZmiany).First();

                zmiananoc = zmiany.nazwa;
            }


            return zmiananoc;
        }
    }
}
