using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosDynamics.WebApi.Models.Invoice
{
    public class InfoBancariaDocente_Result
    {
        public string Formapago { get; set; }
        public string Banco { get; set; }
        public string Nombre_banco { get; set; }
        public string Tipocuenta { get; set; }
        public string Nombre_tipocuenta { get; set; }
        public string Cuentabancaria { get; set; }
        public string Proveedor { get; set; }
        public string Nombre_proveedor { get; set; }
    }
}