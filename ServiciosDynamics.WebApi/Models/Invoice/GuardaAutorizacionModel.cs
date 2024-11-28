using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Invoice
{
    public class GuardaAutorizacionModel
    {
        [Required]
        public string nit { get; set; }

        [Required]
        public string factura_serie { get; set; }

        [Required]
        public string factura_numero { get; set; }

        [Required]
        public string autorizacion { get; set; }

        [Required]
        public string ref_interna { get; set; }

        [Required]
        public string fecha_autorizacion { get; set; }

        public int certificador_id { get; set; }
    }
}