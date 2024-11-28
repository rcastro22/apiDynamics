using ServiciosDynamics.WebApi.Models.TipoCambio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosDynamics.WebApi.Controllers
{
    /// <summary>
    /// API de tipo de cambio
    /// </summary>
    [RoutePrefix("api/tipocambio")]
    public class TipoCambioController : ApiController
    {
        /// <summary>
        /// tipo de cambio: Fecha inicial moneda
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("fechainicialmoneda")]
        public IHttpActionResult fechainicialmoneda([FromUri] FechaInicialMonedaModel fimData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                TipoCambio.TipoCambio ws = new TipoCambio.TipoCambio();

                var ret = ws.TipoCambioFechaInicialMoneda(fimData.fecha, fimData.moneda);

                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
