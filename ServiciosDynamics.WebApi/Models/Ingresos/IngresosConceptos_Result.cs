using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosDynamics.WebApi.Models.Ingresos
{
    public class IngresosConceptos_Result
    {
        public string CONCEPTO { get; set; }
        public string VALOR { get; set; }
        public string FECHA { get; set; }
        public string TIPO { get; set; }
        public string CORRELATIVO { get; set; }
        public string ROWID { get; set; }
    }
}