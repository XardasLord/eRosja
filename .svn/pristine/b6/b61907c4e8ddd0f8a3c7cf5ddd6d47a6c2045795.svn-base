using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

// Potrzebne do SQLite
using SQLite;
using Windows.Storage;
using System.IO;
using Sqlite;
using System.Data.Linq;

namespace eRosja
{
    public partial class StronaGlowna : PhoneApplicationPage
    {

        public StronaGlowna()
        {
            InitializeComponent();
        }


        private void btnSprawdzCeny_Click(object sender, RoutedEventArgs e)
        {
            if(App.SprawdzPolaczenieinternetowe())
            {
                Uri uriCeny = new Uri("/Strony/Online/Ceny.xaml", UriKind.Relative);
                NavigationService.Navigate(uriCeny);
            }
            else
            {
                Uri uriCeny = new Uri("/Strony/Offline/CenyOffline.xaml", UriKind.Relative);
                NavigationService.Navigate(uriCeny);
            }
          
        }


        private void btnSprawdzKurs_Click(object sender, RoutedEventArgs e)
        {
            if(App.SprawdzPolaczenieinternetowe())
            {
                Uri uriKurs = new Uri("/Strony/Online/Kurs.xaml", UriKind.Relative);
                NavigationService.Navigate(uriKurs);
            }
            else
            {
                Uri uriKurs = new Uri("/Strony/Offline/KursOffline.xaml", UriKind.Relative);
                NavigationService.Navigate(uriKurs);
            }
        }



        private void btnDodajWyjazd_Click(object sender, RoutedEventArgs e)
        {
            if(App.SprawdzPolaczenieinternetowe())
            {
                Uri uriWyjazdDodaj = new Uri("/Strony/Online/WyjazdDodaj.xaml", UriKind.Relative);
                NavigationService.Navigate(uriWyjazdDodaj);
            }    
            else
            {
                Uri uriWyjazdDodaj = new Uri("/Strony/Offline/WyjazdDodajOffline.xaml", UriKind.Relative);
                NavigationService.Navigate(uriWyjazdDodaj);
            }
        }




        private void btnWyloguj_Click(object sender, EventArgs e)
        {
            // Przy wylogowaniu kasujemy ze zmiennych aplikacji informację o zalogowanym użytkowniku
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values.Remove("loginUzytkownika");

            // Przechodzimy na stronę logowania
            Uri uriWyloguj = new Uri("/Strony/StronaStartowa.xaml", UriKind.Relative);
            NavigationService.Navigate(uriWyloguj);
        }




        private void btnSprawdzWyjazd_Click(object sender, RoutedEventArgs e)
        {
            if(App.SprawdzPolaczenieinternetowe())
            {
                Uri uriWyjazdSprawdz = new Uri("/Strony/Online/WyjazdSprawdz.xaml", UriKind.Relative);
                NavigationService.Navigate(uriWyjazdSprawdz);
            }    
            else
            {
                Uri uriWyjazdSprawdz = new Uri("/Strony/Offline/WyjazdSprawdzOffline.xaml", UriKind.Relative);
                NavigationService.Navigate(uriWyjazdSprawdz);
            }
        }



        private void btnSprawdzKoszt_Click(object sender, RoutedEventArgs e)
        {
            if(App.SprawdzPolaczenieinternetowe())
            {
                Uri uriKoszty = new Uri("/Strony/Online/Koszty.xaml", UriKind.Relative);
                NavigationService.Navigate(uriKoszty);
            }
            else
            {
                Uri uriKoszty = new Uri("/Strony/Offline/KosztyOffline.xaml", UriKind.Relative);
                NavigationService.Navigate(uriKoszty);
            }
        }


        private void btnSprawdzZmiany_Click(object sender, RoutedEventArgs e)
        {
            if(App.SprawdzPolaczenieinternetowe())
            {
                Uri uriZmiany = new Uri("/Strony/Online/Zmiany.xaml", UriKind.Relative);
                NavigationService.Navigate(uriZmiany);
            }
            else
            {
                Uri uriZmiany = new Uri("/Strony/Offline/ZmianyOffline.xaml", UriKind.Relative);
                NavigationService.Navigate(uriZmiany);
            }
        }
    }
}