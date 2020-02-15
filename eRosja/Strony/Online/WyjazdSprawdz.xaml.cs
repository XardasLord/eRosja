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
using eRosja.WyjazdService;
using System.Windows.Media;

namespace eRosja
{
    public partial class WyjazdSprawdz : PhoneApplicationPage
    {
        ObservableCollection<WyjazdService.Wyjazd> listaWyjazdow;
        ObservableCollection<WyjazdService.Wyjazd> listaWyjazdowPosortowana;
        WyjazdService.WyjazdServiceClient wyjazdUsluga;


        public WyjazdSprawdz()
        {
            InitializeComponent();

            listaWyjazdow = new ObservableCollection<WyjazdService.Wyjazd>();
            wyjazdUsluga = new WyjazdService.WyjazdServiceClient();
            wyjazdUsluga.PobierzWyjazdyCompleted += wyjazdUsluga_PobierzWyjazdyCompleted;


            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            string login = localSettings.Values["loginUzytkownika"].ToString();

            wyjazdUsluga.PobierzWyjazdyAsync(login);
        }





        void wyjazdUsluga_PobierzWyjazdyCompleted(object sender, WyjazdService.PobierzWyjazdyCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Błąd połączenia z serwerem");
                PrzekierujNaStroneGlowna();
            }
            else if (e.Result != null)
            {
                pbLadowanie.IsIndeterminate = false;

                listaWyjazdow = e.Result;

                // Sortujemy wg daty i godziny
                listaWyjazdowPosortowana = new ObservableCollection<WyjazdService.Wyjazd>(listaWyjazdow.OrderByDescending(x => x.Data.Date));
                llsWyjazdy.ItemsSource = listaWyjazdowPosortowana;
                tbIloscWyjazdow.Text = listaWyjazdowPosortowana.Count.ToString();
            }
        }



        // Wybranie jakiegoś wyjazdu
        private void llsWyjazdy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Pobranie zaznaczonego wyjazdu
                var wyjazd = (WyjazdService.Wyjazd)e.AddedItems[0];

                WyczyscInformacjeOWyjezdzie();
                WyswietlInformacjeOWyjezdzie(wyjazd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }        
        }




        private void WyswietlInformacjeOWyjezdzie(Wyjazd wyjazd)
        {
            tbPrzejscie.Text = wyjazd.Przejscie;
            tbStacja.Text = wyjazd.Paliwo.Stacja;
            tbPaliwo.Text = wyjazd.Paliwo.RodzajPaliwa;
            tbIloscPaliwa.Text = wyjazd.Paliwo.IloscPaliwa.ToString();
            if (wyjazd.Papierosy != null)
            {
                tbSklepPapierosy.Text = wyjazd.Papierosy.Sklep;
                tbPapierosy.Text = wyjazd.Papierosy.Nazwa;
                tbIloscPapierosow.Text = wyjazd.Papierosy.Ilosc.ToString();
            }
            if(wyjazd.Alkohol != null)
            {
                tbSklepAlkohol.Text = wyjazd.Alkohol.Sklep;
                tbAlkohol.Text = wyjazd.Alkohol.Nazwa;
                tbIloscAlkoholu.Text = wyjazd.Alkohol.Ilosc.ToString();
            }
            tbData.Text = wyjazd.Data.ToShortDateString();
            tbGodzina.Text = wyjazd.Data.TimeOfDay.ToString();
            if (wyjazd.Kanal == true)
                tbKanal.Text = "*";
            if (wyjazd.Mandat == true)
                tbMandat.Text = "*";
        }


        private void WyczyscInformacjeOWyjezdzie()
        {
            tbPrzejscie.Text = "";
            tbStacja.Text = "";
            tbPaliwo.Text = "";
            tbIloscPaliwa.Text = "";
            tbSklepPapierosy.Text = "";
            tbPapierosy.Text = "";
            tbIloscPapierosow.Text = "";
            tbSklepAlkohol.Text = "";
            tbAlkohol.Text = "";
            tbIloscAlkoholu.Text = "";
            tbData.Text = "";
            tbGodzina.Text = "";
            tbKanal.Text = "";
            tbMandat.Text = "";
        }



        private void PrzekierujNaStroneGlowna()
        {
            Uri uriStronaGlowna = new Uri("/Strony/StronaGlowna.xaml", UriKind.Relative);
            NavigationService.Navigate(uriStronaGlowna);
        }



    }
}