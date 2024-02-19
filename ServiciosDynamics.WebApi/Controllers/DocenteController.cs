using System.Configuration;
using Newtonsoft.Json.Linq;
using ServiciosDynamics.WebApi.Models.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data;
using ServiciosDynamics.WebApi.Models.Docente;

namespace ServiciosDynamics.WebApi.Controllers
{
    /// <summary>
    /// API de Docentes
    /// </summary>
    [RoutePrefix("api/Docentes")]
    public class DocenteController : ApiController
    {

        /// <summary>
        /// Valida si existe el docente en Dynamics
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("existeDocenteDynamics")]
        public IHttpActionResult Existe([FromUri] string nit)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                WSDocentes.WSDocentes ws = new WSDocentes.WSDocentes();

                bool ret = ws.exiteDocenteDynamics(
                    nit
                    );

                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Crea el docente en la tabla de Dynamics
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("nuevoTutorDocenteDAX")]
        public IHttpActionResult nuevoTutorDocente([FromBody] NuevoTutorDocenteModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                WSDocentes.WSDocentes ws = new WSDocentes.WSDocentes();

                string ret = ws.nuevoTutorDocenteDAX(
                    model.orig,
                    model.nit,
                    model.nombre,
                    model.codigo,
                    model.nacional,
                    model.usuario_oracle
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
