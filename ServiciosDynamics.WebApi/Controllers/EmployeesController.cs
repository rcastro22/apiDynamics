using Newtonsoft.Json;
using ServiciosDynamics.WebApi.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
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


        /// <summary>
        /// Da seguimiento al tramite del empleado importado a Dynamics
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("seguimientoSolicitud")]
        public async Task<IHttpActionResult> SeguimientoSolicitud([FromBody] SolSeguimientoModel solData)
        {
            string ret = "";
            Uri BaseUriDG = new Uri("https://dg.galileo.edu/fotos/");

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = BaseUriDG;
                    client.DefaultRequestHeaders.Accept.Clear();
                    StringContent Content = new StringContent(JsonConvert.SerializeObject(solData), Encoding.UTF8, "application/json");
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    HttpResponseMessage response = await client.PostAsync("Personal/seguimientoSolicitud",Content);

                    response.EnsureSuccessStatusCode();
                    ret = response.Content.ReadAsAsync<string>().Result;
                }

                return Ok(ret);

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
        [HttpPost]
        [Route("People")]
        public async Task<IHttpActionResult> People([FromBody] PeopleModel emplData)
        {
            List<Solicitudes_Result> sol;
            string ret="";
            Uri BaseUriDG = new Uri("https://dg.galileo.edu/core/api/");

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = BaseUriDG;
                    client.DefaultRequestHeaders.Accept.Clear();

                    //HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(emplData), Encoding.UTF8);
                    StringContent Content = new StringContent(JsonConvert.SerializeObject(emplData), Encoding.UTF8, "application/json");
                    //httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    HttpResponseMessage response = await client.PostAsync("DynamicsUG/People", Content);
                    //HttpResponseMessage response = client.PostAsync("DynamicsUG/People", Content).Result;

                    response.EnsureSuccessStatusCode();
                    /*if (!response.IsSuccessStatusCode)
                    {
                        return null;
                    }*/
                    //sol = response.Content.ReadAsAsync<List<Solicitudes_Result>>().Result;
                    ret= response.Content.ReadAsAsync<string>().Result;
                }

                return Ok(ret);

            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
