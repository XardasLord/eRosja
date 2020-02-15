using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using eRosja.WyjazdService;

namespace eRosja.Strony.Offline
{
    public partial class WyjazdSprawdzOffline : PhoneApplicationPage
    {
        List<Wyjazd> listaWyjazdow;
        List<Wyjazd> listaWyjazdowPosortowana;


        public WyjazdSprawdzOffline()
        {
            InitializeComponent();

            SQLiteDB.WyjazdSQLite wyjazdSQLite = new SQLiteDB.WyjazdSQLite();
            listaWyjazdow = new List<Wyjazd>();

            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            string login = localSettings.Values["loginUzytkownika"].ToString();


            listaWyjazdow = wyjazdSQLite.PobierzWyjazdy(App.DB_PATH, login);
            WypiszWyjazdy();
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



        private void WypiszWyjazdy()
        {
            // Sortujemy wg daty i godziny
            listaWyjazdowPosortowana = new List<Wyjazd>(listaWyjazdow.OrderByDescending(x => x.Data.Date));
            llsWyjazdy.ItemsSource = listaWyjazdowPosortowana;
            tbIloscWyjazdow.Text = listaWyjazdowPosortowana.Count.ToString();

            pbLadowanie.IsIndeterminate = false;
        }



        private void PrzekierujNaStroneGlowna()
        {
            Uri uriStronaGlowna = new Uri("/Strony/StronaGlowna.xaml", UriKind.Relative);
            NavigationService.Navigate(uriStronaGlowna);
        }



    }
}