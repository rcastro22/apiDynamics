using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Employees
{
    public class CuiModel
    {
        [Required]
        public string Cui { get; set; }
    }
}