using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Invoice
{
    public class ValidInvoiceNitModel
    {
        [Required]
        public string nit { get; set; }

        [Required]
        public string factura_serie { get; set; }

        [Required]
        public string factura_numero { get; set; }
    }
}