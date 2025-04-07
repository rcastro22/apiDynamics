﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace ServiciosDynamics.WebApi.WSEmpleados {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WSEmpleadosSoap", Namespace="http://tempuri.org/")]
    public partial class WSEmpleados : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback existeEmpleadoOperationCompleted;
        
        private System.Threading.SendOrPostCallback familiaresOperationCompleted;
        
        private System.Threading.SendOrPostCallback delfamiliaresOperationCompleted;
        
        private System.Threading.SendOrPostCallback updEmplInfoOperationCompleted;
        
        private System.Threading.SendOrPostCallback fechaDPIOperationCompleted;
        
        private System.Threading.SendOrPostCallback fechaDPIDeleteOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WSEmpleados() {
            this.Url = global::ServiciosDynamics.WebApi.Properties.Settings.Default.ServiciosDynamics_WebApi_WSEmpleados_WSEmpleados;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event existeEmpleadoCompletedEventHandler existeEmpleadoCompleted;
        
        /// <remarks/>
        public event familiaresCompletedEventHandler familiaresCompleted;
        
        /// <remarks/>
        public event delfamiliaresCompletedEventHandler delfamiliaresCompleted;
        
        /// <remarks/>
        public event updEmplInfoCompletedEventHandler updEmplInfoCompleted;
        
        /// <remarks/>
        public event fechaDPICompletedEventHandler fechaDPICompleted;
        
        /// <remarks/>
        public event fechaDPIDeleteCompletedEventHandler fechaDPIDeleteCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/existeEmpleado", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string existeEmpleado(string _emplId) {
            object[] results = this.Invoke("existeEmpleado", new object[] {
                        _emplId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void existeEmpleadoAsync(string _emplId) {
            this.existeEmpleadoAsync(_emplId, null);
        }
        
        /// <remarks/>
        public void existeEmpleadoAsync(string _emplId, object userState) {
            if ((this.existeEmpleadoOperationCompleted == null)) {
                this.existeEmpleadoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnexisteEmpleadoOperationCompleted);
            }
            this.InvokeAsync("existeEmpleado", new object[] {
                        _emplId}, this.existeEmpleadoOperationCompleted, userState);
        }
        
        private void OnexisteEmpleadoOperationCompleted(object arg) {
            if ((this.existeEmpleadoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.existeEmpleadoCompleted(this, new existeEmpleadoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/familiares", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string familiares(string _emplId, string _nombreFamiliar, int _genero, int _relacion, string _fechaNacimiento, string _usuarioOracle) {
            object[] results = this.Invoke("familiares", new object[] {
                        _emplId,
                        _nombreFamiliar,
                        _genero,
                        _relacion,
                        _fechaNacimiento,
                        _usuarioOracle});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void familiaresAsync(string _emplId, string _nombreFamiliar, int _genero, int _relacion, string _fechaNacimiento, string _usuarioOracle) {
            this.familiaresAsync(_emplId, _nombreFamiliar, _genero, _relacion, _fechaNacimiento, _usuarioOracle, null);
        }
        
        /// <remarks/>
        public void familiaresAsync(string _emplId, string _nombreFamiliar, int _genero, int _relacion, string _fechaNacimiento, string _usuarioOracle, object userState) {
            if ((this.familiaresOperationCompleted == null)) {
                this.familiaresOperationCompleted = new System.Threading.SendOrPostCallback(this.OnfamiliaresOperationCompleted);
            }
            this.InvokeAsync("familiares", new object[] {
                        _emplId,
                        _nombreFamiliar,
                        _genero,
                        _relacion,
                        _fechaNacimiento,
                        _usuarioOracle}, this.familiaresOperationCompleted, userState);
        }
        
        private void OnfamiliaresOperationCompleted(object arg) {
            if ((this.familiaresCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.familiaresCompleted(this, new familiaresCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/delfamiliares", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string delfamiliares(string _emplId) {
            object[] results = this.Invoke("delfamiliares", new object[] {
                        _emplId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void delfamiliaresAsync(string _emplId) {
            this.delfamiliaresAsync(_emplId, null);
        }
        
        /// <remarks/>
        public void delfamiliaresAsync(string _emplId, object userState) {
            if ((this.delfamiliaresOperationCompleted == null)) {
                this.delfamiliaresOperationCompleted = new System.Threading.SendOrPostCallback(this.OndelfamiliaresOperationCompleted);
            }
            this.InvokeAsync("delfamiliares", new object[] {
                        _emplId}, this.delfamiliaresOperationCompleted, userState);
        }
        
        private void OndelfamiliaresOperationCompleted(object arg) {
            if ((this.delfamiliaresCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.delfamiliaresCompleted(this, new delfamiliaresCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/updEmplInfo", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string updEmplInfo(string _emplId, string _torre, string _oficina, string _extension) {
            object[] results = this.Invoke("updEmplInfo", new object[] {
                        _emplId,
                        _torre,
                        _oficina,
                        _extension});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void updEmplInfoAsync(string _emplId, string _torre, string _oficina, string _extension) {
            this.updEmplInfoAsync(_emplId, _torre, _oficina, _extension, null);
        }
        
        /// <remarks/>
        public void updEmplInfoAsync(string _emplId, string _torre, string _oficina, string _extension, object userState) {
            if ((this.updEmplInfoOperationCompleted == null)) {
                this.updEmplInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnupdEmplInfoOperationCompleted);
            }
            this.InvokeAsync("updEmplInfo", new object[] {
                        _emplId,
                        _torre,
                        _oficina,
                        _extension}, this.updEmplInfoOperationCompleted, userState);
        }
        
        private void OnupdEmplInfoOperationCompleted(object arg) {
            if ((this.updEmplInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.updEmplInfoCompleted(this, new updEmplInfoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/fechaDPI", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string fechaDPI(string _cui) {
            object[] results = this.Invoke("fechaDPI", new object[] {
                        _cui});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void fechaDPIAsync(string _cui) {
            this.fechaDPIAsync(_cui, null);
        }
        
        /// <remarks/>
        public void fechaDPIAsync(string _cui, object userState) {
            if ((this.fechaDPIOperationCompleted == null)) {
                this.fechaDPIOperationCompleted = new System.Threading.SendOrPostCallback(this.OnfechaDPIOperationCompleted);
            }
            this.InvokeAsync("fechaDPI", new object[] {
                        _cui}, this.fechaDPIOperationCompleted, userState);
        }
        
        private void OnfechaDPIOperationCompleted(object arg) {
            if ((this.fechaDPICompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.fechaDPICompleted(this, new fechaDPICompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/fechaDPIDelete", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string fechaDPIDelete(string _cui) {
            object[] results = this.Invoke("fechaDPIDelete", new object[] {
                        _cui});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void fechaDPIDeleteAsync(string _cui) {
            this.fechaDPIDeleteAsync(_cui, null);
        }
        
        /// <remarks/>
        public void fechaDPIDeleteAsync(string _cui, object userState) {
            if ((this.fechaDPIDeleteOperationCompleted == null)) {
                this.fechaDPIDeleteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnfechaDPIDeleteOperationCompleted);
            }
            this.InvokeAsync("fechaDPIDelete", new object[] {
                        _cui}, this.fechaDPIDeleteOperationCompleted, userState);
        }
        
        private void OnfechaDPIDeleteOperationCompleted(object arg) {
            if ((this.fechaDPIDeleteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.fechaDPIDeleteCompleted(this, new fechaDPIDeleteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void existeEmpleadoCompletedEventHandler(object sender, existeEmpleadoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class existeEmpleadoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal existeEmpleadoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void familiaresCompletedEventHandler(object sender, familiaresCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class familiaresCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal familiaresCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void delfamiliaresCompletedEventHandler(object sender, delfamiliaresCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class delfamiliaresCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal delfamiliaresCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void updEmplInfoCompletedEventHandler(object sender, updEmplInfoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class updEmplInfoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal updEmplInfoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void fechaDPICompletedEventHandler(object sender, fechaDPICompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class fechaDPICompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal fechaDPICompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void fechaDPIDeleteCompletedEventHandler(object sender, fechaDPIDeleteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class fechaDPIDeleteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal fechaDPIDeleteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591