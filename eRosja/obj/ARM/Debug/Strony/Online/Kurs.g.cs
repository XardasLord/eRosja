﻿#pragma checksum "D:\Paweł\!!! Programowanie\Aplikacje\Mobilne\eRosja\WCFeRosja\eRosja\Strony\Online\Kurs.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EE54A6D0DAD5E7D192680F40A8C9B8C8"
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
    
    
    public partial class Kurs : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.ProgressBar pbLadowanie;
        
        internal System.Windows.Controls.TextBlock tbKurs;
        
        internal System.Windows.Controls.TextBlock tbData;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/eRosja;component/Strony/Online/Kurs.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.pbLadowanie = ((System.Windows.Controls.ProgressBar)(this.FindName("pbLadowanie")));
            this.tbKurs = ((System.Windows.Controls.TextBlock)(this.FindName("tbKurs")));
            this.tbData = ((System.Windows.Controls.TextBlock)(this.FindName("tbData")));
        }
    }
}

