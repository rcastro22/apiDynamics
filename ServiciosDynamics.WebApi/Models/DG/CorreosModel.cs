using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.DG
{
    public class CorreosModel
    {
        [Required]
        public string Para { get; set; }

        public string Copia { get; set; }

        public string Asunto { get; set; }

        public string Titulo { get; set; }

        public string Cuerpo { get; set; }
    }
}