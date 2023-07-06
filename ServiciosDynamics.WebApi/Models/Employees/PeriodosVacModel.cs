using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Employees
{
    public class PeriodosVacModel
    {
        [Required]
        public string correlativo { get; set; }

        [Required]
        public int dias { get; set; }

        [Required]
        public string fecha_inicio { get; set; }

        public bool consultarPeriodos { get; set; }
    }
}