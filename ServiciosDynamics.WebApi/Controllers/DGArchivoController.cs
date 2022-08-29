using Newtonsoft.Json;
using ServiciosDynamics.WebApi.Models.DG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

                //WSDGArchivo.WSDGArchivo ws = new WSDGArchivo.WSDGArchivo();

                /*string ret = ws.obtenerIdArchivo(
                        archivoData.aplicacion,
                        archivoData.categoria,
                        archivoData.etiquetas
                    );*/

                string ret = ObtenerArchivos(archivoData.aplicacion,
                        archivoData.categoria.ToString(),
                        archivoData.etiquetas);

                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public string ObtenerArchivos(string Aplicacion, string Categoria, string Etiquetas)
        {
            string ret = "";
            Uri BaseUriDG = new Uri("https://dg.galileo.edu/DG/");

            char[] separador = { '&' };
            char[] separador2 = { '=' };
            String[] listLabel = Etiquetas.Split(separador);
            try
            {
                using (var client = new HttpClient())
                {
                    List<Etiquetas> ets = new List<Etiquetas>();
                    Etiquetas et = new Etiquetas();

                    int i = 0;
                    foreach (String label in listLabel)
                    {
                        et = new Etiquetas();
                        String[] ValueLabel = label.Split(separador2);
                        et.Etiqueta = Int16.Parse(ValueLabel[0]);
                        et.Valor = ValueLabel[1];
                        ets.Add(et);
                        i++;
                    }

                    ObtenerArchivos arch = new ObtenerArchivos();
                    arch.Aplicacion = Aplicacion;
                    arch.categoria = Categoria;
                    arch.Etiquetas = ets;

                    client.BaseAddress = BaseUriDG;
                    client.DefaultRequestHeaders.Accept.Clear();

                    StringContent Content = new StringContent(JsonConvert.SerializeObject(arch), Encoding.UTF8, "application/json");
                    HttpContent httpContent = Content;
                    httpContent.Headers.Add("Token", "Dynamics");
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                    HttpResponseMessage response = client.PostAsync("api/DG/ObtenerArchivos", httpContent).Result;

                    response.EnsureSuccessStatusCode();

                    List<ObtenerArchivos_Result> res = JsonConvert.DeserializeObject<List<ObtenerArchivos_Result>>(response.Content.ReadAsStringAsync().Result);

                    int filaFechaMaxima = 0, cont = 0;
                    DateTime fecha = Convert.ToDateTime("01/01/2000");
                    foreach (var item in res)
                    {
                        cont++;

                        if (fecha < item.Fecha)
                        {
                            filaFechaMaxima = cont;
                            fecha = item.Fecha;
                        }
                    }
                    ret = res[filaFechaMaxima - 1].IdArchivo;
                }
                var variable = Encoding.UTF8.GetBytes(ret);
                //return ret;
                return Convert.ToBase64String(variable);

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// Subir archivo de sanciones
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("cargar_sancion")]
        public IHttpActionResult subirArchivoSanciones([FromUri] SubirSancionModel archivoData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                WSDGArchivo.WSDGArchivo ws = new WSDGArchivo.WSDGArchivo();

                string ret = ws.SubirArchivo(archivoData.nombre_archivo);

                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Consultar el numero de archivo
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("sendEmail")]
        public IHttpActionResult enviarCorreo([FromBody] CorreosModel Data)
        {
            Uri BaseUriDG = new Uri("https://dg.galileo.edu/core/");

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = BaseUriDG;
                    client.DefaultRequestHeaders.Accept.Clear();

                    StringContent Content = new StringContent(JsonConvert.SerializeObject(Data), Encoding.UTF8, "application/json");
                    HttpContent httpContent = Content;
                    httpContent.Headers.Add("Token", "Dynamics");
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                    HttpResponseMessage response = client.PostAsync("api/Correos/Comentario", httpContent).Result;

                    response.EnsureSuccessStatusCode();

                    var res = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                }
                return Ok(true);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    
}
