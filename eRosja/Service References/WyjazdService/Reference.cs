﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.Phone.ServiceReference, version 3.7.0.0
// 
namespace eRosja.WyjazdService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Wyjazd", Namespace="http://schemas.datacontract.org/2004/07/WCFeRosja")]
    public partial class Wyjazd : object, System.ComponentModel.INotifyPropertyChanged {
        
        private eRosja.WyjazdService.Alkohol AlkoholField;
        
        private System.DateTime DataField;
        
        private bool KanalField;
        
        private string LoginUzytkownikaField;
        
        private bool MandatField;
        
        private eRosja.WyjazdService.Paliwo PaliwoField;
        
        private eRosja.WyjazdService.Papierosy PapierosyField;
        
        private string PrzejscieField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public eRosja.WyjazdService.Alkohol Alkohol {
            get {
                return this.AlkoholField;
            }
            set {
                if ((object.ReferenceEquals(this.AlkoholField, value) != true)) {
                    this.AlkoholField = value;
                    this.RaisePropertyChanged("Alkohol");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Data {
            get {
                return this.DataField;
            }
            set {
                if ((this.DataField.Equals(value) != true)) {
                    this.DataField = value;
                    this.RaisePropertyChanged("Data");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Kanal {
            get {
                return this.KanalField;
            }
            set {
                if ((this.KanalField.Equals(value) != true)) {
                    this.KanalField = value;
                    this.RaisePropertyChanged("Kanal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LoginUzytkownika {
            get {
                return this.LoginUzytkownikaField;
            }
            set {
                if ((object.ReferenceEquals(this.LoginUzytkownikaField, value) != true)) {
                    this.LoginUzytkownikaField = value;
                    this.RaisePropertyChanged("LoginUzytkownika");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Mandat {
            get {
                return this.MandatField;
            }
            set {
                if ((this.MandatField.Equals(value) != true)) {
                    this.MandatField = value;
                    this.RaisePropertyChanged("Mandat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public eRosja.WyjazdService.Paliwo Paliwo {
            get {
                return this.PaliwoField;
            }
            set {
                if ((object.ReferenceEquals(this.PaliwoField, value) != true)) {
                    this.PaliwoField = value;
                    this.RaisePropertyChanged("Paliwo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public eRosja.WyjazdService.Papierosy Papierosy {
            get {
                return this.PapierosyField;
            }
            set {
                if ((object.ReferenceEquals(this.PapierosyField, value) != true)) {
                    this.PapierosyField = value;
                    this.RaisePropertyChanged("Papierosy");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Przejscie {
            get {
                return this.PrzejscieField;
            }
            set {
                if ((object.ReferenceEquals(this.PrzejscieField, value) != true)) {
                    this.PrzejscieField = value;
                    this.RaisePropertyChanged("Przejscie");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Alkohol", Namespace="http://schemas.datacontract.org/2004/07/WCFeRosja")]
    public partial class Alkohol : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Nullable<decimal> CenaField;
        
        private decimal IloscField;
        
        private string NazwaField;
        
        private string PrzejscieField;
        
        private string SklepField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> Cena {
            get {
                return this.CenaField;
            }
            set {
                if ((this.CenaField.Equals(value) != true)) {
                    this.CenaField = value;
                    this.RaisePropertyChanged("Cena");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Ilosc {
            get {
                return this.IloscField;
            }
            set {
                if ((this.IloscField.Equals(value) != true)) {
                    this.IloscField = value;
                    this.RaisePropertyChanged("Ilosc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nazwa {
            get {
                return this.NazwaField;
            }
            set {
                if ((object.ReferenceEquals(this.NazwaField, value) != true)) {
                    this.NazwaField = value;
                    this.RaisePropertyChanged("Nazwa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Przejscie {
            get {
                return this.PrzejscieField;
            }
            set {
                if ((object.ReferenceEquals(this.PrzejscieField, value) != true)) {
                    this.PrzejscieField = value;
                    this.RaisePropertyChanged("Przejscie");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sklep {
            get {
                return this.SklepField;
            }
            set {
                if ((object.ReferenceEquals(this.SklepField, value) != true)) {
                    this.SklepField = value;
                    this.RaisePropertyChanged("Sklep");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Paliwo", Namespace="http://schemas.datacontract.org/2004/07/WCFeRosja")]
    public partial class Paliwo : object, System.ComponentModel.INotifyPropertyChanged {
        
        private decimal IloscPaliwaField;
        
        private string RodzajPaliwaField;
        
        private string StacjaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal IloscPaliwa {
            get {
                return this.IloscPaliwaField;
            }
            set {
                if ((this.IloscPaliwaField.Equals(value) != true)) {
                    this.IloscPaliwaField = value;
                    this.RaisePropertyChanged("IloscPaliwa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RodzajPaliwa {
            get {
                return this.RodzajPaliwaField;
            }
            set {
                if ((object.ReferenceEquals(this.RodzajPaliwaField, value) != true)) {
                    this.RodzajPaliwaField = value;
                    this.RaisePropertyChanged("RodzajPaliwa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Stacja {
            get {
                return this.StacjaField;
            }
            set {
                if ((object.ReferenceEquals(this.StacjaField, value) != true)) {
                    this.StacjaField = value;
                    this.RaisePropertyChanged("Stacja");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Papierosy", Namespace="http://schemas.datacontract.org/2004/07/WCFeRosja")]
    public partial class Papierosy : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Nullable<decimal> CenaField;
        
        private int IloscField;
        
        private string NazwaField;
        
        private string PrzejscieField;
        
        private string SklepField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<decimal> Cena {
            get {
                return this.CenaField;
            }
            set {
                if ((this.CenaField.Equals(value) != true)) {
                    this.CenaField = value;
                    this.RaisePropertyChanged("Cena");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Ilosc {
            get {
                return this.IloscField;
            }
            set {
                if ((this.IloscField.Equals(value) != true)) {
                    this.IloscField = value;
                    this.RaisePropertyChanged("Ilosc");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nazwa {
            get {
                return this.NazwaField;
            }
            set {
                if ((object.ReferenceEquals(this.NazwaField, value) != true)) {
                    this.NazwaField = value;
                    this.RaisePropertyChanged("Nazwa");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Przejscie {
            get {
                return this.PrzejscieField;
            }
            set {
                if ((object.ReferenceEquals(this.PrzejscieField, value) != true)) {
                    this.PrzejscieField = value;
                    this.RaisePropertyChanged("Przejscie");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sklep {
            get {
                return this.SklepField;
            }
            set {
                if ((object.ReferenceEquals(this.SklepField, value) != true)) {
                    this.SklepField = value;
                    this.RaisePropertyChanged("Sklep");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WyjazdService.IWyjazdService")]
    public interface IWyjazdService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IWyjazdService/DodajWyjazd", ReplyAction="http://tempuri.org/IWyjazdService/DodajWyjazdResponse")]
        System.IAsyncResult BeginDodajWyjazd(eRosja.WyjazdService.Wyjazd daneWyjazdu, System.AsyncCallback callback, object asyncState);
        
        bool EndDodajWyjazd(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IWyjazdService/PobierzWyjazdy", ReplyAction="http://tempuri.org/IWyjazdService/PobierzWyjazdyResponse")]
        System.IAsyncResult BeginPobierzWyjazdy(string loginUzytkownika, System.AsyncCallback callback, object asyncState);
        
        System.Collections.ObjectModel.ObservableCollection<eRosja.WyjazdService.Wyjazd> EndPobierzWyjazdy(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWyjazdServiceChannel : eRosja.WyjazdService.IWyjazdService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DodajWyjazdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public DodajWyjazdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public bool Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PobierzWyjazdyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public PobierzWyjazdyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public System.Collections.ObjectModel.ObservableCollection<eRosja.WyjazdService.Wyjazd> Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((System.Collections.ObjectModel.ObservableCollection<eRosja.WyjazdService.Wyjazd>)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WyjazdServiceClient : System.ServiceModel.ClientBase<eRosja.WyjazdService.IWyjazdService>, eRosja.WyjazdService.IWyjazdService {
        
        private BeginOperationDelegate onBeginDodajWyjazdDelegate;
        
        private EndOperationDelegate onEndDodajWyjazdDelegate;
        
        private System.Threading.SendOrPostCallback onDodajWyjazdCompletedDelegate;
        
        private BeginOperationDelegate onBeginPobierzWyjazdyDelegate;
        
        private EndOperationDelegate onEndPobierzWyjazdyDelegate;
        
        private System.Threading.SendOrPostCallback onPobierzWyjazdyCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public WyjazdServiceClient() {
        }
        
        public WyjazdServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WyjazdServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WyjazdServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WyjazdServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Net.CookieContainer CookieContainer {
            get {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    return httpCookieContainerManager.CookieContainer;
                }
                else {
                    return null;
                }
            }
            set {
                System.ServiceModel.Channels.IHttpCookieContainerManager httpCookieContainerManager = this.InnerChannel.GetProperty<System.ServiceModel.Channels.IHttpCookieContainerManager>();
                if ((httpCookieContainerManager != null)) {
                    httpCookieContainerManager.CookieContainer = value;
                }
                else {
                    throw new System.InvalidOperationException("Unable to set the CookieContainer. Please make sure the binding contains an HttpC" +
                            "ookieContainerBindingElement.");
                }
            }
        }
        
        public event System.EventHandler<DodajWyjazdCompletedEventArgs> DodajWyjazdCompleted;
        
        public event System.EventHandler<PobierzWyjazdyCompletedEventArgs> PobierzWyjazdyCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult eRosja.WyjazdService.IWyjazdService.BeginDodajWyjazd(eRosja.WyjazdService.Wyjazd daneWyjazdu, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginDodajWyjazd(daneWyjazdu, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool eRosja.WyjazdService.IWyjazdService.EndDodajWyjazd(System.IAsyncResult result) {
            return base.Channel.EndDodajWyjazd(result);
        }
        
        private System.IAsyncResult OnBeginDodajWyjazd(object[] inValues, System.AsyncCallback callback, object asyncState) {
            eRosja.WyjazdService.Wyjazd daneWyjazdu = ((eRosja.WyjazdService.Wyjazd)(inValues[0]));
            return ((eRosja.WyjazdService.IWyjazdService)(this)).BeginDodajWyjazd(daneWyjazdu, callback, asyncState);
        }
        
        private object[] OnEndDodajWyjazd(System.IAsyncResult result) {
            bool retVal = ((eRosja.WyjazdService.IWyjazdService)(this)).EndDodajWyjazd(result);
            return new object[] {
                    retVal};
        }
        
        private void OnDodajWyjazdCompleted(object state) {
            if ((this.DodajWyjazdCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.DodajWyjazdCompleted(this, new DodajWyjazdCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void DodajWyjazdAsync(eRosja.WyjazdService.Wyjazd daneWyjazdu) {
            this.DodajWyjazdAsync(daneWyjazdu, null);
        }
        
        public void DodajWyjazdAsync(eRosja.WyjazdService.Wyjazd daneWyjazdu, object userState) {
            if ((this.onBeginDodajWyjazdDelegate == null)) {
                this.onBeginDodajWyjazdDelegate = new BeginOperationDelegate(this.OnBeginDodajWyjazd);
            }
            if ((this.onEndDodajWyjazdDelegate == null)) {
                this.onEndDodajWyjazdDelegate = new EndOperationDelegate(this.OnEndDodajWyjazd);
            }
            if ((this.onDodajWyjazdCompletedDelegate == null)) {
                this.onDodajWyjazdCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnDodajWyjazdCompleted);
            }
            base.InvokeAsync(this.onBeginDodajWyjazdDelegate, new object[] {
                        daneWyjazdu}, this.onEndDodajWyjazdDelegate, this.onDodajWyjazdCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult eRosja.WyjazdService.IWyjazdService.BeginPobierzWyjazdy(string loginUzytkownika, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginPobierzWyjazdy(loginUzytkownika, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Collections.ObjectModel.ObservableCollection<eRosja.WyjazdService.Wyjazd> eRosja.WyjazdService.IWyjazdService.EndPobierzWyjazdy(System.IAsyncResult result) {
            return base.Channel.EndPobierzWyjazdy(result);
        }
        
        private System.IAsyncResult OnBeginPobierzWyjazdy(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string loginUzytkownika = ((string)(inValues[0]));
            return ((eRosja.WyjazdService.IWyjazdService)(this)).BeginPobierzWyjazdy(loginUzytkownika, callback, asyncState);
        }
        
        private object[] OnEndPobierzWyjazdy(System.IAsyncResult result) {
            System.Collections.ObjectModel.ObservableCollection<eRosja.WyjazdService.Wyjazd> retVal = ((eRosja.WyjazdService.IWyjazdService)(this)).EndPobierzWyjazdy(result);
            return new object[] {
                    retVal};
        }
        
        private void OnPobierzWyjazdyCompleted(object state) {
            if ((this.PobierzWyjazdyCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.PobierzWyjazdyCompleted(this, new PobierzWyjazdyCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void PobierzWyjazdyAsync(string loginUzytkownika) {
            this.PobierzWyjazdyAsync(loginUzytkownika, null);
        }
        
        public void PobierzWyjazdyAsync(string loginUzytkownika, object userState) {
            if ((this.onBeginPobierzWyjazdyDelegate == null)) {
                this.onBeginPobierzWyjazdyDelegate = new BeginOperationDelegate(this.OnBeginPobierzWyjazdy);
            }
            if ((this.onEndPobierzWyjazdyDelegate == null)) {
                this.onEndPobierzWyjazdyDelegate = new EndOperationDelegate(this.OnEndPobierzWyjazdy);
            }
            if ((this.onPobierzWyjazdyCompletedDelegate == null)) {
                this.onPobierzWyjazdyCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPobierzWyjazdyCompleted);
            }
            base.InvokeAsync(this.onBeginPobierzWyjazdyDelegate, new object[] {
                        loginUzytkownika}, this.onEndPobierzWyjazdyDelegate, this.onPobierzWyjazdyCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override eRosja.WyjazdService.IWyjazdService CreateChannel() {
            return new WyjazdServiceClientChannel(this);
        }
        
        private class WyjazdServiceClientChannel : ChannelBase<eRosja.WyjazdService.IWyjazdService>, eRosja.WyjazdService.IWyjazdService {
            
            public WyjazdServiceClientChannel(System.ServiceModel.ClientBase<eRosja.WyjazdService.IWyjazdService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginDodajWyjazd(eRosja.WyjazdService.Wyjazd daneWyjazdu, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = daneWyjazdu;
                System.IAsyncResult _result = base.BeginInvoke("DodajWyjazd", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndDodajWyjazd(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("DodajWyjazd", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginPobierzWyjazdy(string loginUzytkownika, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = loginUzytkownika;
                System.IAsyncResult _result = base.BeginInvoke("PobierzWyjazdy", _args, callback, asyncState);
                return _result;
            }
            
            public System.Collections.ObjectModel.ObservableCollection<eRosja.WyjazdService.Wyjazd> EndPobierzWyjazdy(System.IAsyncResult result) {
                object[] _args = new object[0];
                System.Collections.ObjectModel.ObservableCollection<eRosja.WyjazdService.Wyjazd> _result = ((System.Collections.ObjectModel.ObservableCollection<eRosja.WyjazdService.Wyjazd>)(base.EndInvoke("PobierzWyjazdy", _args, result)));
                return _result;
            }
        }
    }
}