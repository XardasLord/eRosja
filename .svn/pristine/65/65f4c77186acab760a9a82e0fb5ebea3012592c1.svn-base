using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using eRosja.Resources;


namespace eRosja
{
    public partial class StronaStartowa : PhoneApplicationPage
    {
        UzytkownikService.UzytkownikServiceClient uzytkownikUsluga;


        public StronaStartowa()
        {
            InitializeComponent();
            uzytkownikUsluga = new UzytkownikService.UzytkownikServiceClient();
            uzytkownikUsluga.ZalogujUzytkownikaCompleted += uzytkownikUsluga_ZalogujUzytkownikaCompleted;
        }



        private void btnZarejestruj_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Strony/Rejestracja.xaml", UriKind.Relative));
        }



        private void btnZaloguj_Click(object sender, RoutedEventArgs e)
        {
            pbLadowanie.IsIndeterminate = true;

            if(App.SprawdzPolaczenieinternetowe())
            {
                string login = tbLogin.Text;
                string haslo = Hash.ZakodujSHA1(tbHaslo.Password);
                
                uzytkownikUsluga.ZalogujUzytkownikaAsync(login, haslo);
            }
            else
            {
                ZalogujUzytkownikaLokalnie();
            }
            
        }



        private void ZalogujUzytkownikaLokalnie()
        {
            string login = tbLogin.Text;
            string haslo = Hash.ZakodujSHA1(tbHaslo.Password);

            var uzytkownikSQLite = new SQLiteDB.UzytkownikSQLite();
            bool zalogowano = uzytkownikSQLite.ZalogujUzytkownika(App.DB_PATH, login, haslo);

            pbLadowanie.IsIndeterminate = false;

            if(zalogowano)
            {
                var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

                if (localSettings.Values.ContainsKey("loginUzytkownika"))
                    localSettings.Values.Remove("loginUzytkownika");

                localSettings.Values.Add("loginUzytkownika", login);

                MessageBox.Show("Zalogowano pomyślnie", "Logowanie", MessageBoxButton.OK);
                NavigationService.Navigate(new Uri("/Strony/StronaGlowna.xaml", UriKind.Relative));
            }
            else
            {
                MessageBox.Show("Błędne dane podczas logowania", "Logowanie", MessageBoxButton.OK);
            }
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("param"))
            {
                string info = NavigationContext.QueryString["param"];
                lblInformacja.Text = info + " pomyślnie!";
            }
        }



        void uzytkownikUsluga_ZalogujUzytkownikaCompleted(object sender, UzytkownikService.ZalogujUzytkownikaCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Błąd połączenia z serwerem");
                pbLadowanie.IsIndeterminate = false;
            }
            else
            {
                pbLadowanie.IsIndeterminate = false;
                bool istnieje = e.Result;

                if (istnieje)
                {
                    string login = tbLogin.Text;

                    var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

                    if (localSettings.Values.ContainsKey("loginUzytkownika"))
                        localSettings.Values.Remove("loginUzytkownika");

                    localSettings.Values.Add("loginUzytkownika", login);

                    MessageBox.Show("Zalogowano pomyślnie", "Logowanie", MessageBoxButton.OK);
                    NavigationService.Navigate(new Uri("/Strony/StronaGlowna.xaml", UriKind.Relative));
                }
                else
                {
                    MessageBox.Show("Błędne dane podczas logowania", "Logowanie", MessageBoxButton.OK);
                }
            }         
        }




        // Sprawdzenie połączenia internetowego
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            //bool polaczenie = ((App)Application.Current).SprawdzPolaczenieinternetowe();

            //if (polaczenie == false)
            //{
            //    MessageBox.Show("Do działania aplikacji wymagane jest połączenie z internetem", "Brak internetu", MessageBoxButton.OK);
            //    Application.Current.Terminate();
            //}           
        }    
  


    }
}