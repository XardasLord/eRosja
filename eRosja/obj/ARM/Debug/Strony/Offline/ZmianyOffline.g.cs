﻿#pragma checksum "D:\Paweł\!!! Programowanie\Aplikacje\Mobilne\eRosja\WCFeRosja\eRosja\Strony\Offline\ZmianyOffline.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5584A2A83DA85A62ABE347A3BE13EF7E"
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
using WPControls;


namespace eRosja.Strony.Offline {
    
    
    public partial class ZmianyOffline : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.ProgressBar pbLadowanie;
        
        internal WPControls.Calendar kalendarz;
        
        internal System.Windows.Controls.TextBlock tbDzien;
        
        internal System.Windows.Controls.TextBlock tbNoc;
        
        internal System.Windows.Controls.TextBlock lblData;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/eRosja;component/Strony/Offline/ZmianyOffline.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.pbLadowanie = ((System.Windows.Controls.ProgressBar)(this.FindName("pbLadowanie")));
            this.kalendarz = ((WPControls.Calendar)(this.FindName("kalendarz")));
            this.tbDzien = ((System.Windows.Controls.TextBlock)(this.FindName("tbDzien")));
            this.tbNoc = ((System.Windows.Controls.TextBlock)(this.FindName("tbNoc")));
            this.lblData = ((System.Windows.Controls.TextBlock)(this.FindName("lblData")));
        }
    }
}

