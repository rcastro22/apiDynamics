using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Ingresos
{
    public class IngresosModel
    {
        [Required]
        public string origen { get; set; }

        [Required]
        public string fecha_inicio { get; set; }

        [Required]
        public string fecha_fin { get; set; }
    }
}