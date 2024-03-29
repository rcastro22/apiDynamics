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

namespace ServiciosDynamics.WebApi.WSVacaciones {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="WSVacacionesSoap", Namespace="http://tempuri.org/")]
    public partial class WSVacaciones : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback BuscarOperationCompleted;
        
        private System.Threading.SendOrPostCallback periodosVacacionesOperationCompleted;
        
        private System.Threading.SendOrPostCallback validaPeriodosOperationCompleted;
        
        private System.Threading.SendOrPostCallback DatosEmpleadosVacacionesOperationCompleted;
        
        private System.Threading.SendOrPostCallback generarVacacionDynamicsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WSVacaciones() {
            this.Url = global::ServiciosDynamics.WebApi.Properties.Settings.Default.ServiciosDynamics_WebApi_WSVacaciones_WSVacaciones;
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
        public event BuscarCompletedEventHandler BuscarCompleted;
        
        /// <remarks/>
        public event periodosVacacionesCompletedEventHandler periodosVacacionesCompleted;
        
        /// <remarks/>
        public event validaPeriodosCompletedEventHandler validaPeriodosCompleted;
        
        /// <remarks/>
        public event DatosEmpleadosVacacionesCompletedEventHandler DatosEmpleadosVacacionesCompleted;
        
        /// <remarks/>
        public event generarVacacionDynamicsCompletedEventHandler generarVacacionDynamicsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Buscar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable Buscar(string _txtBusqueda) {
            object[] results = this.Invoke("Buscar", new object[] {
                        _txtBusqueda});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void BuscarAsync(string _txtBusqueda) {
            this.BuscarAsync(_txtBusqueda, null);
        }
        
        /// <remarks/>
        public void BuscarAsync(string _txtBusqueda, object userState) {
            if ((this.BuscarOperationCompleted == null)) {
                this.BuscarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBuscarOperationCompleted);
            }
            this.InvokeAsync("Buscar", new object[] {
                        _txtBusqueda}, this.BuscarOperationCompleted, userState);
        }
        
        private void OnBuscarOperationCompleted(object arg) {
            if ((this.BuscarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.BuscarCompleted(this, new BuscarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/periodosVacaciones", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable periodosVacaciones(string _correlativo, int _dias, string _startDate, bool _periodos) {
            object[] results = this.Invoke("periodosVacaciones", new object[] {
                        _correlativo,
                        _dias,
                        _startDate,
                        _periodos});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void periodosVacacionesAsync(string _correlativo, int _dias, string _startDate, bool _periodos) {
            this.periodosVacacionesAsync(_correlativo, _dias, _startDate, _periodos, null);
        }
        
        /// <remarks/>
        public void periodosVacacionesAsync(string _correlativo, int _dias, string _startDate, bool _periodos, object userState) {
            if ((this.periodosVacacionesOperationCompleted == null)) {
                this.periodosVacacionesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnperiodosVacacionesOperationCompleted);
            }
            this.InvokeAsync("periodosVacaciones", new object[] {
                        _correlativo,
                        _dias,
                        _startDate,
                        _periodos}, this.periodosVacacionesOperationCompleted, userState);
        }
        
        private void OnperiodosVacacionesOperationCompleted(object arg) {
            if ((this.periodosVacacionesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.periodosVacacionesCompleted(this, new periodosVacacionesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/validaPeriodos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool validaPeriodos(string _correlativo, int _dias, string _startDate) {
            object[] results = this.Invoke("validaPeriodos", new object[] {
                        _correlativo,
                        _dias,
                        _startDate});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void validaPeriodosAsync(string _correlativo, int _dias, string _startDate) {
            this.validaPeriodosAsync(_correlativo, _dias, _startDate, null);
        }
        
        /// <remarks/>
        public void validaPeriodosAsync(string _correlativo, int _dias, string _startDate, object userState) {
            if ((this.validaPeriodosOperationCompleted == null)) {
                this.validaPeriodosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnvalidaPeriodosOperationCompleted);
            }
            this.InvokeAsync("validaPeriodos", new object[] {
                        _correlativo,
                        _dias,
                        _startDate}, this.validaPeriodosOperationCompleted, userState);
        }
        
        private void OnvalidaPeriodosOperationCompleted(object arg) {
            if ((this.validaPeriodosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.validaPeriodosCompleted(this, new validaPeriodosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DatosEmpleadosVacaciones", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable DatosEmpleadosVacaciones(string _correlativo) {
            object[] results = this.Invoke("DatosEmpleadosVacaciones", new object[] {
                        _correlativo});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void DatosEmpleadosVacacionesAsync(string _correlativo) {
            this.DatosEmpleadosVacacionesAsync(_correlativo, null);
        }
        
        /// <remarks/>
        public void DatosEmpleadosVacacionesAsync(string _correlativo, object userState) {
            if ((this.DatosEmpleadosVacacionesOperationCompleted == null)) {
                this.DatosEmpleadosVacacionesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDatosEmpleadosVacacionesOperationCompleted);
            }
            this.InvokeAsync("DatosEmpleadosVacaciones", new object[] {
                        _correlativo}, this.DatosEmpleadosVacacionesOperationCompleted, userState);
        }
        
        private void OnDatosEmpleadosVacacionesOperationCompleted(object arg) {
            if ((this.DatosEmpleadosVacacionesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DatosEmpleadosVacacionesCompleted(this, new DatosEmpleadosVacacionesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/generarVacacionDynamics", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string generarVacacionDynamics(string _correlativo, int _dias, string _startDate, string _usuarioOracle, string _solicitudTramite) {
            object[] results = this.Invoke("generarVacacionDynamics", new object[] {
                        _correlativo,
                        _dias,
                        _startDate,
                        _usuarioOracle,
                        _solicitudTramite});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void generarVacacionDynamicsAsync(string _correlativo, int _dias, string _startDate, string _usuarioOracle, string _solicitudTramite) {
            this.generarVacacionDynamicsAsync(_correlativo, _dias, _startDate, _usuarioOracle, _solicitudTramite, null);
        }
        
        /// <remarks/>
        public void generarVacacionDynamicsAsync(string _correlativo, int _dias, string _startDate, string _usuarioOracle, string _solicitudTramite, object userState) {
            if ((this.generarVacacionDynamicsOperationCompleted == null)) {
                this.generarVacacionDynamicsOperationCompleted = new System.Threading.SendOrPostCallback(this.OngenerarVacacionDynamicsOperationCompleted);
            }
            this.InvokeAsync("generarVacacionDynamics", new object[] {
                        _correlativo,
                        _dias,
                        _startDate,
                        _usuarioOracle,
                        _solicitudTramite}, this.generarVacacionDynamicsOperationCompleted, userState);
        }
        
        private void OngenerarVacacionDynamicsOperationCompleted(object arg) {
            if ((this.generarVacacionDynamicsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.generarVacacionDynamicsCompleted(this, new generarVacacionDynamicsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void BuscarCompletedEventHandler(object sender, BuscarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class BuscarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal BuscarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void periodosVacacionesCompletedEventHandler(object sender, periodosVacacionesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class periodosVacacionesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal periodosVacacionesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void validaPeriodosCompletedEventHandler(object sender, validaPeriodosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class validaPeriodosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal validaPeriodosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void DatosEmpleadosVacacionesCompletedEventHandler(object sender, DatosEmpleadosVacacionesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DatosEmpleadosVacacionesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DatosEmpleadosVacacionesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataTable Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataTable)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void generarVacacionDynamicsCompletedEventHandler(object sender, generarVacacionDynamicsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class generarVacacionDynamicsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal generarVacacionDynamicsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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