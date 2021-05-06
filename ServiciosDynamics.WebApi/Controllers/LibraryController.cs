using ServiciosDynamics.WebApi.Models.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Serialization;

namespace ServiciosDynamics.WebApi.Controllers
{
    /// <summary>
    /// API de Libraria
    /// </summary>
    [RoutePrefix("api/libreria")]
    public class LibraryController : ApiController
    {
        [HttpGet]
        [Route("asignacion")]
        public IHttpActionResult asignacion([FromUri] CarneModel carneData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                string carne = carneData.carnet.ToUpper().Replace("IDE", "").Trim();
                InfoAlumnoLibreria_Result c = new InfoAlumnoLibreria_Result();

                WSLibreria.WSLibreria ws = new WSLibreria.WSLibreria();

                c.nombreAlumno = ws.nombreAlumno(carne);

                DataTable dt = ws.cursosAsigAlumno(carne);

                List<CursoAsig> lst = new List<CursoAsig>();

                foreach (DataRow row in dt.Rows)
                {
                    CursoAsig ca = new CursoAsig();
                    ca.curso = Convert.ToString(row["CURSO"]);
                    lst.Add(ca);
                }
                c.cursos = lst;

                return Ok(c);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("actualizar_inventario")]
        public IHttpActionResult actualizar_inventario([FromBody] DatosReciboModel reciboData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var stringwriter = new System.IO.StringWriter();
                var serializer = new XmlSerializer(reciboData.GetType());
                serializer.Serialize(stringwriter, reciboData);

                string toXmlObject = stringwriter.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n", "").Replace("\r\n", "").Replace(" ", "").Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"","");

                WSLibreria.WSLibreria ws = new WSLibreria.WSLibreria();
                string resp = ws.createSalesOrder(toXmlObject);

                if(resp != "correcto")
                {
                    throw new Exception(resp);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        [Route("anular_recibo")]
        public IHttpActionResult anular_recibo([FromBody] ReciboModel reciboData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                WSLibreria.WSLibreria ws = new WSLibreria.WSLibreria();
                string resp = ws.cancelSalesOrder(reciboData.recibo);

                if (resp != "correcto")
                {
                    throw new Exception(resp);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
