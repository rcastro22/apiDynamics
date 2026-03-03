using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosDynamics.WebApi.Models.FacturaSat
{
    public class Facturas_Result
    {
        public string fechaEmision { get; set; }
        public string numeroUuid { get; set; }
        public string tipo { get; set; }
        public string serie { get; set; }
        public string numeroDocumento { get; set; }
        public string nitEmisor { get; set; }
        public string nombreEmisor { get; set; }
        public string codigoEstablecimiento { get; set; }
        public string nombreEstablecimiento { get; set; }
        public string receptorTipoEspecial { get; set; }
        public string nitReceptor { get; set; }
        public string nombreReceptor { get; set; }
        public string nitCertificador { get; set; }
        public string nombreCertificador { get; set; }
        public string moneda { get; set; }
        public string granTotal { get; set; }
        public string anulado { get; set; }
        public string rechazado { get; set; }
        public string fechaAnulacion { get; set; }
        public string totalIva { get; set; }
        public string impuestoPetroleo { get; set; }
        public string impuestoTurismoHospedaje { get; set; }
        public string impuestoTurismoPasaje { get; set; }
        public string impuestoTrimbrePrensa { get; set; }
        public string impuestoBomberos { get; set; }
        public string impuestoTasaMunicipal { get; set; }
        public string impuestoBebidaAlcoholica { get; set; }
        public string impuestoTabaco { get; set; }
        public string impuestoCemento { get; set; }
        public string impuestoBebidaNoAlcoholica { get; set; }
        public string impuestoTarifaPortuaria { get; set; }
        public string clasificacionEmisor { get; set; }
        public string exportacion { get; set; }
        public string emisionUbicacionTemporal { get; set; }
        public string columnCount { get; set; }
    }
}