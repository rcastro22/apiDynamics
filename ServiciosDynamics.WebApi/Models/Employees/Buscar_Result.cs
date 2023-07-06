using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Employees
{
    public class Buscar_Result
    {

        public string Correlativo { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Tipo { get; set; }

        public string Extension { get; set; }

        public string Foto { get; set; }
    }
}