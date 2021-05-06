using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Library
{
    public class DatosReciboModel
    {
        [Required]
        public string recibo { get; set; }

        [Required]
        public List<DetalleLibrosModel> libros { get; set; }

    }
}