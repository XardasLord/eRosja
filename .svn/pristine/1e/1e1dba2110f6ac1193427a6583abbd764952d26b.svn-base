using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text.RegularExpressions;
using System.Globalization;


namespace eRosja.Strony.Offline
{
    public partial class KosztyOffline : PhoneApplicationPage
    {
        SQLiteDB.CenyMiejscaSQLite cenyMiejscaSQLite;
        List<string> listaPrzejsc, listaStacji, listaDostepnychPaliw, listaSklepow;
        List<CenyMiejscaService.PapierosyCeny> listaPapierosow;
        List<CenyMiejscaService.Alkohol> listaAlkoholi;
        Dictionary<DateTime, decimal> kursRubla;
        decimal cenaPaliwa;
        decimal kursEUR;

        CenyMiejscaService.PapierosyCeny papierosy;
        CenyMiejscaService.Alkohol alkohol;
        


        public KosztyOffline()
        {
            InitializeComponent();

            cenyMiejscaSQLite = new SQLiteDB.CenyMiejscaSQLite();
            listaPrzejsc = new List<string>();
            listaStacji = new List<string>();
            listaDostepnychPaliw = new List<string>();
            listaSklepow = new List<string>();
            listaPapierosow = new List<CenyMiejscaService.PapierosyCeny>();
            listaAlkoholi = new List<CenyMiejscaService.Alkohol>();
            kursRubla = new Dictionary<DateTime, decimal>();

            listaPrzejsc = cenyMiejscaSQLite.PobierzPrzejscia(App.DB_PATH);
            kursRubla = cenyMiejscaSQLite.PobierzKursRubla(App.DB_PATH);
            kursEUR = cenyMiejscaSQLite.PobierzKursEuro(App.DB_PATH);
            WypiszPrzejscia();
        }




        private void WypiszPrzejscia()
        {
            pbLadowanie.IsIndeterminate = false;
            lpPrzejscia.ItemsSource = listaPrzejsc;
        }



        private void WypiszStacje()
        {
            lpStacje.ItemsSource = null;
            lpStacje.ItemsSource = listaStacji;
        }



        private void WypiszDostepnePaliwa()
        {
            lpPaliwa.ItemsSource = listaDostepnychPaliw;
        }




        private void WypiszPapierosy()
        {
            var listaPapierosowPosortowana = new List<CenyMiejscaService.PapierosyCeny>(listaPapierosow.OrderBy(x => x.Nazwa));

            lpPapierosy.ItemsSource = null;
            lpPapierosy.ItemsSource = listaPapierosowPosortowana;
        }



        private void WypiszAlkohole()
        {
            var listaAlkoholiPosortowana = new List<CenyMiejscaService.Alkohol>(listaAlkoholi.OrderBy(x => x.Nazwa));

            lpAlkohole.ItemsSource = null;
            lpAlkohole.ItemsSource = listaAlkoholiPosortowana;

            WyliczKosztAlkoholu(tbIloscAlkoholu.Text);
        }



        private void WypiszSklepy()
        {
            lpSklepyPapierosy.ItemsSource = listaSklepow;
            lpSklepyAlkohol.ItemsSource = listaSklepow;
        }





        #region "Eventy SelectionChanged w listpickerach"
        private void lpPrzejscia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listaStacji.Clear();

            if (lpPrzejscia.SelectedItem != null)
            {
                string nazwaPrzejscia = lpPrzejscia.SelectedItem.ToString();
                listaStacji = cenyMiejscaSQLite.PobierzStacjeBenzynowe(App.DB_PATH, nazwaPrzejscia);
                listaSklepow = cenyMiejscaSQLite.PobierzSklepy(App.DB_PATH, nazwaPrzejscia);
                WypiszStacje();
                WypiszSklepy();
            }
        }




        // Zmiana stacji benzynowej
        private void lpStacje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lpStacje.SelectedItem != null)
            {
                string nazwaPrzejscia, nazwaStacji;

                nazwaPrzejscia = lpPrzejscia.SelectedItem.ToString();
                nazwaStacji = lpStacje.SelectedItem.ToString();

                listaDostepnychPaliw = cenyMiejscaSQLite.PobierzDostepnePaliwa(App.DB_PATH, nazwaPrzejscia, nazwaStacji);
                WypiszDostepnePaliwa();
            }   
        }




        // Zmiana rodzaju paliwa
        private void lpPaliwa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lpPaliwa.SelectedItem != null)
            {
                string nazwaPrzejscia, nazwaStacji, rodzajPaliwa;

                nazwaPrzejscia = lpPrzejscia.SelectedItem.ToString();
                nazwaStacji = lpStacje.SelectedItem.ToString();
                rodzajPaliwa = lpPaliwa.SelectedItem.ToString();

                cenaPaliwa = cenyMiejscaSQLite.PobierzCenePaliwa(App.DB_PATH, nazwaPrzejscia, nazwaStacji, rodzajPaliwa);
                WyliczKosztPaliwa(tbIloscPaliwa.Text);
            }
        }




        // Zmiana sklepu (papierosy)
        private void lpSklepyPapierosy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lpSklepyPapierosy.SelectedItem != null)
            {
                string nazwaPrzejscia, nazwaSklepu;

                nazwaPrzejscia = lpPrzejscia.SelectedItem.ToString();
                nazwaSklepu = lpSklepyPapierosy.SelectedItem.ToString();

                listaPapierosow = cenyMiejscaSQLite.PobierzPapierosy(App.DB_PATH, nazwaPrzejscia, nazwaSklepu);
                WypiszPapierosy();
            }
        }
        


        // Zmiana papierosów
        private void lpPapierosy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                papierosy = (CenyMiejscaService.PapierosyCeny)e.AddedItems[0];
                WyliczKosztPapierosow(tbIloscPapierosow.Text);
            }
        }




        // Zmiana sklepu (alkohol)
        private void lpSklepyAlkohol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lpSklepyAlkohol.SelectedItem != null)
            {
                string nazwaPrzejscia, nazwaSklepu;

                nazwaPrzejscia = lpPrzejscia.SelectedItem.ToString();
                nazwaSklepu = lpSklepyAlkohol.SelectedItem.ToString();

                listaAlkoholi = cenyMiejscaSQLite.PobierzAlkohole(App.DB_PATH, nazwaPrzejscia, nazwaSklepu);
                WypiszAlkohole();
            }
        }


        // Zmiana alkoholu
        private void lpAlkohole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                alkohol = (CenyMiejscaService.Alkohol)e.AddedItems[0];
                WyliczKosztAlkoholu(tbIloscAlkoholu.Text);
            }
        }
        #endregion


        #region "Checkboxy"
        // Papierosy ZAZNACZONE
        private void cbPapierosy_Checked(object sender, RoutedEventArgs e)
        {
            if (gridPapierosy != null)
                gridPapierosy.Visibility = System.Windows.Visibility.Visible;
        }

        // Papierosy NIEZAZNACZONE
        private void cbPapierosy_Unchecked(object sender, RoutedEventArgs e)
        {
            if (gridPapierosy != null)
            {
                gridPapierosy.Visibility = System.Windows.Visibility.Collapsed;
                tbIloscPapierosow.Text = "";
            }

            
        }

        // Alkohol ZAZNACZONE
        private void cbAlkohol_Checked(object sender, RoutedEventArgs e)
        {
            if (gridAlkohol != null)
                gridAlkohol.Visibility = System.Windows.Visibility.Visible;
        }

        // Alkohol NIEZAZNACZONE
        private void cbAlkohol_Unchecked(object sender, RoutedEventArgs e)
        {
            if (gridAlkohol != null)
            {
                gridAlkohol.Visibility = System.Windows.Visibility.Collapsed;
                tbIloscAlkoholu.Text = "";
            }
        }
        #endregion


        
        // Wpisanie ilości paliwa
        private void tbIloscPaliwa_TextChanged(object sender, TextChangedEventArgs e)
        {
            WyliczKosztPaliwa(tbIloscPaliwa.Text);
        }


        // Wpisanie ilości papierosów
        private void tbIloscPapierosow_TextChanged(object sender, TextChangedEventArgs e)
        {
            WyliczKosztPapierosow(tbIloscPapierosow.Text);
        }


        // Wpisanie ilości alkoholu
        private void tbIloscAlkoholu_TextChanged(object sender, TextChangedEventArgs e)
        {
            WyliczKosztAlkoholu(tbIloscAlkoholu.Text);
        }




        private void WyliczKosztPaliwa(string iloscLitrow)
        {           
            double kurs = PobierzKursRubla();
            decimal litry;
            decimal koszt = 0;
            decimal.TryParse(iloscLitrow, out litry);


            foreach (double rubel in kursRubla.Values)
                kurs = rubel;


            try
            {
                // Próba wyliczenia kosztów za paliwo, w przypadku gdy webservice zawiedzie zostanie przechwycony wyjątek, dlatego jest to w TRY
                koszt = Math.Round(((litry * cenaPaliwa) * (decimal)kurs), 2);
            }
            catch
            {
                tbCenaPaliwa.Text = "Błąd wyliczenia!";
            }


            tbCenaPaliwa.Text = koszt.ToString() + " PLN";
            ObliczKosztWyjazdu();
        }



        private void WyliczKosztPapierosow(string iloscPapierosow)
        {
            decimal kurs = kursEUR;
            int iloscSztuk = 0;
            decimal koszt = 0;
            int.TryParse(iloscPapierosow, out iloscSztuk);

            try
            {
                // Próba wyliczenia kosztów za papierosy (niektóre papierosy nie miają cen za paczkę, dlatego jest to w TRY
                koszt = Math.Round((iloscSztuk * (decimal)papierosy.CenaPaczka * (decimal)kurs), 2);
            }
            catch
            {
                tbCenaPapierosow.Text = "Błąd wyliczenia!";
            }


            tbCenaPapierosow.Text = koszt.ToString() + " PLN";
            ObliczKosztWyjazdu();
        }



        private void WyliczKosztAlkoholu(string iloscAlkoholu)
        {
            double kursRUB = PobierzKursRubla();
            int iloscLitrow = 0;
            decimal koszt = 0;
            int.TryParse(iloscAlkoholu, out iloscLitrow);

            try
            {
                // Próba wyliczenia kosztów za alkohol
                if(alkohol.Sklep.Equals("Budy"))
                {
                    // BUDY - Ceny w rublach więc liczymy dla kursu RUB
                    koszt = Math.Round((iloscLitrow * (decimal)alkohol.Cena * (decimal)kursRUB), 2);                   
                }
                else
                {
                    // BEZCŁOWY - Ceny w euro więc liczymy dla kursu EUR
                    koszt = Math.Round((iloscLitrow * (decimal)alkohol.Cena * (decimal)kursEUR), 2);
                }
            }
            catch
            {
                tbCenaPapierosow.Text = "Błąd wyliczenia!";
            }


            tbCenaAlkoholu.Text = koszt.ToString() + " PLN";
            ObliczKosztWyjazdu();
        }




        private void ObliczKosztWyjazdu()
        {
            decimal cenaPaliwa = 0;
            decimal cenaPapierosow = 0;
            decimal cenaAlkoholu = 0; 
            decimal kosztCalkowity = 0;

            Regex regex = new Regex(@"^-?\d+(?:\.\d+)?");
            Match match = regex.Match(tbCenaPaliwa.Text);
            if (match.Success)
            {
                cenaPaliwa = decimal.Parse(match.Value, CultureInfo.InvariantCulture);
            }

            match = regex.Match(tbCenaPapierosow.Text);
            if (match.Success)
            {
                cenaPapierosow = decimal.Parse(match.Value, CultureInfo.InvariantCulture);
            }

            match = regex.Match(tbCenaAlkoholu.Text);
            if (match.Success)
            {
                cenaAlkoholu = decimal.Parse(match.Value, CultureInfo.InvariantCulture);
            }

            kosztCalkowity = cenaPaliwa + cenaPapierosow + cenaAlkoholu;
            tbKosztCalkowity.Text = kosztCalkowity + " PLN";
        }



        private double PobierzKursRubla()
        {
            double kurs = 0;

            foreach (double rubel in kursRubla.Values)
                kurs = rubel;

            return kurs;
        }



        private void PrzekierujNaStroneGlowna()
        {
            Uri uriStronaGlowna = new Uri("/Strony/StronaGlowna.xaml", UriKind.Relative);
            NavigationService.Navigate(uriStronaGlowna);
        }

        

        


     

    }
}