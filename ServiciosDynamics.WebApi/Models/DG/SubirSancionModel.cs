using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.DG
{
    public class SubirSancionModel
    {
        [Required]
        public string nombre_archivo { get; set; }
    }
}