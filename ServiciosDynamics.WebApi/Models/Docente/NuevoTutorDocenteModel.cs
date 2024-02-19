using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Docente
{
    public class NuevoTutorDocenteModel
    {
        [Required]
        public string orig { get; set; }

        [Required]
        public string nit { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string codigo { get; set; }

        [Required]
        public bool nacional { get; set; }

        [Required]
        public string usuario_oracle { get; set; }
    }
}