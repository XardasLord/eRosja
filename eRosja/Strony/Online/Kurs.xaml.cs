using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.ServiceModel;

namespace eRosja
{
    public partial class Kurs : PhoneApplicationPage
    {
        CenyMiejscaService.CenyMiejscaServiceClient cenyMiejscaUsluga;
        SQLiteDB.CenyMiejscaSQLite cenyMiejscaSQLite;
        Dictionary<DateTime, decimal> kurs;
        Dictionary<DateTime, decimal> kursOffline;


        public Kurs()
        {
            InitializeComponent();

            kurs = new Dictionary<DateTime, decimal>();

            cenyMiejscaUsluga = new CenyMiejscaService.CenyMiejscaServiceClient();
            cenyMiejscaUsluga.PobierzKursRublaCompleted += cenyMiejscaUsluga_PobierzKursRublaCompleted;

            cenyMiejscaUsluga.PobierzKursRublaAsync();

            cenyMiejscaSQLite = new SQLiteDB.CenyMiejscaSQLite();
            kursOffline = cenyMiejscaSQLite.PobierzKursRubla(App.DB_PATH);

        }



        void cenyMiejscaUsluga_PobierzKursRublaCompleted(object sender, CenyMiejscaService.PobierzKursRublaCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Błąd połączenia z serwerem");
                PrzekierujNaStroneGlowna();
            }
            else
            {
                pbLadowanie.IsIndeterminate = false;

                if (e.Result != null)
                {
                    kurs = e.Result;

                    foreach (DateTime data in kurs.Keys)
                        tbData.Text = data.ToString();

                    foreach (double rubel in kurs.Values)
                        tbKurs.Text = rubel.ToString();


                    bool takieSame = PorownajKursy();

                    if(!takieSame)
                    {
                        cenyMiejscaSQLite.UaktualnijKursRubla(App.DB_PATH, kurs, kursOffline);
                    }
                }
            }
        }



        private bool PorownajKursy()
        {
            if (kurs.SequenceEqual(kursOffline))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private void PrzekierujNaStroneGlowna()
        {
            Uri uriStronaGlowna = new Uri("/Strony/StronaGlowna.xaml", UriKind.Relative);
            NavigationService.Navigate(uriStronaGlowna);
        }
    }
}