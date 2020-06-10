using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.Employees
{
    public class EmplTableModel
    {
        [Required]
        public string correlativo { get; set; }

       
        public string torre { get; set; }

        
        public string oficina { get; set; }


        public string extension { get; set; }

        public IEnumerable<Familiares> familiares { get; set; }

        [Required]
        public string usuario_oracle { get; set; }
    }
}