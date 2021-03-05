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

namespace ServiciosDynamics.WebApi.Controllers
{
    /// <summary>
    /// API de facturas
    /// </summary>
    [RoutePrefix("api/Facturas")]
    public class InvoiceController : ApiController
    {

        /// <summary>
        /// Guarda las facturas en Dynamics
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("Guardar")]
        public IHttpActionResult Guardar([FromBody] InvoiceModel invoiceData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                WSFacturas.WSFacturas ws = new WSFacturas.WSFacturas();

                string ret = ws.agregarFactura(
                    invoiceData.proveedor,
                    invoiceData.factura_serie,
                    invoiceData.factura_numero,
                    invoiceData.fecha,
                    invoiceData.descripcion,
                    Convert.ToDecimal(invoiceData.monto),
                    invoiceData.id_detalle,
                    invoiceData.type_staff,
                    invoiceData.usuario_oracle,
                    (invoiceData.no_tramite == null ? "" : invoiceData.no_tramite )
                    );

                if(ret == "Correcto")
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(ret);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Valida las facturas en Dynamics
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("existeFactura")]
        public IHttpActionResult Existe([FromUri] ValidInvoiceModel invoiceData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                WSFacturas.WSFacturas ws = new WSFacturas.WSFacturas();

                bool ret = ws.validarFactura(
                    invoiceData.proveedor,
                    invoiceData.factura_serie,
                    invoiceData.factura_numero
                    );

                return Ok(ret);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene la informacion bancaria del docente
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("infobancaria")]
        public IEnumerable<InfoBancariaDocente_Result> infoBancariaDocente([FromUri] string codpers)
        {
            List<InfoBancariaDocente_Result> lst = new List<InfoBancariaDocente_Result>();

            if(codpers == "" || codpers == null)
            {
                throw new Exception("Error en los parametros");
            }   

            WSFacturas.WSFacturas ws = new WSFacturas.WSFacturas();

            DataTable ret = ws.infoBancariaDocente(codpers);
            DataTableReader dr = ret.CreateDataReader();

            while (dr.Read())
            {
                InfoBancariaDocente_Result c = new InfoBancariaDocente_Result();

                c.Formapago = Convert.ToString(dr["Formapago"]);
                c.Banco = Convert.ToString(dr["Banco"]);
                c.Nombre_banco = Convert.ToString(dr["Nombre_banco"]);
                c.Tipocuenta = Convert.ToString(dr["Tipocuenta"]);
                c.Nombre_tipocuenta = Convert.ToString(dr["Nombre_Tipocuenta"]);
                c.Cuentabancaria = Convert.ToString(dr["Cuenta"]);
                c.Proveedor = Convert.ToString(dr["Proveedor"]);
                c.Nombre_proveedor = Convert.ToString(dr["Nombre_proveedor"]);

                lst.Add(c);
            }
            return lst;

        }


        /// <summary>
        /// retorna si es docente o no
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("esdocente")]
        public IHttpActionResult esDocente([FromUri] string codpers)
        {
            try
            {
                if (codpers == "" || codpers == null)
                {
                    throw new Exception("Error en los parametros");
                }

                WSFacturas.WSFacturas ws = new WSFacturas.WSFacturas();

                bool ret = ws.validaEsDocente(
                    codpers
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
