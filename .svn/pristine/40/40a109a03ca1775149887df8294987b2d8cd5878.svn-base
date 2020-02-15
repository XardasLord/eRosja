using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace eRosja.Strony.Offline
{
    public partial class ZmianyOffline : PhoneApplicationPage
    {
        Tuple<string, string> zmiany;
        

        public ZmianyOffline()
        {
            InitializeComponent();

            var zmianySQLite = new eRosja.SQLiteDB.ZmianySQLite();
            zmiany = zmianySQLite.PobierzZmiane(App.DB_PATH, DateTime.Now);
            UstawZmianyPIERWSZYRAZ();
        }




        private void UstawZmiany()
        {
            pbLadowanie.IsIndeterminate = false;

            tbDzien.Text = zmiany.Item1;
            tbNoc.Text = zmiany.Item2;
            lblData.Text = "Zmiany na dzień: " + kalendarz.SelectedDate.ToShortDateString();
        }



        private void UstawZmianyPIERWSZYRAZ()
        {
            pbLadowanie.IsIndeterminate = false;

            tbDzien.Text = zmiany.Item1;
            tbNoc.Text = zmiany.Item2;
            lblData.Text = "Zmiany na dzień: " + DateTime.Now.ToShortDateString();
        }






        private void kalendarz_DateClicked(object sender, WPControls.SelectionChangedEventArgs e)
        {
            pbLadowanie.IsIndeterminate = true;

            var zmianySQLite = new eRosja.SQLiteDB.ZmianySQLite();
            zmiany = zmianySQLite.PobierzZmiane(App.DB_PATH, e.SelectedDate);
            UstawZmiany();          
        }



        private void PrzekierujNaStroneGlowna()
        {
            Uri uriStronaGlowna = new Uri("/Strony/StronaGlowna.xaml", UriKind.Relative);
            NavigationService.Navigate(uriStronaGlowna);
        }
    }
}