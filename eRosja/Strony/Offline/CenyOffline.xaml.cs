using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;

namespace eRosja.Strony.Offline
{
    public partial class CenyOffline : PhoneApplicationPage
    {
        SQLiteDB.CenyMiejscaSQLite cenyMiejscaSQLite;
        List<string> listaPrzejsc;
        List<string> listaStacji;
        List<string> listaPaliw;
        List<string> listaSklepow;
        List<CenyMiejscaService.PapierosyCeny> listaPapierosow;
        List<CenyMiejscaService.PapierosyCeny> listaPapierosowPosortowana;
        Dictionary<long, decimal> cenyPaliw;
        Dictionary<DateTime, decimal> kursRubla;
        decimal kursEUR;


        public CenyOffline()
        {
            InitializeComponent();

            cenyMiejscaSQLite = new SQLiteDB.CenyMiejscaSQLite();

            listaPrzejsc = new List<string>();
            listaStacji = new List<string>();
            listaPaliw = new List<string>();
            listaSklepow = new List<string>();
            listaPapierosow = new List<CenyMiejscaService.PapierosyCeny>();
            cenyPaliw = new Dictionary<long, decimal>();
            kursRubla = new Dictionary<DateTime, decimal>();


            listaPrzejsc = cenyMiejscaSQLite.PobierzPrzejscia(App.DB_PATH);
            kursRubla = cenyMiejscaSQLite.PobierzKursRubla(App.DB_PATH);
            kursEUR = cenyMiejscaSQLite.PobierzKursEuro(App.DB_PATH);
            WypiszPrzejscia();
        }





        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        private void UstawNazwyPaliw()
        {
            TextBlock tb = new TextBlock();

            for (int i = 1; i <= listaPaliw.Count; i++)
            {
                // Przechodzimy przez każdą kontrolkę o nazwie 'tbPaliwo1, tbPaliwo2...' 
                // i ustawiamy jej tekst na nazwę paliwa pobranego z bazy
                object kontrolka = LayoutRoot.FindName("tbPaliwo" + i);
                tb = (TextBlock)kontrolka;
                tb.Text = listaPaliw.ElementAt(i - 1).ToString();
            }
        }



        private void UstawCenyPaliw()
        {
            TextBlock tb = new TextBlock();

            for (int i = 1; i <= listaPaliw.Count; i++)
            {
                foreach (long id_paliwa in cenyPaliw.Keys)
                {
                    if (id_paliwa == i)
                    {
                        object kontrolka = LayoutRoot.FindName("tbCena" + i);
                        tb = (TextBlock)kontrolka;
                        tb.Text = cenyPaliw.FirstOrDefault(x => x.Key == i).Value.ToString();
                    }
                }
            }
        }


        private void ZerujCenyPaliw()
        {
            TextBlock tb = new TextBlock();

            for (int i = 1; i <= listaPaliw.Count; i++)
            {
                object kontrolka = LayoutRoot.FindName("tbCena" + i);
                tb = (TextBlock)kontrolka;
                tb.Text = "";
            }
        }




        private void ZerujCenyPapierosow()
        {
            tbEuroPakiet.Text = "";
            tbEuroPaczka.Text = "";
            tbRubPakiet.Text = "";
            tbRubPaczka.Text = "";
            tbPlnPakiet.Text = "";
            tbPlnPaczka.Text = "";
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>


        //private void PrzekierujNaStroneGlowna()
        //{
        //    Uri uriStronaGlowna = new Uri("/Strony/StronaGlowna.xaml", UriKind.Relative);
        //    NavigationService.Navigate(uriStronaGlowna);
        //}



        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        private void WypiszPrzejscia()
        {
            pbLadowanie.IsIndeterminate = false;

            lpPrzejsciaPaliwo.ItemsSource = listaPrzejsc;
            lpPrzejsciaPapierosy.ItemsSource = listaPrzejsc;
        }



        private void WypiszStacje()
        {
            lpStacjePaliwo.ItemsSource = null;
            lpStacjePaliwo.ItemsSource = listaStacji;
        }




        private void WypiszPapierosy()
        {
            listaPapierosowPosortowana = new List<CenyMiejscaService.PapierosyCeny>(listaPapierosow.OrderBy(x => x.Nazwa));

            lpPapierosy.ItemsSource = null;
            lpPapierosy.ItemsSource = listaPapierosowPosortowana;

            if (listaPapierosowPosortowana.Count == 0)
            {
                ZerujCenyPapierosow();
            }
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>





        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        // Zmiana przejścia granicznego przy PALIWIE
        private void lpPrzejscia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaStacji.Clear();

            if (lpPrzejsciaPaliwo.SelectedItem != null)
            {
                string nazwaPrzejscia = lpPrzejsciaPaliwo.SelectedItem.ToString();
                listaStacji = cenyMiejscaSQLite.PobierzStacjeBenzynowe(App.DB_PATH, nazwaPrzejscia);
                WypiszStacje();
            }          
        }


        // Zmiana stacji benzynowej przy PALIWIE
        private void lpStacje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lpStacjePaliwo.SelectedItem != null)
            {
                string nazwaPrzejscia, nazwaStacji;

                nazwaPrzejscia = lpPrzejsciaPaliwo.SelectedItem.ToString();
                nazwaStacji = lpStacjePaliwo.SelectedItem.ToString();
                tbNazwaStacji.Text = nazwaStacji;

                listaPaliw = cenyMiejscaSQLite.PobierzNazwyPaliw(App.DB_PATH);
                cenyPaliw = cenyMiejscaSQLite.PobierzCenyPaliw(App.DB_PATH, nazwaPrzejscia, nazwaStacji);

                UstawNazwyPaliw();
                ZerujCenyPaliw();
                UstawCenyPaliw();
            }   
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>



        //// Zmiana przejścia granicznego przy PAPIEROSACH
        private void lpPrzejsciaPapierosy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaSklepow.Clear();

            if (lpPrzejsciaPapierosy.SelectedItem != null)
            {
                string nazwaPrzejscia = lpPrzejsciaPapierosy.SelectedItem.ToString();
                listaSklepow = cenyMiejscaSQLite.PobierzSklepy(App.DB_PATH, nazwaPrzejscia);

                lpSklepyPapierosy.ItemsSource = null;
                lpSklepyPapierosy.ItemsSource = listaSklepow;
            }
        }


        //// Zmiana sklepu przy PAPIEROSACH
        private void lpSklepy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaPapierosow.Clear();

            if (lpSklepyPapierosy.SelectedItem != null)
            {
                string nazwaPrzejscia, nazwaSklepu;

                nazwaPrzejscia = lpPrzejsciaPapierosy.SelectedItem.ToString();
                nazwaSklepu = lpSklepyPapierosy.SelectedItem.ToString();

                listaPapierosow = cenyMiejscaSQLite.PobierzPapierosy(App.DB_PATH, nazwaPrzejscia, nazwaSklepu);

                WypiszPapierosy();
            }
        }



        //// Wybranie papierosa
        private void lpPapierosy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var papierosy = (CenyMiejscaService.PapierosyCeny)e.AddedItems[0];

                ZerujCenyPapierosow();
                WpiszCenyPapierosow(papierosy);
            }
        }




        private void WpiszCenyPapierosow(CenyMiejscaService.PapierosyCeny papierosy)
        {
            double kursRUB = 0;

            foreach (double rubel in kursRubla.Values)
                kursRUB = rubel;


            if (papierosy.CenaPakiet != null)
            {
                tbEuroPakiet.Text = papierosy.CenaPakiet.ToString();
                if (kursRUB != 0)
                    tbRubPakiet.Text = Math.Round(((decimal)papierosy.CenaPakiet * (decimal)kursEUR / (decimal)kursRUB), 2).ToString();
                tbPlnPakiet.Text = Math.Round(((decimal)papierosy.CenaPakiet * (decimal)kursEUR), 2).ToString();

            }

            if (papierosy.CenaPaczka != null)
            {
                tbEuroPaczka.Text = papierosy.CenaPaczka.ToString();
                if (kursRUB != 0)
                    tbRubPaczka.Text = Math.Round(((decimal)papierosy.CenaPaczka * (decimal)kursEUR / (decimal)kursRUB), 2).ToString();
                tbPlnPaczka.Text = Math.Round(((decimal)papierosy.CenaPaczka * (decimal)kursEUR), 2).ToString();
            }

        }
    }
}