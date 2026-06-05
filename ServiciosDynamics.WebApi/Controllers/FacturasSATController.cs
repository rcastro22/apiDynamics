using HtmlAgilityPack;
using Newtonsoft.Json;
using ServiciosDynamics.WebApi.Models.Employees;
using ServiciosDynamics.WebApi.Models.FacturaSat;
using ServiciosDynamics.WebApi.WSFacturas;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;
using LoadInvoiceSATGT;

namespace ServiciosDynamics.WebApi.Controllers
{
    /// <summary>
    /// API de facturas
    /// </summary>
    [RoutePrefix("api/facturasat")]
    public class FacturasSATController : ApiController
    {
        
        [HttpPost]
        [Route("obtenerFacturasSAT")]
        public async Task<IHttpActionResult> obtenerFacturasSAT([FromBody] FacturasModel model)
        {
            string token, accessToken,felToken;
            string usuarioConsulta = model.usuario;

            WSFacturas.WSFacturas wSFacturas = new WSFacturas.WSFacturas();
            string userDelegated = wSFacturas.obtenerDelegadoSAT(model.usuario);            

            try
            {
                token = wSFacturas.obtenerTokenSAT(model.usuario);
                if (string.IsNullOrEmpty(token))
                {
                    string pwd = wSFacturas.obtenerContraseniaSAT(model.usuario);
                    pwd = Encoding.UTF8.GetString(Convert.FromBase64String(pwd));

                    var tokenResponse = await FacturasSAT.GetAccessToken(model.usuario, pwd, userDelegated);

                    if (!string.IsNullOrEmpty(tokenResponse.access_token) && !string.IsNullOrEmpty(tokenResponse.fel_token))
                    {
                        DateTime expires = tokenResponse.expires_token;

                        wSFacturas.guardarTokenSAT(model.usuario, tokenResponse.access_token, tokenResponse.fel_token, expires);
                    }

                    token = tokenResponse.access_token + "|" + tokenResponse.fel_token;

                }
                var tokenParts = token.Split('|');
                accessToken = tokenParts[0];
                felToken = tokenParts.Length > 1 ? tokenParts[1] : null;
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError,
                    new { message = $"Error al obtener token: {ex.Message}" });
            }

            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(felToken))
                return Content(HttpStatusCode.InternalServerError,
                    new { message = "No pudo generarse token de sesión con la SAT" });

            try
            {
                FacturasSAT SATService = new FacturasSAT();
                string xmlResult = "";

                xmlResult = await SATService.ConsultarFacturasAsync(
                model.usuario, usuarioConsulta, accessToken, felToken, model.fechaEmisionIni, model.fechaEmisionFinal, (string.IsNullOrEmpty(model.nitEmisor) ? "" : model.nitEmisor));
                
                var result = xmlResult;
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError,
                    new { message = $"Error al obtener facturas: {ex.Message}" });
            }
        }

    }

    
}
