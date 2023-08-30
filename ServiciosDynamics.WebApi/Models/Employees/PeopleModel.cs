using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Employees
{
    public class PeopleModel
    {
        public int Correlativo { get; set; }     
        public string Nombre1 { get; set; }      
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string DeCasada { get; set; }
        public string Cedula { get; set; }
        public int Nacionalidad { get; set; }
        public int Pais { get; set; }
        public int Depto_ID { get; set; }
        public int Muni_ID { get; set; }
        public string DPI { get; set; }
        public string Pasaporte { get; set; }
        public int Pais_PAS { get; set; }
        public string FechaNac { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Codigo { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }
        public string Usuario { get; set; }
        public string Nit { get; set; }

    }
}