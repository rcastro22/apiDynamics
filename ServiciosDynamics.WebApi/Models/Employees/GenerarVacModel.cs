using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Employees
{
    public class GenerarVacModel
    {
        [Required]
        public string correlativo { get; set; }

        [Required]
        public int dias { get; set; }

        [Required]
        public string fecha_inicio { get; set; }

        [Required]
        public string usuario_oracle { get; set; }

        [Required]
        public string solicitud_tramite { get; set; }
    }
}