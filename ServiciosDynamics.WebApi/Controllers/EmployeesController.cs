using Newtonsoft.Json;
using ServiciosDynamics.WebApi.Models.Employees;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
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
            string url = ConfigurationManager.AppSettings["dgFotos"];
            List<Solicitudes_Result> sol;
            Uri BaseUriDG = new Uri(url);
            
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
            string url = ConfigurationManager.AppSettings["dgFotos"];
            SolSeguimiento_Result result;
            string ret = "";
            Uri BaseUriDG = new Uri(url);

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
                    result = response.Content.ReadAsAsync<SolSeguimiento_Result>().Result;
                }

                return Ok(result);

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
        [Route("fechadpi")]
        public async Task<IHttpActionResult> FechaDPI([FromUri] string cui)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                WSEmpleados.WSEmpleados ws = new WSEmpleados.WSEmpleados();
                string fechaDpi = "";

                fechaDpi = ws.fechaDPI(cui);

                return Ok(fechaDpi);
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
            string url = ConfigurationManager.AppSettings["dgCore"];
            List<Solicitudes_Result> sol;
            string ret="";
            Uri BaseUriDG = new Uri(url);

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



        //// VACACIONES


        /// <summary>
        /// Buscar empleado
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Buscar")]
        public Buscar_Result buscar([FromUri] string buscar)
        {
            Buscar_Result lst = new Buscar_Result();

            if (!ModelState.IsValid)
            {
                throw new Exception("Error en los parametros");
            }

            WSVacaciones.WSVacaciones ws = new WSVacaciones.WSVacaciones();

            DataTable ret = ws.Buscar(buscar);
            DataTableReader dr = ret.CreateDataReader();

            while (dr.Read())
            {
                Buscar_Result c = new Buscar_Result();

                c.Correlativo = Convert.ToString(dr["Correlativo"]);
                c.Codigo = Convert.ToString(dr["Codigo"]);
                c.Nombre = Convert.ToString(dr["Nombre"]);
                c.Tipo = Convert.ToString(dr["Tipo"]);
                c.Extension = Convert.ToString(dr["Extension"]);
                c.Foto = Convert.ToString(dr["Foto"]);

                lst = c;
            }
            return lst;
        }


        /// <summary>
        /// Datos del empleado para vacaciones
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DatosEmpleadoVacaciones")]
        public DatosEmplVac_Result datosEmpleadoVacaciones([FromUri] string correlativo)
        {
            DatosEmplVac_Result lst = new DatosEmplVac_Result();

            if (!ModelState.IsValid)
            {
                throw new Exception("Error en los parametros");
            }

            WSVacaciones.WSVacaciones ws = new WSVacaciones.WSVacaciones();

            DataTable ret = ws.DatosEmpleadosVacaciones(correlativo);
            DataTableReader dr = ret.CreateDataReader();

            while (dr.Read())
            {
                DatosEmplVac_Result c = new DatosEmplVac_Result();
                
                c.Codigo = Convert.ToString(dr["Codigo"]);
                c.Nombre = Convert.ToString(dr["Nombre"]);
                c.Departamento = Convert.ToString(dr["Departamento"]);
                c.Puesto = Convert.ToString(dr["Puesto"]);
                c.Jefe = Convert.ToString(dr["Jefe"]);
                c.FechaIngreso = Convert.ToString(dr["FechaIngreso"]);
                c.Nomina = Convert.ToString(dr["Nomina"]);
                c.DiasDerecho = Convert.ToString(dr["DiasDerecho"]);
                c.DiasVacacionesFinDeAnio = Convert.ToString(dr["DiasVacacionesFinDeAnio"]);
                c.DiasTotales = Convert.ToString(dr["DiasTotales"]);

                lst = c;
            }
            return lst;
        }


        /// <summary>
        /// Retornar los periodos de vacaciones
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("PeriodosVacaciones")]
        public IHttpActionResult periodosVacaciones([FromUri] PeriodosVacModel Data)
        {
            PeriodosVac_Result per = new PeriodosVac_Result();
            List<DataPeriods> lst = new List<DataPeriods>();

            if (!ModelState.IsValid)
            {
                throw new Exception("Error en los parametros");
            }

            try
            {
                WSVacaciones.WSVacaciones ws = new WSVacaciones.WSVacaciones();

                DataTable ret = ws.periodosVacaciones(Data.correlativo, Data.dias, Data.fecha_inicio, Data.consultarPeriodos);
                DataTableReader dr = ret.CreateDataReader();

                while (dr.Read())
                {
                    DataPeriods c = new DataPeriods();

                    c.Periodo = Convert.ToString(dr["Periodo"]);
                    c.DiasDerecho = Convert.ToString(dr["DiasDerecho"]);
                    c.DiasGozados = Convert.ToString(dr["DiasGozados"]);
                    c.DiasPendientes = Convert.ToString(dr["DiasPendientes"]);
                    c.FechaInicio = Convert.ToString(dr["FechaInicio"]);
                    c.FechaFin = Convert.ToString(dr["FechaFin"]);
                    c.TotalDias = Convert.ToString(dr["TotalDias"]);

                    lst.Add(c);
                }

                per.error = false;
                per.data = lst;
            }
            catch(Exception e)
            {
                per.error = true;
                per.mensaje_error = obtenerMensaje(e.Message, "msg;");
                per.data = lst;
                return Ok(per);
            }
            
            return Ok(per);
        }

        private string obtenerMensaje(string mensaje, string indicador)
        {
            int pos1 = mensaje.IndexOf(indicador) + indicador.Length;
            mensaje = mensaje.Remove(0, pos1);
            int pos2 = mensaje.IndexOf(indicador);
            mensaje = mensaje.Remove(pos2, mensaje.Length - pos2);

            return mensaje.Trim();
        }


        /// <summary>
        /// Genera solicitud de vacaciones en Dynamics
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GenerarVacaciones")]
        public IHttpActionResult generarVacaciones([FromBody] GenerarVacModel VacacionesData)
        {
            string ret = "";

            if (!ModelState.IsValid)
            {
                throw new Exception("Error en los parametros");
            }

            try
            {
                WSVacaciones.WSVacaciones ws = new WSVacaciones.WSVacaciones();

                ret = ws.generarVacacionDynamics(VacacionesData.correlativo, VacacionesData.dias, VacacionesData.fecha_inicio, VacacionesData.usuario_oracle, VacacionesData.solicitud_tramite);                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok(ret);
        }

    }
}
