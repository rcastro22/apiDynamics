using ServiciosDynamics.WebApi.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ServiciosDynamics.WebApi.Controllers
{
    /// <summary>
    /// API de facturas
    /// </summary>
    [RoutePrefix("api/empleados")]
    public class EmployeesController : ApiController
    {
        /// <summary>
        /// Actualiza información del empleado
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("actualizar")]
        public IHttpActionResult Guardar([FromBody] EmplTableModel emplData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                WSEmpleados.WSEmpleados ws = new WSEmpleados.WSEmpleados();
                string emplId = "";

                emplId = ws.existeEmpleado(emplData.correlativo);

                if(emplId != "")
                {

                    if (emplData.familiares != null && emplData.familiares.Count() > 0)
                    {
                        ws.delfamiliares(emplId);
                        foreach (Familiares fam in emplData.familiares)
                        {
                            ws.familiares(emplId, fam.nombre, fam.genero, fam.relacion, fam.fecha_nacimiento, emplData.usuario_oracle);
                        }
                    }

                    ws.updEmplInfo(emplId, emplData.torre, emplData.oficina, emplData.extension);

                }
                else
                {
                    return BadRequest("Codigo de empleado no encontrado");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los tramites de empleados nuevos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("nuevoEmpleadoTramite")]
        public IEnumerable<Solicitudes_Result> NuevoEmplTramite()
        {
            List<Solicitudes_Result> sol;
            Uri BaseUriDG = new Uri("https://dg.galileo.edu/fotos/");
            
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = BaseUriDG;
                    client.DefaultRequestHeaders.Accept.Clear();
                    HttpResponseMessage response = client.GetAsync("Personal/obtenerSolicitudes").Result;

                    response.EnsureSuccessStatusCode();
                    sol = response.Content.ReadAsAsync<List<Solicitudes_Result>>().Result;                    
                }

                return sol;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
