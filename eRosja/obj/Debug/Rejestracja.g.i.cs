﻿#pragma checksum "D:\Paweł\!!! Programowanie\Aplikacje\Mobilne\eRosja\WCFeRosja\eRosja\Rejestracja.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BA2A970598E2B7903C6E24E8F5B94CF0"
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
    
    
    public partial class Rejestracja : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBox tbLogin;
        
        internal System.Windows.Controls.TextBox tbEmail;
        
        internal System.Windows.Controls.Button btnZarejestruj;
        
        internal System.Windows.Controls.TextBlock lblInformacja;
        
        internal System.Windows.Controls.PasswordBox tbHaslo;
        
        internal System.Windows.Controls.PasswordBox tbHaslo2;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/eRosja;component/Rejestracja.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.tbLogin = ((System.Windows.Controls.TextBox)(this.FindName("tbLogin")));
            this.tbEmail = ((System.Windows.Controls.TextBox)(this.FindName("tbEmail")));
            this.btnZarejestruj = ((System.Windows.Controls.Button)(this.FindName("btnZarejestruj")));
            this.lblInformacja = ((System.Windows.Controls.TextBlock)(this.FindName("lblInformacja")));
            this.tbHaslo = ((System.Windows.Controls.PasswordBox)(this.FindName("tbHaslo")));
            this.tbHaslo2 = ((System.Windows.Controls.PasswordBox)(this.FindName("tbHaslo2")));
        }
    }
}

