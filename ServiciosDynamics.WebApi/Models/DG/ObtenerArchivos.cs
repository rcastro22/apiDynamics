using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.DG
{
    public class ObtenerArchivos
    {
        [Required]
        public string Aplicacion { get; set; }

        [Required]
        public string categoria { get; set; }

        [Required]
        public List<Etiquetas> Etiquetas { get; set; }
    }
}