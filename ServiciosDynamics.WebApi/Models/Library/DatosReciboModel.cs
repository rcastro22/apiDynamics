using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Library
{
    public class DatosReciboModel
    {
        // 16-09-2025, RC, Se omite el recibo porque el traslado es por dia
        //[Required]
        //public string recibo { get; set; }
        
        [Required]
        public string fecha { get; set; }

        [Required]
        public List<DetalleLibrosModel> libros { get; set; }

    }
}