﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Collections.ObjectModel;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Globalization;

namespace eRosja
{
    public partial class Koszty : PhoneApplicationPage
    {
        CenyMiejscaService.CenyMiejscaServiceClient cenyMiejscaUsluga;
        ObservableCollection<string> listaPrzejsc;
        ObservableCollection<string> listaStacji;
        ObservableCollection<string> listaDostepnychPaliw;
        ObservableCollection<string> listaSklepow;
        ObservableCollection<CenyMiejscaService.PapierosyCeny> listaPapierosow;
        ObservableCollection<CenyMiejscaService.PapierosyCeny> listaPapierosowPosortowana;
        ObservableCollection<CenyMiejscaService.Alkohol> listaAlkoholi;
        ObservableCollection<CenyMiejscaService.Alkohol> listaAlkoholiPosortowana;
        Dictionary<DateTime, decimal> kursRubla;
        decimal cenaPaliwa;
        decimal kursEUR;

        CenyMiejscaService.PapierosyCeny papierosy;
        CenyMiejscaService.Alkohol alkohol;
        


        public Koszty()
        {
            InitializeComponent();

            listaPrzejsc = new ObservableCollection<string>();
            listaStacji = new ObservableCollection<string>();
            listaDostepnychPaliw = new ObservableCollection<string>();
            listaSklepow = new ObservableCollection<string>();
            listaPapierosow = new ObservableCollection<CenyMiejscaService.PapierosyCeny>();
            listaAlkoholi = new ObservableCollection<CenyMiejscaService.Alkohol>();
            kursRubla = new Dictionary<DateTime, decimal>();
            cenyMiejscaUsluga = new CenyMiejscaService.CenyMiejscaServiceClient();
            cenyMiejscaUsluga.PobierzPrzejsciaCompleted += cenyMiejscaUsluga_PobierzPrzejsciaCompleted;
            cenyMiejscaUsluga.PobierzStacjeBenzynoweCompleted += cenyMiejscaUsluga_PobierzStacjeBenzynoweCompleted;
            cenyMiejscaUsluga.PobierzDostepnePaliwaCompleted += cenyMiejscaUsluga_PobierzDostepnePaliwaCompleted;
            cenyMiejscaUsluga.PobierzSklepyCompleted += cenyMiejscaUsluga_PobierzSklepyCompleted;
            cenyMiejscaUsluga.PobierzPapierosyCompleted += cenyMiejscaUsluga_PobierzPapierosyCompleted;
            cenyMiejscaUsluga.PobierzAlkoholeCompleted += cenyMiejscaUsluga_PobierzAlkoholeCompleted;
            cenyMiejscaUsluga.PobierzCenePaliwaCompleted += cenyMiejscaUsluga_PobierzCenePaliwaCompleted;
            cenyMiejscaUsluga.PobierzKursRublaCompleted += cenyMiejscaUsluga_PobierzKursRublaCompleted;
            cenyMiejscaUsluga.PobierzKursEuroCompleted += cenyMiejscaUsluga_PobierzKursEuroCompleted;


            //cenyMiejscaUsluga.PobierzKursRublaAsync();
            //cenyMiejscaUsluga.PobierzKursEuroAsync();
            cenyMiejscaUsluga.PobierzPrzejsciaAsync();
        }

        



        #region "Eventy Completed usługi WCF"
        void cenyMiejscaUsluga_PobierzPrzejsciaCompleted(object sender, CenyMiejscaService.PobierzPrzejsciaCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Błąd połączenia z serwerem");
                PrzekierujNaStroneGlowna();
            }
            else if (e.Result != null)
            {
                cenyMiejscaUsluga.PobierzKursRublaAsync();
                cenyMiejscaUsluga.PobierzKursEuroAsync();

                listaPrzejsc.Clear();

                // Wypełniamy ListPickera przejściami granicznymi
                listaPrzejsc = e.Result;
                lpPrzejscia.ItemsSource = listaPrzejsc;
            }
        }





        void cenyMiejscaUsluga_PobierzStacjeBenzynoweCompleted(object sender, CenyMiejscaService.PobierzStacjeBenzynoweCompletedEventArgs e)
        {
            listaStacji.Clear();

            if (e.Result != null)
            {
                // Wypełniamy ListPickera stacjami benzynowymi
                listaStacji = e.Result;
                lpStacje.ItemsSource = listaStacji;
            }
        }




        void cenyMiejscaUsluga_PobierzDostepnePaliwaCompleted(object sender, CenyMiejscaService.PobierzDostepnePaliwaCompletedEventArgs e)
        {
            pbLadowanie.IsIndeterminate = false;
            listaDostepnychPaliw.Clear();

            if (e.Result != null)
            {
                // Wypełniamy ListPickera dostępnymi rodzajami paliw na tej stacji
                listaDostepnychPaliw = e.Result;
                lpPaliwa.ItemsSource = listaDostepnychPaliw;
            }
        }



        void cenyMiejscaUsluga_PobierzCenePaliwaCompleted(object sender, CenyMiejscaService.PobierzCenePaliwaCompletedEventArgs e)
        {
            if (e.Result != 0)
            {
                cenaPaliwa = e.Result;
                WyliczKosztPaliwa(tbIloscPaliwa.Text);
            }
        }




        void cenyMiejscaUsluga_PobierzSklepyCompleted(object sender, CenyMiejscaService.PobierzSklepyCompletedEventArgs e)
        {
            listaSklepow.Clear();

            if (e.Result != null)
            {
                listaSklepow = e.Result;

                lpSklepyPapierosy.ItemsSource = listaSklepow;
                lpSklepyAlkohol.ItemsSource = listaSklepow;
            }
        }




        void cenyMiejscaUsluga_PobierzPapierosyCompleted(object sender, CenyMiejscaService.PobierzPapierosyCompletedEventArgs e)
        {
            listaPapierosow.Clear();

            if (e.Result != null)
            {
                listaPapierosow = e.Result;
                listaPapierosowPosortowana = new ObservableCollection<CenyMiejscaService.PapierosyCeny>(listaPapierosow.OrderBy(x => x.Nazwa));

                lpPapierosy.ItemsSource = listaPapierosowPosortowana;

                WyliczKosztPapierosow(tbIloscPapierosow.Text);
            }
        }





        void cenyMiejscaUsluga_PobierzAlkoholeCompleted(object sender, CenyMiejscaService.PobierzAlkoholeCompletedEventArgs e)
        {
            listaAlkoholi.Clear();

            if (e.Result != null)
            {
                listaAlkoholi = e.Result;
                listaAlkoholiPosortowana = new ObservableCollection<CenyMiejscaService.Alkohol>(listaAlkoholi.OrderBy(x => x.Nazwa));
                
                lpAlkohole.ItemsSource = listaAlkoholiPosortowana;

                WyliczKosztAlkoholu(tbIloscAlkoholu.Text);
            }
        }




        void cenyMiejscaUsluga_PobierzKursRublaCompleted(object sender, CenyMiejscaService.PobierzKursRublaCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                kursRubla = e.Result;
            }
        }



        void cenyMiejscaUsluga_PobierzKursEuroCompleted(object sender, CenyMiejscaService.PobierzKursEuroCompletedEventArgs e)
        {
            if (e.Result != 0)
            {
                kursEUR = e.Result;
            }
        }
        #endregion



        #region "Eventy SelectionChanged w listpickerach"
        // Zmiana przejścia granicznego
        private void lpPrzejscia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lpPrzejscia.SelectedItem != null)
            {
                string nazwaPrzejscia = lpPrzejscia.SelectedItem.ToString();
                cenyMiejscaUsluga.PobierzStacjeBenzynoweAsync(nazwaPrzejscia);
                cenyMiejscaUsluga.PobierzSklepyAsync(nazwaPrzejscia);
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

                cenyMiejscaUsluga.PobierzDostepnePaliwaAsync(nazwaPrzejscia, nazwaStacji);
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

                cenyMiejscaUsluga.PobierzCenePaliwaAsync(nazwaPrzejscia, nazwaStacji, rodzajPaliwa);
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

                cenyMiejscaUsluga.PobierzPapierosyAsync(nazwaPrzejscia, nazwaSklepu);
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

                cenyMiejscaUsluga.PobierzAlkoholeAsync(nazwaPrzejscia, nazwaSklepu);
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





        private string PobierzLoginZalogowanegoUzytkownika()
        {
            Object login;

            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            login = localSettings.Values["loginUzytkownika"];

            return (string)login;
        }




        



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