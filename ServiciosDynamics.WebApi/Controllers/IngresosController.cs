using System.Configuration;
using Newtonsoft.Json.Linq;
using ServiciosDynamics.WebApi.Models.Ingresos;
using ServiciosDynamics.WebApi.Models.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;

namespace ServiciosDynamics.WebApi.Controllers
{
    /// <summary>
    /// API de ingresos
    /// </summary>
    [RoutePrefix("api/ingresos")]
    public class IngresosController : ApiController
    {
        /// <summary>
        /// Encabezado de ingresos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ingresos")]
        public IEnumerable<Ingresos_Result> Ingresos([FromUri] IngresosModel ingresosData)
        {
            List<Ingresos_Result> lst = new List<Ingresos_Result>();

            if (!ModelState.IsValid)
            {
                throw new Exception("Error en los parametros");
            }

            WSIngresos.WSIngresos ws = new WSIngresos.WSIngresos();

            DataTable ret = ws.ingresos(ingresosData.origen, ingresosData.fecha_inicio, ingresosData.fecha_fin);
            DataTableReader dr = ret.CreateDataReader();

            while (dr.Read())
            {
                Ingresos_Result c = new Ingresos_Result();

                c.RECIBO = Convert.ToString(dr["RECIBO"]);
                c.FECHA = Convert.ToString(dr["FECHA"]);
                c.CARRERA = Convert.ToString(dr["CARRERA"]);
                c.TIPO = Convert.ToString(dr["TIPO"]);
                c.TOTAL = Convert.ToString(dr["TOTAL"]);
                c.ORIG = Convert.ToString(dr["ORIG"]);
                c.STATUS = Convert.ToString(dr["STATUS"]);
                c.CARNE = Convert.ToString(dr["CARNE"]);
                c.ALUMNO = Convert.ToString(dr["ALUMNO"]);
                c.CARNOMBRE = Convert.ToString(dr["CARNOMBRE"]);
                c.TIPOCLIENTE = Convert.ToString(dr["TIPOCLIENTE"]);
                c.CCODE = Convert.ToString(dr["CCODE"]);
                c.CFACULTAD = Convert.ToString(dr["CFACULTAD"]);
                c.FOPERATE = Convert.ToString(dr["FOPERATE"]);
                c.FREGISTER = Convert.ToString(dr["FREGISTER"]);
                c.FUP = Convert.ToString(dr["FUP"]);
                c.ROWID = Convert.ToString(dr["ROWID"]);
                c.CARRERA_SEDE = Convert.ToString(dr["CARRERA_SEDE"]);
                c.RAZON_SOCIAL = Convert.ToString(dr["RAZON_SOCIAL"]);
                c.NIT = Convert.ToString(dr["NIT"]);
                c.SERIE = Convert.ToString(dr["SERIE"]);
                c.PREIMPRESO = Convert.ToString(dr["PREIMPRESO"]);
                c.AUTORIZACION = Convert.ToString(dr["AUTORIZACION"]);
                c.FECHA_EMISIONFEL = Convert.ToString(dr["FECHA_EMISIONFEL"]);
                c.STATUS_FEL = Convert.ToString(dr["STATUS_FEL"]);

                lst.Add(c);
            }
            return lst;
        }


        /// <summary>
        /// Detalle de ingresos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ingresos_conceptos")]
        public IEnumerable<IngresosConceptos_Result> Ingresos_Conceptos([FromUri] IngresosConceptosModel ingresosConceptosData)
        {
            List<IngresosConceptos_Result> lst = new List<IngresosConceptos_Result>();

            if (!ModelState.IsValid)
            {
                throw new Exception("Error en los parametros");
            }

            WSIngresos.WSIngresos ws = new WSIngresos.WSIngresos();

            DataTable ret = ws.ingresos_conceptos(ingresosConceptosData.recibo, ingresosConceptosData.fecha, ingresosConceptosData.tipo);
            DataTableReader dr = ret.CreateDataReader();

            while (dr.Read())
            {
                IngresosConceptos_Result c = new IngresosConceptos_Result();

                c.CONCEPTO = Convert.ToString(dr["CONCEPTO"]);
                c.VALOR = Convert.ToString(dr["VALOR"]);
                c.FECHA = Convert.ToString(dr["FECHA"]);
                c.TIPO = Convert.ToString(dr["TIPO"]);
                c.CORRELATIVO = Convert.ToString(dr["CORRELATIVO"]);
                c.ROWID = Convert.ToString(dr["ROWID"]);               

                lst.Add(c);
            }
            return lst;
        }


        /// <summary>
        /// Inserta Hingresos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("insert_hingresos")]
        public IHttpActionResult Insert_Hingresos([FromUri] string recibo, string fecha, string tipo)
        {
            WSIngresos.WSIngresos ws = new WSIngresos.WSIngresos();
            return Ok(ws.insertHingresos(recibo, fecha, tipo));
        }

        /// <summary>
        /// Inserta Hingresos conceptos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("insert_hingresos_conceptos")]
        public IHttpActionResult Insert_Hingresos_Conceptos([FromUri] string recibo, string fecha, string tipo)
        {
            WSIngresos.WSIngresos ws = new WSIngresos.WSIngresos();
            return Ok(ws.insertHingresos_Conceptos(recibo,fecha,tipo));
        }

        /// <summary>
        /// Inserta Hingresos pago
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("insert_hingresos_pago")]
        public IHttpActionResult Insert_Hingresos_Pago([FromUri] string recibo, string fecha, string tipo)
        {
            WSIngresos.WSIngresos ws = new WSIngresos.WSIngresos();
            return Ok(ws.insertHingresos_pago(recibo, fecha, tipo));
        }


        /// <summary>
        /// Elimina Ingresos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("delete_ingresos")]
        public IHttpActionResult Delete_Ingresos([FromUri] string recibo, string fecha, string tipo)
        {
            WSIngresos.WSIngresos ws = new WSIngresos.WSIngresos();
            return Ok(ws.deleteIngresos(recibo, fecha, tipo));
        }

        /// <summary>
        /// Elimina Ingresos Conceptos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("delete_ingresos_conceptos")]
        public IHttpActionResult Delete_Ingresos_Conceptos([FromUri] string recibo, string fecha, string tipo)
        {
            WSIngresos.WSIngresos ws = new WSIngresos.WSIngresos();
            return Ok(ws.deleteIngresos_Conceptos(recibo, fecha, tipo));
        }

        /// <summary>
        /// Elimina Ingresos Pago
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("delete_ingresos_pago")]
        public IHttpActionResult Delete_Ingresos_Pago([FromUri] string recibo, string fecha, string tipo)
        {
            WSIngresos.WSIngresos ws = new WSIngresos.WSIngresos();
            return Ok(ws.deleteIngresos_pago(recibo, fecha, tipo));
        }




        /// <summary>
        /// Cuenta Ingresos Conceptos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("count_ingresos_conceptos")]
        public IHttpActionResult Count_Ingresos_Conceptos([FromUri] string origen, string fecha_inicial, string fecha_final)
        {
            WSIngresos.WSIngresos ws = new WSIngresos.WSIngresos();
            return Ok(ws.countIngresos_conceptos(origen, fecha_final, fecha_final));
        }

        /// <summary>
        /// Cuenta Ingresos Pago
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("count_ingresos_pago")]
        public IHttpActionResult Count_Ingresos_pago([FromUri] string origen, string fecha_inicial, string fecha_final)
        {
            WSIngresos.WSIngresos ws = new WSIngresos.WSIngresos();
            return Ok(ws.countIngresos_pago(origen, fecha_final, fecha_final));
        }

        /// <summary>
        /// Cuenta Ingresos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("count_ingresos")]
        public IHttpActionResult Count_Ingresos([FromUri] string origen, string fecha_inicial, string fecha_final)
        {
            WSIngresos.WSIngresos ws = new WSIngresos.WSIngresos();
            return Ok(ws.countIngresos(origen, fecha_final, fecha_final));
        }


        /// <summary>
        /// Retorna las carreras que no estan configuradas en Dynamics
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("carreras_faltantes")]
        public IEnumerable<CarreraFaltante_Result> CarrerasFaltantes([FromUri] string origen, string fecha_inicial, string fecha_final)
        {
            List<CarreraFaltante_Result> lst = new List<CarreraFaltante_Result>();

            if ((origen == "" || origen == null) && (fecha_inicial == "" || fecha_inicial == null) && (fecha_final == "" || fecha_final == null))
            {
                throw new Exception("Error en los parametros");
            }

            WSIngresos.WSIngresos ws = new WSIngresos.WSIngresos();
            DataTable ret = ws.carrerasFaltantes(origen,fecha_inicial,fecha_final).Tables[0];
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
        /// Retorna los conceptos que no estan configuradas en Dynamics
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("conceptos_faltantes")]
        public IEnumerable<ConceptoFaltante_Result> ConceptosFaltantes([FromUri] string origen, string fecha_inicial, string fecha_final)
        {
            List<ConceptoFaltante_Result> lst = new List<ConceptoFaltante_Result>();

            if ((origen == "" || origen == null) && (fecha_inicial == "" || fecha_inicial == null) && (fecha_final == "" || fecha_final == null))
            {
                throw new Exception("Error en los parametros");
            }

            WSIngresos.WSIngresos ws = new WSIngresos.WSIngresos();
            DataTable ret = ws.conceptosFaltantes(origen, fecha_inicial, fecha_final).Tables[0];
            DataTableReader dr = ret.CreateDataReader();

            while (dr.Read())
            {
                ConceptoFaltante_Result c = new ConceptoFaltante_Result();

                c.concepto = Convert.ToString(dr["CONCEPTO"]);

                lst.Add(c);
            }
            return lst;

        }
    }
}
