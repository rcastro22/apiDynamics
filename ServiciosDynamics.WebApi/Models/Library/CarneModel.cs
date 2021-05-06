using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Library
{
    public class CarneModel
    {
        [Required]
        public string carnet { get; set; }

    }
}