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
    public partial class KursOffline : PhoneApplicationPage
    {
        Dictionary<DateTime, decimal> kursRubla = new Dictionary<DateTime, decimal>();


        public KursOffline()
        {
            InitializeComponent();

            var CenyMiejscaSQLite = new eRosja.SQLiteDB.CenyMiejscaSQLite();
            kursRubla = CenyMiejscaSQLite.PobierzKursRubla(App.DB_PATH);
            UstawKursRubla();
        }



        private void UstawKursRubla()
        {
            pbLadowanie.IsIndeterminate = false;

            foreach (DateTime data in kursRubla.Keys)
                tbData.Text = data.ToString();

            foreach (double rubel in kursRubla.Values)
                tbKurs.Text = rubel.ToString();
        }
    }
}