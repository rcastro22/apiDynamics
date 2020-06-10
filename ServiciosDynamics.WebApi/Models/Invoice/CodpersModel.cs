using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Invoice
{
    public class CodpersModel
    {
        [Required]
        public string codpers { get; set; }
    }
}