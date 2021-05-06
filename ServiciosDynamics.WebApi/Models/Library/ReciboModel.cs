using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Library
{
    public class ReciboModel
    {
        [Required]
        public string recibo { get; set; }

    }
}