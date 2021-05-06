using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.TipoCambio
{
    public class FechaInicialMonedaModel
    {
        [Required]
        public string fecha { get; set; }

        [Required]
        public int moneda { get; set; }
    }
}