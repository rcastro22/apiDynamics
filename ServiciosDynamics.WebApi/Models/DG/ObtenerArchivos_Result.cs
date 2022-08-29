using System;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.DG
{
    public class ObtenerArchivos_Result
    {
        public string IdArchivo { get; set; }

        public DateTime Fecha { get; set; }
    }
}