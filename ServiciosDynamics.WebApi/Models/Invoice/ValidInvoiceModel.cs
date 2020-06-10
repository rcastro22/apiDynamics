using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Invoice
{
    public class ValidInvoiceModel
    {
        [Required]
        public string proveedor { get; set; }

        [Required]
        public string factura_serie { get; set; }

        [Required]
        public string factura_numero { get; set; }
    }
}