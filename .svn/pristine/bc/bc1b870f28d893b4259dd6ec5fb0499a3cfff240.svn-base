using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace eRosja
{
    public partial class Zmiany : PhoneApplicationPage
    {
        ZmianyService.ZmianyServiceClient zmianyUsluga = new ZmianyService.ZmianyServiceClient();

        public Zmiany()
        {
            InitializeComponent();
            zmianyUsluga.PobierzZmianeCompleted += zmianyUsluga_PobierzZmianeCompleted;

            zmianyUsluga.PobierzZmianeAsync(kalendarz.SelectedDate);
        }




        void zmianyUsluga_PobierzZmianeCompleted(object sender, ZmianyService.PobierzZmianeCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Błąd połączenia z serwerem");
                PrzekierujNaStroneGlowna();
            }
            else
            {
                pbLadowanie.IsIndeterminate = false;

                var zmiany = e.Result;

                tbDzien.Text = zmiany.m_Item1;
                tbNoc.Text = zmiany.m_Item2;
                lblData.Text = "Zmiany na dzień: " + kalendarz.SelectedDate.ToShortDateString();
            }
        }





        private void kalendarz_DateClicked(object sender, WPControls.SelectionChangedEventArgs e)
        {
            zmianyUsluga.PobierzZmianeAsync(e.SelectedDate);
            pbLadowanie.IsIndeterminate = true;
        }



        private void PrzekierujNaStroneGlowna()
        {
            Uri uriStronaGlowna = new Uri("/Strony/StronaGlowna.xaml", UriKind.Relative);
            NavigationService.Navigate(uriStronaGlowna);
        }
    }
}