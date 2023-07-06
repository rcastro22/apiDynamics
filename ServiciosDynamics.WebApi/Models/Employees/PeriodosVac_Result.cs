using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ServiciosDynamics.WebApi.Models.Employees
{
    public class PeriodosVac_Result
    {

        public bool error { get; set; }

        public string mensaje_error { get; set; }

        public List<DataPeriods> data { get; set; }

    }

    public class DataPeriods
    {
        public string Periodo { get; set; }

        public string DiasDerecho { get; set; }

        public string DiasGozados { get; set; }

        public string DiasPendientes { get; set; }

        public string FechaInicio { get; set; }

        public string FechaFin { get; set; }

        public string TotalDias { get; set; }
    }
}