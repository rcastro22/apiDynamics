﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiciosDynamics.WebApi.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://10.0.3.71/ws/WSFacturas.asmx")]
        public string ServiciosDynamics_WebApi_WSFacturas_WSFacturas {
            get {
                return ((string)(this["ServiciosDynamics_WebApi_WSFacturas_WSFacturas"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://srvdynamicsdesa/ws/WSDGArchivo.asmx")]
        public string ServiciosDynamics_WebApi_WSDGArchivo_WSDGArchivo {
            get {
                return ((string)(this["ServiciosDynamics_WebApi_WSDGArchivo_WSDGArchivo"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://srvdynamicsdesa/ws/WSEmpleados.asmx")]
        public string ServiciosDynamics_WebApi_WSEmpleados_WSEmpleados {
            get {
                return ((string)(this["ServiciosDynamics_WebApi_WSEmpleados_WSEmpleados"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:13826/WSLibreria.asmx")]
        public string ServiciosDynamics_WebApi_WSLibreria_WSLibreria {
            get {
                return ((string)(this["ServiciosDynamics_WebApi_WSLibreria_WSLibreria"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://www.banguat.gob.gt/variables/ws/TipoCambio.asmx")]
        public string ServiciosDynamics_WebApi_TipoCambio_TipoCambio {
            get {
                return ((string)(this["ServiciosDynamics_WebApi_TipoCambio_TipoCambio"]));
            }
        }
    }
}
