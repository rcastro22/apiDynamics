using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ServiciosDynamics.WebApi.Models.FacturaSat
{
    public class FacturasModel
    {
        [Required]
        public string usuario {  get; set; }
        public string fechaEmisionIni { get; set; }
        public string fechaEmisionFinal {  get; set; }
        public string nitEmisor { get; set; }
        public string noAutorizacion { get; set; }
    }
}