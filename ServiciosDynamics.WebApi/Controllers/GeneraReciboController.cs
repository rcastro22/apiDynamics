using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosDynamics.WebApi.Controllers
{
    /// <summary>
    /// API de recibos
    /// </summary>
    [RoutePrefix("api/recibos")]
    public class GeneraReciboController : ApiController
    {
        /// <summary>
        /// Guarda las facturas en Dynamics
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("genera")]
        public IHttpActionResult Generar([FromUri] string codigo, int tipo, int anticipo)
        {
            string resp = "";
            try
            {
                /*if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }*/

                WSRecibos.WSReceiptsGeneration ws = new WSRecibos.WSReceiptsGeneration();

                switch (tipo)
                {
                    case 0:     // transaccion de Nomina
                        switch (anticipo)
                        {
                            case 0:
                                resp = ws.generateAdvanceReceipt(codigo);
                                break;
                            case 1:
                                resp = ws.generateTransReceipt(codigo);
                                break;
                        }
                        break;
                    case 1:     // diario de pago
                        switch (anticipo)
                        {
                            case 0:
                                resp = ws.generateInvoiceAdvanceReceipt(codigo);
                                break;
                            case 1:
                                resp = ws.generateInvoiceReceipt(codigo);
                                break;
                        }
                        break;
                    case 2:
                        break;
                }


                return Ok(resp);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
