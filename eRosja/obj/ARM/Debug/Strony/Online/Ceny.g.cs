﻿#pragma checksum "D:\Paweł\!!! Programowanie\Aplikacje\Mobilne\eRosja\WCFeRosja\eRosja\Strony\Online\Ceny.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2EAF8EEC786EE2A8914E48DBC68D4FE3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace eRosja {
    
    
    public partial class Ceny : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Microsoft.Phone.Controls.PivotItem pivotPaliwo;
        
        internal System.Windows.Controls.ProgressBar pbLadowanie;
        
        internal Microsoft.Phone.Controls.ListPicker lpPrzejsciaPaliwo;
        
        internal Microsoft.Phone.Controls.ListPicker lpStacjePaliwo;
        
        internal System.Windows.Controls.Grid gridCenyPaliw;
        
        internal System.Windows.Controls.Grid gridNazwyPaliw;
        
        internal System.Windows.Controls.TextBlock tbNazwaStacji;
        
        internal System.Windows.Controls.TextBlock tbPaliwo1;
        
        internal System.Windows.Controls.TextBlock tbPaliwo2;
        
        internal System.Windows.Controls.TextBlock tbPaliwo3;
        
        internal System.Windows.Controls.TextBlock tbPaliwo4;
        
        internal System.Windows.Controls.TextBlock tbPaliwo5;
        
        internal System.Windows.Controls.TextBlock tbPaliwo6;
        
        internal System.Windows.Controls.TextBlock tbCena1;
        
        internal System.Windows.Controls.TextBlock tbCena2;
        
        internal System.Windows.Controls.TextBlock tbCena3;
        
        internal System.Windows.Controls.TextBlock tbCena4;
        
        internal System.Windows.Controls.TextBlock tbCena5;
        
        internal System.Windows.Controls.TextBlock tbCena6;
        
        internal Microsoft.Phone.Controls.ListPicker lpSklepyPapierosy;
        
        internal Microsoft.Phone.Controls.ListPicker lpPrzejsciaPapierosy;
        
        internal Microsoft.Phone.Controls.ListPicker lpPapierosy;
        
        internal System.Windows.Controls.TextBlock tbEuroPakiet;
        
        internal System.Windows.Controls.TextBlock tbEuroPaczka;
        
        internal System.Windows.Controls.TextBlock tbRubPakiet;
        
        internal System.Windows.Controls.TextBlock tbRubPaczka;
        
        internal System.Windows.Controls.TextBlock tbPlnPakiet;
        
        internal System.Windows.Controls.TextBlock tbPlnPaczka;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/eRosja;component/Strony/Online/Ceny.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.pivotPaliwo = ((Microsoft.Phone.Controls.PivotItem)(this.FindName("pivotPaliwo")));
            this.pbLadowanie = ((System.Windows.Controls.ProgressBar)(this.FindName("pbLadowanie")));
            this.lpPrzejsciaPaliwo = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpPrzejsciaPaliwo")));
            this.lpStacjePaliwo = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpStacjePaliwo")));
            this.gridCenyPaliw = ((System.Windows.Controls.Grid)(this.FindName("gridCenyPaliw")));
            this.gridNazwyPaliw = ((System.Windows.Controls.Grid)(this.FindName("gridNazwyPaliw")));
            this.tbNazwaStacji = ((System.Windows.Controls.TextBlock)(this.FindName("tbNazwaStacji")));
            this.tbPaliwo1 = ((System.Windows.Controls.TextBlock)(this.FindName("tbPaliwo1")));
            this.tbPaliwo2 = ((System.Windows.Controls.TextBlock)(this.FindName("tbPaliwo2")));
            this.tbPaliwo3 = ((System.Windows.Controls.TextBlock)(this.FindName("tbPaliwo3")));
            this.tbPaliwo4 = ((System.Windows.Controls.TextBlock)(this.FindName("tbPaliwo4")));
            this.tbPaliwo5 = ((System.Windows.Controls.TextBlock)(this.FindName("tbPaliwo5")));
            this.tbPaliwo6 = ((System.Windows.Controls.TextBlock)(this.FindName("tbPaliwo6")));
            this.tbCena1 = ((System.Windows.Controls.TextBlock)(this.FindName("tbCena1")));
            this.tbCena2 = ((System.Windows.Controls.TextBlock)(this.FindName("tbCena2")));
            this.tbCena3 = ((System.Windows.Controls.TextBlock)(this.FindName("tbCena3")));
            this.tbCena4 = ((System.Windows.Controls.TextBlock)(this.FindName("tbCena4")));
            this.tbCena5 = ((System.Windows.Controls.TextBlock)(this.FindName("tbCena5")));
            this.tbCena6 = ((System.Windows.Controls.TextBlock)(this.FindName("tbCena6")));
            this.lpSklepyPapierosy = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpSklepyPapierosy")));
            this.lpPrzejsciaPapierosy = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpPrzejsciaPapierosy")));
            this.lpPapierosy = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpPapierosy")));
            this.tbEuroPakiet = ((System.Windows.Controls.TextBlock)(this.FindName("tbEuroPakiet")));
            this.tbEuroPaczka = ((System.Windows.Controls.TextBlock)(this.FindName("tbEuroPaczka")));
            this.tbRubPakiet = ((System.Windows.Controls.TextBlock)(this.FindName("tbRubPakiet")));
            this.tbRubPaczka = ((System.Windows.Controls.TextBlock)(this.FindName("tbRubPaczka")));
            this.tbPlnPakiet = ((System.Windows.Controls.TextBlock)(this.FindName("tbPlnPakiet")));
            this.tbPlnPaczka = ((System.Windows.Controls.TextBlock)(this.FindName("tbPlnPaczka")));
        }
    }
}

