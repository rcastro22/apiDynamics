using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Ingresos
{
    public class IngresosConceptosModel
    {
        [Required]
        public string recibo { get; set; }

        [Required]
        public string fecha { get; set; }

        [Required]
        public string tipo { get; set; }
    }
}