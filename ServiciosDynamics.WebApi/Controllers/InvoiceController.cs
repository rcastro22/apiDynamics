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
        /// Valida las facturas en Dynamics por NIT
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("existeFacturaNit")]
        public InfoExcenciones_Result ExisteNit([FromUri] ValidInvoiceNitModel invoiceData)
        {
                    
            /*if (!ModelState.IsValid)
            {
                return BadRequest();
            }*/

            WSFacturas.WSFacturas ws = new WSFacturas.WSFacturas();

            string ret = ws.validarFacturaNit(
                invoiceData.nit,
                invoiceData.factura_serie,
                invoiceData.factura_numero
                );
            
            InfoExcenciones_Result info = new InfoExcenciones_Result();

            try
            {
                String[] listData = ret.Split('$');
                info.Referencia = listData[0];
                info.Proveedor = listData[1];
                info.Docente = listData[2];
                info.ProveedorNombre = listData[3];
            }
            catch(Exception e)
            {
                info.Referencia = "";
                info.Proveedor = "";
                info.Docente = "";
                info.ProveedorNombre = "";
            }
            

            return info;

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


        /// <summary>
        /// Agrega las excenciones a Dynamics
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("agregaExencion")]
        public IHttpActionResult AgregaExencion([FromBody] GuardaAutorizacionModel exenData)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                WSFacturas.WSFacturas ws = new WSFacturas.WSFacturas();

                ws.agregarExension(
                    exenData.autorizacion,
                    exenData.ref_interna,
                    exenData.fecha_autorizacion,
                    exenData.nit,
                    exenData.factura_serie,
                    exenData.factura_numero
                    );

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Retorna los catedraticos que no estan configurados en Dynamics
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("catedraticos_faltantes")]
        public IEnumerable<CatedraticoFaltante_Result> CatedraticosFaltantes([FromUri] string origen, string fecha)
        {
            List<CatedraticoFaltante_Result> lst = new List<CatedraticoFaltante_Result>();

            if ((origen == "" || origen == null) && (fecha == "" || fecha == null))
            {
                throw new Exception("Error en los parametros");
            }

            WSInterfaceDyn.WSInterfaceDynamics ws = new WSInterfaceDyn.WSInterfaceDynamics();
            DataTable ret = ws.CatedrativosFaltantesUG(fecha, origen).Tables[0];
            DataTableReader dr = ret.CreateDataReader();

            while (dr.Read())
            {
                CatedraticoFaltante_Result c = new CatedraticoFaltante_Result();

                c.catedratico = Convert.ToString(dr["CATEDRATICO"]);
                c.nombre = Convert.ToString(dr["NOMBRE"]);

                lst.Add(c);
            }
            return lst;

        }

        /// <summary>
        /// Retorna las carreras que no estan configuradas en Dynamics
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("carreras_faltantes")]
        public IEnumerable<CarreraFaltante_Result> CarrerasFaltantes([FromUri] string origen, string fecha)
        {
            List<CarreraFaltante_Result> lst = new List<CarreraFaltante_Result>();

            if ((origen == "" || origen == null) && (fecha == "" || fecha == null))
            {
                throw new Exception("Error en los parametros");
            }

            WSInterfaceDyn.WSInterfaceDynamics ws = new WSInterfaceDyn.WSInterfaceDynamics();
            DataTable ret = ws.CarrerasFaltantesUG(fecha, origen).Tables[0];
            DataTableReader dr = ret.CreateDataReader();

            while (dr.Read())
            {
                CarreraFaltante_Result c = new CarreraFaltante_Result();

                c.carrera = Convert.ToString(dr["CARRERA"]);

                lst.Add(c);
            }
            return lst;

        }


        /// <summary>
        /// Informacion de Pagos por Facturacion
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("info_pago_facturacion")]
        public IEnumerable<InfoPagoFacturacion_Result> InfoPagosFacturacion([FromUri] string origen, string fecha)
        {
            List<InfoPagoFacturacion_Result> lst = new List<InfoPagoFacturacion_Result>();

            if ((origen == "" || origen == null) && (fecha == "" || fecha == null))
            {
                throw new Exception("Error en los parametros");
            }

            WSFacturas.WSFacturas ws = new WSFacturas.WSFacturas();
            DataTable ret = ws.infoPagoFacturacion(origen, fecha);
            DataTableReader dr = ret.CreateDataReader();

            DataTable ret2;
            DataTableReader dr2;

            while (dr.Read())
            {
                InfoPagoFacturacion_Result c = new InfoPagoFacturacion_Result();

                c.CATEDRATICO = Convert.ToString(dr["CATEDRATICO"]);
                c.REFERENCIA = Convert.ToString(dr["REFERENCIA"]);
                c.MONTO = Convert.ToString(dr["MONTO"]);
                c.FECHAPROVISION = Convert.ToString(dr["FECHAPROVISION"]);
                c.FECHAPAGO = Convert.ToString(dr["FECHAPAGO"]);
                c.NOMINA = Convert.ToString(dr["NOMINA"]);
                c.CORRELATIVO = Convert.ToString(dr["CORRELATIVO"]);
                c.NOMBRE = Convert.ToString(dr["NOMBRE"]);
                c.PORTAL = Convert.ToString(dr["PORTAL"]);
                c.FECHAIMP = Convert.ToString(dr["FECHAIMP"]);
                c.CURSOS = Convert.ToString(dr["CURSOS"]);
                c.ALUMNOSCURSO = Convert.ToString(dr["ALUMNOSCURSO"]);
                c.FECHA = Convert.ToString(dr["FECHA"]);
                c.TIPONOMINA = Convert.ToString(dr["TIPONOMINA"]);
                c.PUESTO = Convert.ToString(dr["PUESTO"]);
                c.ROWID = Convert.ToString(dr["ROWID"]);

                ret2 = ws.infoPagoDetalle(c.NOMINA, c.CORRELATIVO);
                dr2 = ret2.CreateDataReader();
                List<InfoPagoDetalle_Result> lst2 = new List<InfoPagoDetalle_Result>();

                while (dr2.Read())
                {
                    InfoPagoDetalle_Result c2 = new InfoPagoDetalle_Result();

                    c2.CARRERA = Convert.ToString(dr2["CARRERA"]);
                    c2.MONTO = Convert.ToString(dr2["MONTO"]);
                    c2.ROWID = Convert.ToString(dr2["ROWID"]);

                    lst2.Add(c2);
                }
                c.Detalle = lst2;

                lst.Add(c);
            }
            return lst;

        }


        /// <summary>
        /// Inserta Hpago
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("insert_hpago")]
        public IHttpActionResult Insert_Hpago([FromUri] string nomina, string correlativo)
        {
            WSFacturas.WSFacturas ws = new WSFacturas.WSFacturas();
            return Ok(ws.insertHpagos(nomina, correlativo));
        }


        /// <summary>
        /// Inserta HpagoUgaDetalle
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("insert_hpagougadetalle")]
        public IHttpActionResult Insert_HpagoUga_Detalle([FromUri] string nomina, string correlativo)
        {
            WSFacturas.WSFacturas ws = new WSFacturas.WSFacturas();
            return Ok(ws.insertHpagosUgaDetalle(nomina, correlativo));
        }


        /// <summary>
        /// Elimina PagosUga
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("delete_pagosuga")]
        public IHttpActionResult Delete_PagosUga([FromUri] string nomina, string correlativo)
        {
            WSFacturas.WSFacturas ws = new WSFacturas.WSFacturas();
            return Ok(ws.deletePagosUga(nomina, correlativo));
        }


        /// <summary>
        /// Elimina PagoUgaDetalle
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("delete_pagougadetalle")]
        public IHttpActionResult Delete_PagoUga_Detalle([FromUri] string nomina, string correlativo)
        {
            WSFacturas.WSFacturas ws = new WSFacturas.WSFacturas();
            return Ok(ws.deletePagosUgaDetalle(nomina, correlativo));
        }
    }
}
