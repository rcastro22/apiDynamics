using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Invoice
{
    public class InvoiceModel
    {
        [Required]
        public string proveedor { get; set; }

        [Required]
        public string factura_serie { get; set; }

        [Required]
        public string factura_numero { get; set; }

        [Required]
        public string fecha { get; set; }

        [Required]
        public string descripcion { get; set; }

        [Required]
        public string monto { get; set; }

        [Required]
        public string id_detalle { get; set; }

        [Required]
        public int type_staff { get; set; }

        [Required]
        public string usuario_oracle { get; set; }

        public string no_tramite { get; set; }
    }
}