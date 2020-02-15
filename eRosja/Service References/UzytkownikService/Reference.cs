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
namespace eRosja.UzytkownikService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UzytkownikService.IUzytkownikService")]
    public interface IUzytkownikService {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IUzytkownikService/ZarejestrujUzytkownika", ReplyAction="http://tempuri.org/IUzytkownikService/ZarejestrujUzytkownikaResponse")]
        System.IAsyncResult BeginZarejestrujUzytkownika(string login, string haslo, string email, System.AsyncCallback callback, object asyncState);
        
        bool EndZarejestrujUzytkownika(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IUzytkownikService/ZalogujUzytkownika", ReplyAction="http://tempuri.org/IUzytkownikService/ZalogujUzytkownikaResponse")]
        System.IAsyncResult BeginZalogujUzytkownika(string login, string haslo, System.AsyncCallback callback, object asyncState);
        
        bool EndZalogujUzytkownika(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/IUzytkownikService/PobierzID", ReplyAction="http://tempuri.org/IUzytkownikService/PobierzIDResponse")]
        System.IAsyncResult BeginPobierzID(string login, string haslo, System.AsyncCallback callback, object asyncState);
        
        long EndPobierzID(System.IAsyncResult result);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUzytkownikServiceChannel : eRosja.UzytkownikService.IUzytkownikService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ZarejestrujUzytkownikaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public ZarejestrujUzytkownikaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public partial class ZalogujUzytkownikaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public ZalogujUzytkownikaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public partial class PobierzIDCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public PobierzIDCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public long Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((long)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UzytkownikServiceClient : System.ServiceModel.ClientBase<eRosja.UzytkownikService.IUzytkownikService>, eRosja.UzytkownikService.IUzytkownikService {
        
        private BeginOperationDelegate onBeginZarejestrujUzytkownikaDelegate;
        
        private EndOperationDelegate onEndZarejestrujUzytkownikaDelegate;
        
        private System.Threading.SendOrPostCallback onZarejestrujUzytkownikaCompletedDelegate;
        
        private BeginOperationDelegate onBeginZalogujUzytkownikaDelegate;
        
        private EndOperationDelegate onEndZalogujUzytkownikaDelegate;
        
        private System.Threading.SendOrPostCallback onZalogujUzytkownikaCompletedDelegate;
        
        private BeginOperationDelegate onBeginPobierzIDDelegate;
        
        private EndOperationDelegate onEndPobierzIDDelegate;
        
        private System.Threading.SendOrPostCallback onPobierzIDCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public UzytkownikServiceClient() {
        }
        
        public UzytkownikServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UzytkownikServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UzytkownikServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UzytkownikServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
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
        
        public event System.EventHandler<ZarejestrujUzytkownikaCompletedEventArgs> ZarejestrujUzytkownikaCompleted;
        
        public event System.EventHandler<ZalogujUzytkownikaCompletedEventArgs> ZalogujUzytkownikaCompleted;
        
        public event System.EventHandler<PobierzIDCompletedEventArgs> PobierzIDCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult eRosja.UzytkownikService.IUzytkownikService.BeginZarejestrujUzytkownika(string login, string haslo, string email, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginZarejestrujUzytkownika(login, haslo, email, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool eRosja.UzytkownikService.IUzytkownikService.EndZarejestrujUzytkownika(System.IAsyncResult result) {
            return base.Channel.EndZarejestrujUzytkownika(result);
        }
        
        private System.IAsyncResult OnBeginZarejestrujUzytkownika(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string login = ((string)(inValues[0]));
            string haslo = ((string)(inValues[1]));
            string email = ((string)(inValues[2]));
            return ((eRosja.UzytkownikService.IUzytkownikService)(this)).BeginZarejestrujUzytkownika(login, haslo, email, callback, asyncState);
        }
        
        private object[] OnEndZarejestrujUzytkownika(System.IAsyncResult result) {
            bool retVal = ((eRosja.UzytkownikService.IUzytkownikService)(this)).EndZarejestrujUzytkownika(result);
            return new object[] {
                    retVal};
        }
        
        private void OnZarejestrujUzytkownikaCompleted(object state) {
            if ((this.ZarejestrujUzytkownikaCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ZarejestrujUzytkownikaCompleted(this, new ZarejestrujUzytkownikaCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ZarejestrujUzytkownikaAsync(string login, string haslo, string email) {
            this.ZarejestrujUzytkownikaAsync(login, haslo, email, null);
        }
        
        public void ZarejestrujUzytkownikaAsync(string login, string haslo, string email, object userState) {
            if ((this.onBeginZarejestrujUzytkownikaDelegate == null)) {
                this.onBeginZarejestrujUzytkownikaDelegate = new BeginOperationDelegate(this.OnBeginZarejestrujUzytkownika);
            }
            if ((this.onEndZarejestrujUzytkownikaDelegate == null)) {
                this.onEndZarejestrujUzytkownikaDelegate = new EndOperationDelegate(this.OnEndZarejestrujUzytkownika);
            }
            if ((this.onZarejestrujUzytkownikaCompletedDelegate == null)) {
                this.onZarejestrujUzytkownikaCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnZarejestrujUzytkownikaCompleted);
            }
            base.InvokeAsync(this.onBeginZarejestrujUzytkownikaDelegate, new object[] {
                        login,
                        haslo,
                        email}, this.onEndZarejestrujUzytkownikaDelegate, this.onZarejestrujUzytkownikaCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult eRosja.UzytkownikService.IUzytkownikService.BeginZalogujUzytkownika(string login, string haslo, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginZalogujUzytkownika(login, haslo, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        bool eRosja.UzytkownikService.IUzytkownikService.EndZalogujUzytkownika(System.IAsyncResult result) {
            return base.Channel.EndZalogujUzytkownika(result);
        }
        
        private System.IAsyncResult OnBeginZalogujUzytkownika(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string login = ((string)(inValues[0]));
            string haslo = ((string)(inValues[1]));
            return ((eRosja.UzytkownikService.IUzytkownikService)(this)).BeginZalogujUzytkownika(login, haslo, callback, asyncState);
        }
        
        private object[] OnEndZalogujUzytkownika(System.IAsyncResult result) {
            bool retVal = ((eRosja.UzytkownikService.IUzytkownikService)(this)).EndZalogujUzytkownika(result);
            return new object[] {
                    retVal};
        }
        
        private void OnZalogujUzytkownikaCompleted(object state) {
            if ((this.ZalogujUzytkownikaCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.ZalogujUzytkownikaCompleted(this, new ZalogujUzytkownikaCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void ZalogujUzytkownikaAsync(string login, string haslo) {
            this.ZalogujUzytkownikaAsync(login, haslo, null);
        }
        
        public void ZalogujUzytkownikaAsync(string login, string haslo, object userState) {
            if ((this.onBeginZalogujUzytkownikaDelegate == null)) {
                this.onBeginZalogujUzytkownikaDelegate = new BeginOperationDelegate(this.OnBeginZalogujUzytkownika);
            }
            if ((this.onEndZalogujUzytkownikaDelegate == null)) {
                this.onEndZalogujUzytkownikaDelegate = new EndOperationDelegate(this.OnEndZalogujUzytkownika);
            }
            if ((this.onZalogujUzytkownikaCompletedDelegate == null)) {
                this.onZalogujUzytkownikaCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnZalogujUzytkownikaCompleted);
            }
            base.InvokeAsync(this.onBeginZalogujUzytkownikaDelegate, new object[] {
                        login,
                        haslo}, this.onEndZalogujUzytkownikaDelegate, this.onZalogujUzytkownikaCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult eRosja.UzytkownikService.IUzytkownikService.BeginPobierzID(string login, string haslo, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginPobierzID(login, haslo, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        long eRosja.UzytkownikService.IUzytkownikService.EndPobierzID(System.IAsyncResult result) {
            return base.Channel.EndPobierzID(result);
        }
        
        private System.IAsyncResult OnBeginPobierzID(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string login = ((string)(inValues[0]));
            string haslo = ((string)(inValues[1]));
            return ((eRosja.UzytkownikService.IUzytkownikService)(this)).BeginPobierzID(login, haslo, callback, asyncState);
        }
        
        private object[] OnEndPobierzID(System.IAsyncResult result) {
            long retVal = ((eRosja.UzytkownikService.IUzytkownikService)(this)).EndPobierzID(result);
            return new object[] {
                    retVal};
        }
        
        private void OnPobierzIDCompleted(object state) {
            if ((this.PobierzIDCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.PobierzIDCompleted(this, new PobierzIDCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void PobierzIDAsync(string login, string haslo) {
            this.PobierzIDAsync(login, haslo, null);
        }
        
        public void PobierzIDAsync(string login, string haslo, object userState) {
            if ((this.onBeginPobierzIDDelegate == null)) {
                this.onBeginPobierzIDDelegate = new BeginOperationDelegate(this.OnBeginPobierzID);
            }
            if ((this.onEndPobierzIDDelegate == null)) {
                this.onEndPobierzIDDelegate = new EndOperationDelegate(this.OnEndPobierzID);
            }
            if ((this.onPobierzIDCompletedDelegate == null)) {
                this.onPobierzIDCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnPobierzIDCompleted);
            }
            base.InvokeAsync(this.onBeginPobierzIDDelegate, new object[] {
                        login,
                        haslo}, this.onEndPobierzIDDelegate, this.onPobierzIDCompletedDelegate, userState);
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
        
        protected override eRosja.UzytkownikService.IUzytkownikService CreateChannel() {
            return new UzytkownikServiceClientChannel(this);
        }
        
        private class UzytkownikServiceClientChannel : ChannelBase<eRosja.UzytkownikService.IUzytkownikService>, eRosja.UzytkownikService.IUzytkownikService {
            
            public UzytkownikServiceClientChannel(System.ServiceModel.ClientBase<eRosja.UzytkownikService.IUzytkownikService> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginZarejestrujUzytkownika(string login, string haslo, string email, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[3];
                _args[0] = login;
                _args[1] = haslo;
                _args[2] = email;
                System.IAsyncResult _result = base.BeginInvoke("ZarejestrujUzytkownika", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndZarejestrujUzytkownika(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("ZarejestrujUzytkownika", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginZalogujUzytkownika(string login, string haslo, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = login;
                _args[1] = haslo;
                System.IAsyncResult _result = base.BeginInvoke("ZalogujUzytkownika", _args, callback, asyncState);
                return _result;
            }
            
            public bool EndZalogujUzytkownika(System.IAsyncResult result) {
                object[] _args = new object[0];
                bool _result = ((bool)(base.EndInvoke("ZalogujUzytkownika", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginPobierzID(string login, string haslo, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[2];
                _args[0] = login;
                _args[1] = haslo;
                System.IAsyncResult _result = base.BeginInvoke("PobierzID", _args, callback, asyncState);
                return _result;
            }
            
            public long EndPobierzID(System.IAsyncResult result) {
                object[] _args = new object[0];
                long _result = ((long)(base.EndInvoke("PobierzID", _args, result)));
                return _result;
            }
        }
    }
}
