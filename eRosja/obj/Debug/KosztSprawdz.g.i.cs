﻿#pragma checksum "D:\Paweł\!!! Programowanie\Aplikacje\Mobilne\eRosja\WCFeRosja\eRosja\KosztSprawdz.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6CEF156DDD6252AEA6966D1E0B229E89"
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
using Microsoft.Phone.Shell;
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
    
    
    public partial class WyjazdDodaj : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton btnDodajWyjazd;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.ProgressBar pbLadowanie;
        
        internal Microsoft.Phone.Controls.ListPicker lpPrzejscia;
        
        internal System.Windows.Controls.Grid gridPaliwo;
        
        internal Microsoft.Phone.Controls.ListPicker lpStacje;
        
        internal Microsoft.Phone.Controls.ListPicker lpPaliwa;
        
        internal System.Windows.Controls.TextBox tbIloscPaliwa;
        
        internal System.Windows.Controls.CheckBox cbPapierosy;
        
        internal System.Windows.Controls.CheckBox cbAlkohol;
        
        internal System.Windows.Controls.Grid gridPapierosy;
        
        internal Microsoft.Phone.Controls.ListPicker lpSklepyPapierosy;
        
        internal Microsoft.Phone.Controls.ListPicker lpPapierosy;
        
        internal System.Windows.Controls.TextBox tbIloscPapierosow;
        
        internal System.Windows.Controls.Grid gridAlkohol;
        
        internal Microsoft.Phone.Controls.ListPicker lpSklepyAlkohol;
        
        internal Microsoft.Phone.Controls.ListPicker lpAlkohole;
        
        internal System.Windows.Controls.TextBox tbIloscAlkoholu;
        
        internal Microsoft.Phone.Controls.DatePicker dpData;
        
        internal Microsoft.Phone.Controls.TimePicker tpGodzina;
        
        internal System.Windows.Controls.CheckBox cbKanal;
        
        internal System.Windows.Controls.CheckBox cbMandat;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/eRosja;component/KosztSprawdz.xaml", System.UriKind.Relative));
            this.btnDodajWyjazd = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("btnDodajWyjazd")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.pbLadowanie = ((System.Windows.Controls.ProgressBar)(this.FindName("pbLadowanie")));
            this.lpPrzejscia = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpPrzejscia")));
            this.gridPaliwo = ((System.Windows.Controls.Grid)(this.FindName("gridPaliwo")));
            this.lpStacje = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpStacje")));
            this.lpPaliwa = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpPaliwa")));
            this.tbIloscPaliwa = ((System.Windows.Controls.TextBox)(this.FindName("tbIloscPaliwa")));
            this.cbPapierosy = ((System.Windows.Controls.CheckBox)(this.FindName("cbPapierosy")));
            this.cbAlkohol = ((System.Windows.Controls.CheckBox)(this.FindName("cbAlkohol")));
            this.gridPapierosy = ((System.Windows.Controls.Grid)(this.FindName("gridPapierosy")));
            this.lpSklepyPapierosy = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpSklepyPapierosy")));
            this.lpPapierosy = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpPapierosy")));
            this.tbIloscPapierosow = ((System.Windows.Controls.TextBox)(this.FindName("tbIloscPapierosow")));
            this.gridAlkohol = ((System.Windows.Controls.Grid)(this.FindName("gridAlkohol")));
            this.lpSklepyAlkohol = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpSklepyAlkohol")));
            this.lpAlkohole = ((Microsoft.Phone.Controls.ListPicker)(this.FindName("lpAlkohole")));
            this.tbIloscAlkoholu = ((System.Windows.Controls.TextBox)(this.FindName("tbIloscAlkoholu")));
            this.dpData = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("dpData")));
            this.tpGodzina = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("tpGodzina")));
            this.cbKanal = ((System.Windows.Controls.CheckBox)(this.FindName("cbKanal")));
            this.cbMandat = ((System.Windows.Controls.CheckBox)(this.FindName("cbMandat")));
        }
    }
}
