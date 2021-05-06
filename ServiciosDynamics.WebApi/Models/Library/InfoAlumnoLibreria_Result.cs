using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiciosDynamics.WebApi.Models.Library
{
    public class InfoAlumnoLibreria_Result
    {
        public string nombreAlumno { get; set; }
        public IEnumerable<CursoAsig> cursos { get; set; }   
    }
}