using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.DG
{
    public class DGArchivoModel
    {
        [Required]
        public string aplicacion { get; set; }

        [Required]
        public int categoria { get; set; }

        [Required]
        public string etiquetas { get; set; }
    }
}