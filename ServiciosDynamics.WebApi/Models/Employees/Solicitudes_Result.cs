using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Employees
{
    public class Solicitudes_Result
    {
        [Required]
        public string SOLICITUD { get; set; }
       
        public string CORREO { get; set; }

        public IEnumerable<DataSolicitud> DATOS { get; set; }
    }
}