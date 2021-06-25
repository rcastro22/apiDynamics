using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosDynamics.WebApi.Models.Invoice
{
    public class InfoPagoFacturacion_Result
    {
        public string CATEDRATICO { get; set; }
        public string REFERENCIA { get; set; }
        public string MONTO { get; set; }
        public string FECHAPROVISION { get; set; }
        public string FECHAPAGO { get; set; }
        public string NOMINA { get; set; }
        public string CORRELATIVO { get; set; }
        public string NOMBRE { get; set; }
        public string PORTAL { get; set; }
        public string FECHAIMP { get; set; }
        public string CURSOS { get; set; }
        public string ALUMNOSCURSO { get; set; }
        public string FECHA { get; set; }
        public string TIPONOMINA { get; set; }
        public string PUESTO { get; set; }
        public string ROWID { get; set; }
        public IEnumerable<InfoPagoDetalle_Result> Detalle { get; set; }
    }
}