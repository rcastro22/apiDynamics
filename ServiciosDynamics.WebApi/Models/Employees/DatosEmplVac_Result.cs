using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Employees
{
    public class DatosEmplVac_Result
    {

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Departamento { get; set; }

        public string Puesto { get; set; }

        public string Jefe { get; set; }

        public string FechaIngreso { get; set; }

        public string Nomina { get; set; }

        public string DiasDerecho { get; set; }

        public string DiasVacacionesFinDeAnio { get; set; }

        public string DiasTotales { get; set; }
    }
}