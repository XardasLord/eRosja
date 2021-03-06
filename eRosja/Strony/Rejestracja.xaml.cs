﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using eRosja.UzytkownikService;
using System.Security.Cryptography;
using System.Text;

namespace eRosja
{
    public partial class Rejestracja : PhoneApplicationPage
    {
        UzytkownikServiceClient uzytkownikUsluga;

        public Rejestracja()
        {
            InitializeComponent();
            uzytkownikUsluga = new UzytkownikServiceClient();
            uzytkownikUsluga.ZarejestrujUzytkownikaCompleted += uzytkownikUsluga_ZarejestrujUzytkownikaCompleted;
        }




        private void btnZarejestruj_Click(object sender, RoutedEventArgs e)
        {
            pbLadowanie.IsIndeterminate = true;
            bool poprawne = SprawdzDane();

            if (poprawne)
            {
                if(App.SprawdzPolaczenieinternetowe())
                {
                    string login = tbLogin.Text;
                    string haslo = Hash.ZakodujSHA1(tbHaslo.Password);
                    string email = tbEmail.Text;

                    //Wywołanie metody w usłudze WCF - dodanie rekordu do bazy
                    uzytkownikUsluga.ZarejestrujUzytkownikaAsync(login, haslo, email);
                }
                else
                {
                    MessageBox.Show("Do rejestracji wymagane jest połączenie z Internetem.", "Połączenie z Internetem", MessageBoxButton.OK);
                    pbLadowanie.IsIndeterminate = false;
                }

                
            }
        }




        void uzytkownikUsluga_ZarejestrujUzytkownikaCompleted(object sender, ZarejestrujUzytkownikaCompletedEventArgs e)
        {
            if (e.Result == true)
            {
                ZarejestrujUzytkownikaLokalnie();
                pbLadowanie.IsIndeterminate = false;
                NavigationService.Navigate(new Uri("/Strony/StronaStartowa.xaml?param=Zarejestrowano", UriKind.Relative));
            }
            else
            {
                lblInformacja.Text = "Użytkownik o podanym loginie już istnieje";
                pbLadowanie.IsIndeterminate = false;
            }
        }



        private void ZarejestrujUzytkownikaLokalnie()
        {
            string login = tbLogin.Text;
            string haslo = Hash.ZakodujSHA1(tbHaslo.Password);
            string email = tbEmail.Text;

            var uzytkownikSQLite = new SQLiteDB.UzytkownikSQLite();
            uzytkownikSQLite.ZarejestrujUzytkownika(App.DB_PATH, login, haslo, email);
        }



        // Walidacja danych wpisanych przy rejestracji
        private bool SprawdzDane()
        {
            if (tbLogin.Text == "")
            {
                lblInformacja.Text = "Login nie może być pusty!";
                tbLogin.Focus();
                return false;
            }

            if (tbLogin.Text.Count() < 5)
            {
                lblInformacja.Text = "Login musi zawierać przynajmniej 5 znaków!";
                tbLogin.Focus();
                return false;
            }

            if (tbHaslo.Password == "")
            {
                lblInformacja.Text = "Hasło nie może być puste!";
                tbHaslo.Focus();
                return false;
            }

            if (tbHaslo.Password.Count() < 5)
            {
                lblInformacja.Text = "Hasło musi zawierać przynajmniej 5 znaków!";
                tbLogin.Focus();
                return false;
            }

            if (tbHaslo.Password != tbHaslo2.Password)
            {
                lblInformacja.Text = "Wpisane hasła nie są identyczne!";
                return false;
            }

            if (tbEmail.Text == "")
            {
                lblInformacja.Text = "E-mail nie może być pusty!";
                tbEmail.Focus();
                return false;
            }

            // Jeśli wszystkie pola są poprawnie wypełnione
            lblInformacja.Text = "";
            return true;
        }

    }
}