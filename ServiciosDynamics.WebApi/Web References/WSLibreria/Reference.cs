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

namespace ServiciosDynamics.WebApi.WSLibreria {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="WSLibreriaSoap", Namespace="http://tempuri.org/")]
    public partial class WSLibreria : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback nombreAlumnoOperationCompleted;
        
        private System.Threading.SendOrPostCallback cursosAsigAlumnoOperationCompleted;
        
        private System.Threading.SendOrPostCallback createSalesOrderOperationCompleted;
        
        private System.Threading.SendOrPostCallback cancelSalesOrderOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WSLibreria() {
            this.Url = global::ServiciosDynamics.WebApi.Properties.Settings.Default.ServiciosDynamics_WebApi_WSLibreria_WSLibreria;
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
        public event nombreAlumnoCompletedEventHandler nombreAlumnoCompleted;
        
        /// <remarks/>
        public event cursosAsigAlumnoCompletedEventHandler cursosAsigAlumnoCompleted;
        
        /// <remarks/>
        public event createSalesOrderCompletedEventHandler createSalesOrderCompleted;
        
        /// <remarks/>
        public event cancelSalesOrderCompletedEventHandler cancelSalesOrderCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/nombreAlumno", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string nombreAlumno(string _carne) {
            object[] results = this.Invoke("nombreAlumno", new object[] {
                        _carne});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void nombreAlumnoAsync(string _carne) {
            this.nombreAlumnoAsync(_carne, null);
        }
        
        /// <remarks/>
        public void nombreAlumnoAsync(string _carne, object userState) {
            if ((this.nombreAlumnoOperationCompleted == null)) {
                this.nombreAlumnoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnnombreAlumnoOperationCompleted);
            }
            this.InvokeAsync("nombreAlumno", new object[] {
                        _carne}, this.nombreAlumnoOperationCompleted, userState);
        }
        
        private void OnnombreAlumnoOperationCompleted(object arg) {
            if ((this.nombreAlumnoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.nombreAlumnoCompleted(this, new nombreAlumnoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/cursosAsigAlumno", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataTable cursosAsigAlumno(string _carne) {
            object[] results = this.Invoke("cursosAsigAlumno", new object[] {
                        _carne});
            return ((System.Data.DataTable)(results[0]));
        }
        
        /// <remarks/>
        public void cursosAsigAlumnoAsync(string _carne) {
            this.cursosAsigAlumnoAsync(_carne, null);
        }
        
        /// <remarks/>
        public void cursosAsigAlumnoAsync(string _carne, object userState) {
            if ((this.cursosAsigAlumnoOperationCompleted == null)) {
                this.cursosAsigAlumnoOperationCompleted = new System.Threading.SendOrPostCallback(this.OncursosAsigAlumnoOperationCompleted);
            }
            this.InvokeAsync("cursosAsigAlumno", new object[] {
                        _carne}, this.cursosAsigAlumnoOperationCompleted, userState);
        }
        
        private void OncursosAsigAlumnoOperationCompleted(object arg) {
            if ((this.cursosAsigAlumnoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.cursosAsigAlumnoCompleted(this, new cursosAsigAlumnoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/createSalesOrder", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string createSalesOrder(string _detalleLibros) {
            object[] results = this.Invoke("createSalesOrder", new object[] {
                        _detalleLibros});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void createSalesOrderAsync(string _detalleLibros) {
            this.createSalesOrderAsync(_detalleLibros, null);
        }
        
        /// <remarks/>
        public void createSalesOrderAsync(string _detalleLibros, object userState) {
            if ((this.createSalesOrderOperationCompleted == null)) {
                this.createSalesOrderOperationCompleted = new System.Threading.SendOrPostCallback(this.OncreateSalesOrderOperationCompleted);
            }
            this.InvokeAsync("createSalesOrder", new object[] {
                        _detalleLibros}, this.createSalesOrderOperationCompleted, userState);
        }
        
        private void OncreateSalesOrderOperationCompleted(object arg) {
            if ((this.createSalesOrderCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.createSalesOrderCompleted(this, new createSalesOrderCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/cancelSalesOrder", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string cancelSalesOrder(string _recibo) {
            object[] results = this.Invoke("cancelSalesOrder", new object[] {
                        _recibo});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void cancelSalesOrderAsync(string _recibo) {
            this.cancelSalesOrderAsync(_recibo, null);
        }
        
        /// <remarks/>
        public void cancelSalesOrderAsync(string _recibo, object userState) {
            if ((this.cancelSalesOrderOperationCompleted == null)) {
                this.cancelSalesOrderOperationCompleted = new System.Threading.SendOrPostCallback(this.OncancelSalesOrderOperationCompleted);
            }
            this.InvokeAsync("cancelSalesOrder", new object[] {
                        _recibo}, this.cancelSalesOrderOperationCompleted, userState);
        }
        
        private void OncancelSalesOrderOperationCompleted(object arg) {
            if ((this.cancelSalesOrderCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.cancelSalesOrderCompleted(this, new cancelSalesOrderCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void nombreAlumnoCompletedEventHandler(object sender, nombreAlumnoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class nombreAlumnoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal nombreAlumnoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void cursosAsigAlumnoCompletedEventHandler(object sender, cursosAsigAlumnoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class cursosAsigAlumnoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal cursosAsigAlumnoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void createSalesOrderCompletedEventHandler(object sender, createSalesOrderCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class createSalesOrderCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal createSalesOrderCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void cancelSalesOrderCompletedEventHandler(object sender, cancelSalesOrderCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class cancelSalesOrderCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal cancelSalesOrderCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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