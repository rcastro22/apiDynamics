using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Library
{
    public class DetalleLibrosModel
    {
        [Required]
        public string codLibro { get; set; }

        [Required]
        public int cantidad { get; set; }

        [Required]
        public string almacen { get; set; }
    }
}