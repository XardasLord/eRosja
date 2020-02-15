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


namespace eRosja
{
    public partial class WyjazdDodaj : PhoneApplicationPage
    {
        CenyMiejscaService.CenyMiejscaServiceClient cenyMiejscaUsluga;
        ObservableCollection<string> listaPrzejsc;
        ObservableCollection<string> listaStacji;
        ObservableCollection<string> listaDostepnychPaliw;
        ObservableCollection<string> listaSklepow;
        ObservableCollection<CenyMiejscaService.PapierosyCeny> listaPapierosow;
        ObservableCollection<CenyMiejscaService.PapierosyCeny> listaPapierosowPosortowana;
        ObservableCollection<CenyMiejscaService.Alkohol> listaAlkoholi;
        string papierosyNazwa;
        string alkoholNazwa;


        // Zmienne potrzebne do pobrania wszystkich danych do dodania wyjazdu
        WyjazdService.Wyjazd daneWyjazdu;
        WyjazdService.Paliwo danePaliwa;
        WyjazdService.Papierosy danePapierosow;
        WyjazdService.Alkohol daneAlkoholu;
      
        string loginUzytkownika, nazwaPrzejscia, nazwaStacji, rodzajPaliwa, sklepPapierosy, sklepAlkohol;
        decimal iloscPaliwa, iloscAlkoholu;
        int iloscPapierosow;
        bool kanal = false;
        bool mandat = false;
        DateTime data;



        public WyjazdDodaj()
        {
            InitializeComponent();

            listaPrzejsc = new ObservableCollection<string>();
            listaStacji = new ObservableCollection<string>();
            listaDostepnychPaliw = new ObservableCollection<string>();
            listaSklepow = new ObservableCollection<string>();
            listaPapierosow = new ObservableCollection<CenyMiejscaService.PapierosyCeny>();
            listaAlkoholi = new ObservableCollection<CenyMiejscaService.Alkohol>();

            daneWyjazdu = new WyjazdService.Wyjazd();
            danePaliwa = new WyjazdService.Paliwo();

            cenyMiejscaUsluga = new CenyMiejscaService.CenyMiejscaServiceClient();
            cenyMiejscaUsluga.PobierzPrzejsciaCompleted += cenyMiejscaUsluga_PobierzPrzejsciaCompleted;
            cenyMiejscaUsluga.PobierzStacjeBenzynoweCompleted += cenyMiejscaUsluga_PobierzStacjeBenzynoweCompleted;
            cenyMiejscaUsluga.PobierzDostepnePaliwaCompleted += cenyMiejscaUsluga_PobierzDostepnePaliwaCompleted;
            cenyMiejscaUsluga.PobierzSklepyCompleted += cenyMiejscaUsluga_PobierzSklepyCompleted;
            cenyMiejscaUsluga.PobierzPapierosyCompleted += cenyMiejscaUsluga_PobierzPapierosyCompleted;
            cenyMiejscaUsluga.PobierzAlkoholeCompleted += cenyMiejscaUsluga_PobierzAlkoholeCompleted;


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
            }
        }

        void cenyMiejscaUsluga_PobierzAlkoholeCompleted(object sender, CenyMiejscaService.PobierzAlkoholeCompletedEventArgs e)
        {
            listaAlkoholi.Clear();

            if (e.Result != null)
            {
                listaAlkoholi = e.Result;

                lpAlkohole.ItemsSource = listaAlkoholi;
            }
        }

        void wyjazdUsluga_DodajWyjazdCompleted(object sender, WyjazdService.DodajWyjazdCompletedEventArgs e)
        {
            if (e.Result == true)
            {
                DodajWyjazdLokalnie();
                MessageBox.Show("Dodano wyjazd!", "Dodano", MessageBoxButton.OK);
                PrzekierujNaStroneGlowna();
            }
            else
            {
                MessageBox.Show("Wystąpił problem przy dodawaniu wyjazdu, spróbuj ponownie", "Błąd", MessageBoxButton.OK);
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
                gridPapierosy.Visibility = System.Windows.Visibility.Collapsed;
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
                gridAlkohol.Visibility = System.Windows.Visibility.Collapsed;
        }
        #endregion



        private string PobierzLoginZalogowanegoUzytkownika()
        {
            Object login;

            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            login = localSettings.Values["loginUzytkownika"];

            return (string)login;
        }

        private void btnDodajWyjazd_Click(object sender, EventArgs e)
        {
            PobierzDaneDoDodaniaWyjazdu();
            DodajWyjazd();
        }

        private void lpPapierosy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                var papierosy = (CenyMiejscaService.PapierosyCeny)e.AddedItems[0];
                papierosyNazwa = papierosy.Nazwa;
            }
        }

        private void lpAlkohole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(e.AddedItems.Count > 0)
            {
                var alkohol = (CenyMiejscaService.Alkohol)e.AddedItems[0];
                alkoholNazwa = alkohol.Nazwa;
            }
        }

        private void DodajWyjazd()
        {
            WyjazdService.WyjazdServiceClient wyjazdUsluga = new WyjazdService.WyjazdServiceClient();
            wyjazdUsluga.DodajWyjazdCompleted += wyjazdUsluga_DodajWyjazdCompleted;

          
            try
            {
                wyjazdUsluga.DodajWyjazdAsync(daneWyjazdu);
                wyjazdUsluga.CloseAsync();
            }
            catch (TimeoutException ex)
            {
                MessageBox.Show(ex.Message, "Przekroczono czas oczekiwania", MessageBoxButton.OK);
                wyjazdUsluga.Abort();
            }
            catch (FaultException ex)
            {
                MessageBox.Show(ex.Message, "Błąd wykonania usługi", MessageBoxButton.OK);
                wyjazdUsluga.Abort();
            }
            catch (CommunicationException ex)
            {
                MessageBox.Show(ex.Message, "Błąd komunikacji", MessageBoxButton.OK);
                wyjazdUsluga.Abort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Błąd", MessageBoxButton.OK);
                wyjazdUsluga.Abort();
            }
        }

        private void DodajWyjazdLokalnie()
        {
            var wyjazdSQLite = new SQLiteDB.WyjazdSQLite();
            wyjazdSQLite.DodajWyjazd(App.DB_PATH, daneWyjazdu);
        }

        private void PobierzDaneDoDodaniaWyjazdu()
        {
            if (cbKanal.IsChecked == true)
                kanal = true;
            if (cbMandat.IsChecked == true)
                mandat = true;

            data = dpData.Value.Value.Add(tpGodzina.Value.Value.TimeOfDay);


            loginUzytkownika = PobierzLoginZalogowanegoUzytkownika();
            nazwaPrzejscia = lpPrzejscia.SelectedItem.ToString();
            nazwaStacji = lpStacje.SelectedItem.ToString();
            rodzajPaliwa = lpPaliwa.SelectedItem.ToString();
            decimal.TryParse(tbIloscPaliwa.Text, out iloscPaliwa);

            // Paliwo
            danePaliwa.Stacja = nazwaStacji;
            danePaliwa.RodzajPaliwa = rodzajPaliwa;
            danePaliwa.IloscPaliwa = iloscPaliwa;

            // Papierosy
            if (cbPapierosy.IsChecked == true)
            {
                danePapierosow = new WyjazdService.Papierosy();
                sklepPapierosy = lpSklepyPapierosy.SelectedItem.ToString();
                int.TryParse(tbIloscPapierosow.Text, out iloscPapierosow);

                danePapierosow.Sklep = sklepPapierosy;
                danePapierosow.Nazwa = papierosyNazwa;
                danePapierosow.Ilosc = iloscPapierosow;
            }
            else
            {
                danePapierosow = null;
            }

            // Alkohol
            if (cbAlkohol.IsChecked == true)
            {
                daneAlkoholu = new WyjazdService.Alkohol();
                sklepAlkohol = lpSklepyAlkohol.SelectedItem.ToString();
                decimal.TryParse(tbIloscAlkoholu.Text, out iloscAlkoholu);

                daneAlkoholu.Sklep = sklepAlkohol;
                daneAlkoholu.Nazwa = alkoholNazwa;
                daneAlkoholu.Ilosc = iloscAlkoholu;
            }
            else
            {
                daneAlkoholu = null;
            }

            // Cały wyjazd
            daneWyjazdu.LoginUzytkownika = loginUzytkownika;
            daneWyjazdu.Przejscie = nazwaPrzejscia;
            daneWyjazdu.Paliwo = danePaliwa;
            daneWyjazdu.Papierosy = danePapierosow;
            daneWyjazdu.Alkohol = daneAlkoholu;
            daneWyjazdu.Data = data;
            daneWyjazdu.Kanal = kanal;
            daneWyjazdu.Mandat = mandat;


        }

        private void PrzekierujNaStroneGlowna()
        {
            Uri uriStronaGlowna = new Uri("/Strony/StronaGlowna.xaml", UriKind.Relative);
            NavigationService.Navigate(uriStronaGlowna);
        }

       

        
    }
}