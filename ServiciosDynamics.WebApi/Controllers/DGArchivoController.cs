using ServiciosDynamics.WebApi.Models.DG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiciosDynamics.WebApi.Controllers
{
    /// <summary>
    /// API para Digitalización
    /// </summary>
    [RoutePrefix("api/dgarchivo")]
    public class DGArchivoController : ApiController
    {
        /// <summary>
        /// Consultar el numero de archivo
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("obtenerid")]
        public IHttpActionResult obtenerIdArchivo([FromBody] DGArchivoModel archivoData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                WSDGArchivo.WSDGArchivo ws = new WSDGArchivo.WSDGArchivo();

                string ret = ws.obtenerIdArchivo(
                        archivoData.aplicacion,
                        archivoData.categoria,
                        archivoData.etiquetas
                    );

                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
