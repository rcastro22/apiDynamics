using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Employees
{
    public class Familiares
    {
        [Required]
        public string nombre { get; set; }

        [Required]
        public int genero { get; set; }

        [Required]
        public int relacion { get; set; }

        [Required]
        public string fecha_nacimiento { get; set; }
    }
}