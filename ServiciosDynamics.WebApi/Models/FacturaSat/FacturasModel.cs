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
        [Required]
        public string fechaEmisionIni { get; set; }
        [Required]
        public string fechaEmisionFinal {  get; set; }
    }
}