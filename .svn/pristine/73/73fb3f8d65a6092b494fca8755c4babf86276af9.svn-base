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

namespace eRosja
{
    public partial class Ceny : PhoneApplicationPage
    {
        CenyMiejscaService.CenyMiejscaServiceClient cenyMiejscaUsluga;
        ObservableCollection<string> listaPrzejsc;
        ObservableCollection<string> listaStacji;
        ObservableCollection<string> listaPaliw;
        ObservableCollection<string> listaSklepow;
        ObservableCollection<CenyMiejscaService.PapierosyCeny> listaPapierosow;
        ObservableCollection<CenyMiejscaService.PapierosyCeny> listaPapierosowPosortowana;
        Dictionary<int, decimal> cenyPaliw, cenyPaliwWszystkieOnline, cenyPapierosowWszystkieOnlinePakiet, cenyPapierosowWszystkieOnlinePaczka;
        Dictionary<long, decimal> cenyPaliwWszystkieOffline, cenyPaliwRoznice, cenyPapierosowWszystkieOfflinePakiet, cenyPapierosowWszystkieOfflinePaczka, cenyPapierosowRoznicePakiet, cenyPapierosowRoznicePaczka;
        Dictionary<DateTime, decimal> kursRubla;
        decimal kursEUR;
        


        public Ceny()
        {
            InitializeComponent();

            listaPrzejsc = new ObservableCollection<string>();
            listaStacji = new ObservableCollection<string>();
            listaPaliw = new ObservableCollection<string>();
            listaSklepow = new ObservableCollection<string>();
            listaPapierosow = new ObservableCollection<CenyMiejscaService.PapierosyCeny>();
            cenyPaliw = new Dictionary<int, decimal>();
            cenyPaliwWszystkieOnline = new Dictionary<int, decimal>();
            cenyPaliwWszystkieOffline = new Dictionary<long, decimal>();
            cenyPapierosowWszystkieOnlinePakiet = new Dictionary<int, decimal>();
            cenyPapierosowWszystkieOnlinePaczka = new Dictionary<int, decimal>();
            cenyPapierosowWszystkieOfflinePaczka = new Dictionary<long, decimal>();
            cenyPapierosowWszystkieOfflinePakiet = new Dictionary<long, decimal>();
            cenyPaliwRoznice = new Dictionary<long, decimal>();
            cenyPapierosowRoznicePakiet = new Dictionary<long, decimal>();
            cenyPapierosowRoznicePaczka = new Dictionary<long, decimal>();
            kursRubla = new Dictionary<DateTime, decimal>();
            cenyMiejscaUsluga = new CenyMiejscaService.CenyMiejscaServiceClient();
            cenyMiejscaUsluga.PobierzPrzejsciaCompleted += cenyMiejscaUsluga_PobierzPrzejsciaCompleted;
            cenyMiejscaUsluga.PobierzStacjeBenzynoweCompleted += cenyMiejscaUsluga_PobierzStacjeBenzynoweCompleted;
            cenyMiejscaUsluga.PobierzNazwyPaliwCompleted += cenyMiejscaUsluga_PobierzNazwyPaliwCompleted;
            cenyMiejscaUsluga.PobierzCenyPaliwCompleted += cenyMiejscaUsluga_PobierzCenyPaliwCompleted;
            cenyMiejscaUsluga.PobierzSklepyCompleted += cenyMiejscaUsluga_PobierzSklepyCompleted;
            cenyMiejscaUsluga.PobierzPapierosyCompleted += cenyMiejscaUsluga_PobierzPapierosyCompleted;
            cenyMiejscaUsluga.PobierzKursRublaCompleted += cenyMiejscaUsluga_PobierzKursRublaCompleted;
            cenyMiejscaUsluga.PobierzKursEuroCompleted += cenyMiejscaUsluga_PobierzKursEuroCompleted;
            cenyMiejscaUsluga.PobierzCenyPaliwWszystkieCompleted += cenyMiejscaUsluga_PobierzCenyPaliwWszystkieCompleted;
            cenyMiejscaUsluga.PobierzCenyPapierosowWszystkiePakietCompleted += cenyMiejscaUsluga_PobierzCenyPapierosowWszystkiePakietCompleted;
            cenyMiejscaUsluga.PobierzCenyPapierosowWszystkiePaczkaCompleted += cenyMiejscaUsluga_PobierzCenyPapierosowWszystkiePaczkaCompleted;



            //cenyMiejscaUsluga.PobierzKursRublaAsync();
            //cenyMiejscaUsluga.PobierzKursEuroAsync();
            cenyMiejscaUsluga.PobierzPrzejsciaAsync();
            
        }





        private void WpiszCenyPapierosow(CenyMiejscaService.PapierosyCeny papierosy)
        {
            double kursRUB = 0;

            foreach (double rubel in kursRubla.Values)
                kursRUB = rubel;


            if (papierosy.CenaPakiet != null)
            {
                tbEuroPakiet.Text = papierosy.CenaPakiet.ToString();
                if (kursRUB != 0)
                    tbRubPakiet.Text = Math.Round(((decimal)papierosy.CenaPakiet * (decimal)kursEUR / (decimal)kursRUB), 2).ToString();
                tbPlnPakiet.Text = Math.Round(((decimal)papierosy.CenaPakiet * (decimal)kursEUR), 2).ToString();

            }

            if (papierosy.CenaPaczka != null)
            {
                tbEuroPaczka.Text = papierosy.CenaPaczka.ToString();
                if (kursRUB != 0)
                    tbRubPaczka.Text = Math.Round(((decimal)papierosy.CenaPaczka * (decimal)kursEUR / (decimal)kursRUB), 2).ToString();
                tbPlnPaczka.Text = Math.Round(((decimal)papierosy.CenaPaczka * (decimal)kursEUR), 2).ToString();
            }

        }

        private void UstawNazwyPaliw()
        {
            TextBlock tb = new TextBlock();

            for (int i = 1; i <= listaPaliw.Count; i++)
            {
                // Przechodzimy przez każdą kontrolkę o nazwie 'tbPaliwo1, tbPaliwo2...' 
                // i ustawiamy jej tekst na nazwę paliwa pobranego z bazy
                object kontrolka = LayoutRoot.FindName("tbPaliwo" + i);
                tb = (TextBlock)kontrolka;
                tb.Text = listaPaliw.ElementAt(i - 1).ToString();
            }
        }

        private void UstawCenyPaliw()
        {
            TextBlock tb = new TextBlock();

            for (int i = 1; i <= listaPaliw.Count; i++)
            {
                foreach (long id_paliwa in cenyPaliw.Keys)
                {
                    if (id_paliwa == i)
                    {
                        object kontrolka = LayoutRoot.FindName("tbCena" + i);
                        tb = (TextBlock)kontrolka;
                        tb.Text = cenyPaliw.FirstOrDefault(x => x.Key == i).Value.ToString();
                    }
                }
            }
        }

        private void ZerujCenyPaliw()
        {
            TextBlock tb = new TextBlock();

            for (int i = 1; i <= listaPaliw.Count; i++)
            {
                object kontrolka = LayoutRoot.FindName("tbCena" + i);
                tb = (TextBlock)kontrolka;
                tb.Text = "";
            }
        }

        private void ZerujCenyPapierosow()
        {
            tbEuroPakiet.Text = "";
            tbEuroPaczka.Text = "";
            tbRubPakiet.Text = "";
            tbRubPaczka.Text = "";
            tbPlnPakiet.Text = "";
            tbPlnPaczka.Text = "";
        }

        // Paliwo
        private void PobierzCenyPaliwOnLine()
        {
            cenyMiejscaUsluga.PobierzCenyPaliwWszystkieAsync();
        }

        private void PobierzCenyPaliwOffLine()
        {
            var cenyMiejscaSQLite = new SQLiteDB.CenyMiejscaSQLite();
            cenyPaliwWszystkieOffline = cenyMiejscaSQLite.PobierzCenyPaliwWszystkie(App.DB_PATH);
        }

        private void PorownajCenyPaliw()
        {
            foreach(var cenaOnline in cenyPaliwWszystkieOnline)
            {
                if(cenyPaliwWszystkieOffline[(long)cenaOnline.Key] != cenaOnline.Value)
                {
                    cenyPaliwRoznice.Add((long)cenaOnline.Key, cenaOnline.Value);
                }
            }
        }

        private void UaktualnijCenyPaliwLokalnie()
        {
            var cenyMiejscaSQLite = new SQLiteDB.CenyMiejscaSQLite();
            cenyMiejscaSQLite.UaktualnijCenyPaliw(App.DB_PATH, cenyPaliwRoznice);
        }

        // Papierosy - pakiet
        private void PobierzCenyPapierosowOnLinePakiet()
        {
            cenyMiejscaUsluga.PobierzCenyPapierosowWszystkiePakietAsync();
        }

        private void PobierzCenyPapierosowOffLinePakiet()
        {
            var cenyMiejscaSQLite = new SQLiteDB.CenyMiejscaSQLite();
            cenyPapierosowWszystkieOfflinePakiet = cenyMiejscaSQLite.PobierzCenyPapierosowWszystkiePakiet(App.DB_PATH);
        }

        private void PorownajCenyPapierosowPakiet()
        {
            foreach (var cenaOnline in cenyPapierosowWszystkieOnlinePakiet)
            {
                if (cenyPapierosowWszystkieOfflinePakiet[(long)cenaOnline.Key] != cenaOnline.Value)
                {
                    cenyPapierosowRoznicePakiet.Add((long)cenaOnline.Key, cenaOnline.Value);
                }
            }
        }

        private void UaktualnijCenyPapierosowLokalniePakiet()
        {
            var cenyMiejscaSQLite = new SQLiteDB.CenyMiejscaSQLite();
            cenyMiejscaSQLite.UaktualnijCenyPapierosowPakiet(App.DB_PATH, cenyPapierosowRoznicePakiet);
        }

        // Papierosy - paczka
        private void PobierzCenyPapierosowOnLinePaczka()
        {
            cenyMiejscaUsluga.PobierzCenyPapierosowWszystkiePaczkaAsync();
        }

        private void PobierzCenyPapierosowOffLinePaczka()
        {
            var cenyMiejscaSQLite = new SQLiteDB.CenyMiejscaSQLite();
            cenyPapierosowWszystkieOfflinePaczka = cenyMiejscaSQLite.PobierzCenyPapierosowWszystkiePaczka(App.DB_PATH);
        }

        private void PorownajCenyPapierosowPaczka()
        {
            foreach (var cenaOnline in cenyPapierosowWszystkieOnlinePaczka)
            {
                try
                {
                    if (cenyPapierosowWszystkieOfflinePaczka[(long)cenaOnline.Key] != cenaOnline.Value)
                    {
                        cenyPapierosowRoznicePaczka.Add((long)cenaOnline.Key, cenaOnline.Value);
                    }
                }
                catch { }               
            }
        }

        private void UaktualnijCenyPapierosowLokalniePaczka()
        {
            var cenyMiejscaSQLite = new SQLiteDB.CenyMiejscaSQLite();
            cenyMiejscaSQLite.UaktualnijCenyPapierosowPaczka(App.DB_PATH, cenyPapierosowRoznicePaczka);
        }

        private void PrzekierujNaStroneGlowna()
        {
            Uri uriStronaGlowna = new Uri("/Strony/StronaGlowna.xaml", UriKind.Relative);
            NavigationService.Navigate(uriStronaGlowna);
        }


        
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

                pbLadowanie.IsIndeterminate = false;
                listaPrzejsc.Clear();

                // Wypełniamy ListPickera przejściami granicznymi
                listaPrzejsc = e.Result;
                lpPrzejsciaPaliwo.ItemsSource = listaPrzejsc;
                lpPrzejsciaPapierosy.ItemsSource = listaPrzejsc;
            }
        }

        void cenyMiejscaUsluga_PobierzStacjeBenzynoweCompleted(object sender, CenyMiejscaService.PobierzStacjeBenzynoweCompletedEventArgs e)
        {
            listaStacji.Clear();

            if (e.Result != null)
            {
                // Wypełniamy ListPickera stacjami benzynowymi
                listaStacji = e.Result;
                lpStacjePaliwo.ItemsSource = listaStacji;
            }
        }

        void cenyMiejscaUsluga_PobierzNazwyPaliwCompleted(object sender, CenyMiejscaService.PobierzNazwyPaliwCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                listaPaliw = e.Result;

                UstawNazwyPaliw();
            }
        }

        void cenyMiejscaUsluga_PobierzCenyPaliwCompleted(object sender, CenyMiejscaService.PobierzCenyPaliwCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                // Pobieramy ceny paliw do słownika
                cenyPaliw = e.Result;

                ZerujCenyPaliw();
                UstawCenyPaliw();
                PobierzCenyPaliwOnLine();
            }
        }

        void cenyMiejscaUsluga_PobierzSklepyCompleted(object sender, CenyMiejscaService.PobierzSklepyCompletedEventArgs e)
        {
            listaSklepow.Clear();

            if (e.Result != null)
            {
                // Pobieramy ceny paliw do słownika
                listaSklepow = e.Result;

                lpSklepyPapierosy.ItemsSource = listaSklepow;
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
                PobierzCenyPapierosowOnLinePakiet();
                PobierzCenyPapierosowOnLinePaczka();


                if(listaPapierosowPosortowana.Count == 0)
                {
                    ZerujCenyPapierosow();
                }
            }
        }

        void cenyMiejscaUsluga_PobierzKursRublaCompleted(object sender, CenyMiejscaService.PobierzKursRublaCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Błąd połączenia z serwerem");
                PrzekierujNaStroneGlowna();
            }
            else if (e.Result != null)
            {
                kursRubla = e.Result;
            }
        }

        void cenyMiejscaUsluga_PobierzKursEuroCompleted(object sender, CenyMiejscaService.PobierzKursEuroCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Błąd połączenia z serwerem");
                PrzekierujNaStroneGlowna();
            }
            else if (e.Result != 0)
            {
                kursEUR = e.Result;
            }
        }

        void cenyMiejscaUsluga_PobierzCenyPaliwWszystkieCompleted(object sender, CenyMiejscaService.PobierzCenyPaliwWszystkieCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                cenyPaliwWszystkieOnline = e.Result;
                PobierzCenyPaliwOffLine();
                PorownajCenyPaliw();
                if (cenyPaliwRoznice.Count > 0)
                {
                    UaktualnijCenyPaliwLokalnie();
                }
            }
        }

        void cenyMiejscaUsluga_PobierzCenyPapierosowWszystkiePakietCompleted(object sender, CenyMiejscaService.PobierzCenyPapierosowWszystkiePakietCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                cenyPapierosowWszystkieOnlinePakiet = e.Result;
                PobierzCenyPapierosowOffLinePakiet();
                PorownajCenyPapierosowPakiet();
                if (cenyPapierosowRoznicePakiet.Count > 0)
                {
                    UaktualnijCenyPapierosowLokalniePakiet();
                }
                
            }
        }

        void cenyMiejscaUsluga_PobierzCenyPapierosowWszystkiePaczkaCompleted(object sender, CenyMiejscaService.PobierzCenyPapierosowWszystkiePaczkaCompletedEventArgs e)
        {
            if (e.Result != null)
            {
                cenyPapierosowWszystkieOnlinePaczka = e.Result;
                PobierzCenyPapierosowOffLinePaczka();
                PorownajCenyPapierosowPaczka();
                if (cenyPapierosowRoznicePaczka.Count > 0)
                {
                    UaktualnijCenyPapierosowLokalniePaczka();
                }
            }
        }



        // Zmiana przejścia granicznego przy PALIWIE
        private void lpPrzejscia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lpPrzejsciaPaliwo.SelectedItem != null)
            {
                string nazwaPrzejscia = lpPrzejsciaPaliwo.SelectedItem.ToString();
                cenyMiejscaUsluga.PobierzStacjeBenzynoweAsync(nazwaPrzejscia);
            }          
        }

        // Zmiana stacji benzynowej przy PALIWIE
        private void lpStacje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lpStacjePaliwo.SelectedItem != null)
            {
                string nazwaPrzejscia, nazwaStacji;

                nazwaPrzejscia = lpPrzejsciaPaliwo.SelectedItem.ToString();
                nazwaStacji = lpStacjePaliwo.SelectedItem.ToString();
                tbNazwaStacji.Text = nazwaStacji;

                cenyMiejscaUsluga.PobierzNazwyPaliwAsync();
                cenyMiejscaUsluga.PobierzCenyPaliwAsync(nazwaPrzejscia, nazwaStacji);
            }   
        }

        // Zmiana przejścia granicznego przy PAPIEROSACH
        private void lpPrzejsciaPapierosy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lpPrzejsciaPapierosy.SelectedItem != null)
            {
                string nazwaPrzejscia = lpPrzejsciaPapierosy.SelectedItem.ToString();
                cenyMiejscaUsluga.PobierzSklepyAsync(nazwaPrzejscia);
            } 
        }

        // Zmiana sklepu przy PAPIEROSACH
        private void lpSklepy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lpSklepyPapierosy.SelectedItem != null)
            {
                string nazwaPrzejscia, nazwaSklepu;

                nazwaPrzejscia = lpPrzejsciaPapierosy.SelectedItem.ToString();
                nazwaSklepu = lpSklepyPapierosy.SelectedItem.ToString();

                cenyMiejscaUsluga.PobierzPapierosyAsync(nazwaPrzejscia, nazwaSklepu);
            }
        }

        // Wybranie papierosa
        private void lpPapierosy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                var papierosy = (CenyMiejscaService.PapierosyCeny)e.AddedItems[0];

                ZerujCenyPapierosow();
                WpiszCenyPapierosow(papierosy);
            }          
        }

    }
}