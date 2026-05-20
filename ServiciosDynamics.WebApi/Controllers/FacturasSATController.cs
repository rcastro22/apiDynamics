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
                if (!string.IsNullOrEmpty(userDelegated))
                {
                    token = await GetAccessToken(model.usuario, userDelegated);
                    usuarioConsulta = userDelegated;
                }
                else
                {
                    token = await GetAccessToken(model.usuario);
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

            if (string.IsNullOrEmpty(accessToken))
                return Content(HttpStatusCode.InternalServerError,
                    new { message = "No pudo generarse token de sesión con la SAT" });

            try
            {
                // ─── REQUEST 7: GET consulta de facturas ──────────────────────────────
                string url7 = $"https://felcons.c.sat.gob.gt/dte-agencia-virtual/api/consulta-dte" +
                              $"?usuario={Uri.EscapeDataString(usuarioConsulta)}" +
                              $"&cui=&tipoOperacion=R&establecimiento=&tipoDte=" +
                              $"&noAutorizacion=&nitIdReceptor=&estadoDte=&serie=" +
                              $"&numero=&moneda=&montoTotalRangoIni=&montoTotalRangoFinal=" +
                              $"&impuesto=&nitCertificador=&resultado=" +
                              $"&fechaEmisionIni={Uri.EscapeDataString(model.fechaEmisionIni)}" +
                              $"&fechaEmisionFinal={Uri.EscapeDataString(model.fechaEmisionFinal)}";


                var cookieContainer = new CookieContainer();
                var handler = new HttpClientHandler
                {
                    CookieContainer = cookieContainer,
                    UseCookies = true
                };

                // Agregar la cookie al dominio específico
                cookieContainer.Add(
                    new Uri("https://felcons.c.sat.gob.gt"),
                    new Cookie("felTokc", felToken)
                );

                // Nueva instancia sin manejo de cookies para la llamada final con header Authtoken
                using (var clientFinal = new HttpClient(handler))
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, url7);

                    request.Headers.TryAddWithoutValidation("Authorization", accessToken);
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0");

                    // 12-05-2026, se cambia el header de Authtoken por Authorization, ya que la SAT ha actualizado su API para requerir este formato
                    //clientFinal.DefaultRequestHeaders.Add("Authtoken", $"token {accessToken}");

                    // El header Content-Type no es necesario para un GET, y la SAT no lo requiere, por lo que se comenta para evitar posibles errores de la API
                    //clientFinal.DefaultRequestHeaders.Add("Content-Type", "application/json");


                    var response7 = await clientFinal.SendAsync(request);
                    //var response7 = await clientFinal.GetAsync(url7);
                    string jsonResult = await response7.Content.ReadAsStringAsync();

                    //var result = JsonConvert.DeserializeObject(jsonResult);
                    XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(jsonResult, "Facturas");
                    var result = xmlDoc.InnerXml;
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError,
                    new { message = $"Error al obtener facturas: {ex.Message}" });
            }
        }


        // ─── Helper: extrae el valor de una cookie por nombre y dominio ──────────
        private static string GetCookieValue(
            CookieContainer container, string domain, string cookieName)
        {
            try
            {
                Uri uri = new Uri($"https://{domain}");
                CookieCollection cookies = container.GetCookies(uri);
                return cookies[cookieName]?.Value;
            }
            catch
            {
                return null;
            }
        }

        private static DateTime GetCookieExpires(
            CookieContainer container, string domain, string cookieName)
        {
            try
            {
                Uri uri = new Uri($"https://{domain}");
                CookieCollection cookies = container.GetCookies(uri);
                return cookies[cookieName].Expires;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }



        private static async Task<string> GetAccessToken(string _user)
        { 
            string token = null;

            WSFacturas.WSFacturas wSFacturas = new WSFacturas.WSFacturas();
            token = wSFacturas.obtenerTokenSAT(_user);

            if (string.IsNullOrEmpty(token))
            {
                string pwd = wSFacturas.obtenerContraseniaSAT(_user);

                // La variable pwd esta en base64, se decodifica a texto plano para usarla en el login
                pwd = Encoding.UTF8.GetString(Convert.FromBase64String(pwd));

                var cookieContainer = new CookieContainer();

                var handler = new HttpClientHandler
                {
                    CookieContainer = cookieContainer,
                    AllowAutoRedirect = true,
                    UseCookies = true
                };

                using (var client = new HttpClient(handler))
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    // ─── REQUEST 1: GET login para obtener cookies iniciales ───────────────
                    string url1 = "https://farm3.sat.gob.gt/";
                    client.BaseAddress = new Uri(url1);
                    client.DefaultRequestHeaders.Add("Accept", "application/json, text/html");
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                    var response1 = await client.GetAsync("menu/login.jsf");
                    response1.EnsureSuccessStatusCode();

                    // Extraer cookies del response 1
                    string jsessionId = GetCookieValue(cookieContainer, "farm3.sat.gob.gt/menu", "JSESSIONID");
                    string nscCookie = GetCookieValue(cookieContainer, "farm3.sat.gob.gt/menu", "NSC_mc_nfov_fyu");

                    // ─── REQUEST 2: POST login con credenciales ───────────────────────────
                    string url2 = $"https://farm3.sat.gob.gt/menu/login.jsf;jsessionid={jsessionId}";

                    var data2 = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("javax.faces.partial.ajax",    "true"),
                        new KeyValuePair<string, string>("javax.faces.source",          "formContent:cmdbtnIngresar"),
                        new KeyValuePair<string, string>("javax.faces.partial.execute", "@all"),
                        new KeyValuePair<string, string>("javax.faces.partial.render",  "formContent:otMensaje"),
                        new KeyValuePair<string, string>("formContent:cmdbtnIngresar",  "formContent:cmdbtnIngresar"),
                        new KeyValuePair<string, string>("formContent",                 "formContent"),
                        new KeyValuePair<string, string>("formContent:username",        _user),
                        new KeyValuePair<string, string>("formContent:password",        pwd),
                        new KeyValuePair<string, string>("formContent:inMaskVerifyCode",""),
                        new KeyValuePair<string, string>("javax.faces.ViewState",       "stateless")
                    });

                    var response2 = await client.PostAsync(url2, data2);
                    response2.EnsureSuccessStatusCode();
                    string doc2 = await response2.Content.ReadAsStringAsync();
                    if(doc2.Contains("Credenciales inválidas"))
                    {
                        throw new Exception("Credenciales inválidas");
                    }

                    // ─── REQUEST 3: GET portada para extraer URL y ViewState ──────────────
                    string url3 = "https://farm3.sat.gob.gt/menu/portada.jsf";
                    var response3 = await client.GetAsync(url3);
                    string html3 = await response3.Content.ReadAsStringAsync();

                    OnClickData dataPortada_1 = HtmlOnClickExtractor.portada1_ExtractByUrl(html3, "https://felcons.c.sat.gob.gt/dte-agencia-virtual/dte-consulta");

                    var doc3 = new HtmlDocument();
                    doc3.LoadHtml(html3);

                    // Extraer idhUrlSelected
                    var inputUrl = doc3.DocumentNode.SelectSingleNode("//input[@id='frmMenu:idhUrlSelected']");
                    string urlSelected = WebUtility.HtmlDecode(inputUrl?.GetAttributeValue("value", null))?.Replace(">", "%3E");

                    // Extraer ViewState
                    var inputViewState = doc3.DocumentNode.SelectSingleNode("//input[@id='j_id1:javax.faces.ViewState:0']");
                    string viewState = inputViewState?.GetAttributeValue("value", null);

                    // Extraer URL dinámica desde JS
                    var matchUrl = Regex.Match(html3,
                        @"document\.getElementById\('frmMenu:idhUrlSelected'\)\.value\s*=\s*'([^']+)'");
                    string urlSelected2 = matchUrl.Success
                        ? matchUrl.Groups[1].Value.Replace(">", "%3E")
                        : null;

                    if (string.IsNullOrEmpty(urlSelected))
                        throw new Exception("No pudo iniciarse sesión con la SAT");
                    //return Content(HttpStatusCode.InternalServerError,
                    //        new { message = "No pudo iniciarse sesión con la SAT" });

                    // ─── REQUEST 4: GET url_selected (doble llamada para rotar JSESSIONID) ─
                    string url4 = urlSelected;
                    var response4a = await client.GetAsync(url4);

                    // El nuevo JSESSIONID viene en las cookies del response 4a
                    string newJsessionId = GetCookieValue(cookieContainer,
                        new Uri(url4).Host, "JSESSIONID");

                    // Segunda llamada con el nuevo JSESSIONID
                    var response4b = await client.GetAsync(url4);

                    // ─── REQUEST 5: POST portada para obtener felTokc y url_token ─────────
                    string url5 = "https://farm3.sat.gob.gt/menu/portada.jsf";



                    var pairs_5 = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("javax.faces.partial.ajax",    "true"),
                        new KeyValuePair<string, string>("javax.faces.source",          dataPortada_1.s),
                        new KeyValuePair<string, string>("javax.faces.partial.execute", "@all"),
                        new KeyValuePair<string, string>(dataPortada_1.s,               dataPortada_1.s),
                        new KeyValuePair<string, string>("frmMenu",                     "frmMenu"),
                        new KeyValuePair<string, string>("frmMenu:idhUrlSelected",      urlSelected2 ?? ""),
                        new KeyValuePair<string, string>("frmMenu:itBuscarMobile",      ""),
                        new KeyValuePair<string, string>("javax.faces.ViewState",       viewState ?? "")
                    };

                    for (int i = 0; i < dataPortada_1.pa.Count; i++)
                    {
                        pairs_5.Add(new KeyValuePair<string, string>(dataPortada_1.pa[i].name, dataPortada_1.pa[i].value));
                    }

                    var data5 = new FormUrlEncodedContent(pairs_5);


                    var response5 = await client.PostAsync(url5, data5);
                    string html5 = await response5.Content.ReadAsStringAsync();

                    // Extraer url_token desde JS del response 5
                    var matchToken = Regex.Match(html5,
                        @"document\.getElementById\('iframeContent'\)\.contentWindow\.location\.replace\('([^']+)'\)");
                    string urlToken = matchToken.Success
                        ? matchToken.Groups[1].Value.Replace(">", "%3E")
                        : null;

                    if (string.IsNullOrEmpty(urlToken))
                        throw new Exception("No pudo generarse url de sesión con la SAT");
                    //return Content(HttpStatusCode.InternalServerError,
                    //        new { message = "No pudo generarse url de sesión con la SAT" });

                    // felTokc viene en las cookies del response 5
                    string felTokc = GetCookieValue(cookieContainer,
                        "farm3.sat.gob.gt", "felTokc");

                    // ─── REQUEST 6: GET url_token para obtener ACCESS_TOKEN ───────────────
                    string url6 = urlToken;
                    var response6 = await client.GetAsync(url6);

                    string accessToken = GetCookieValue(cookieContainer,
                        new Uri(url6).Host + "/dte-agencia-virtual/dte-consulta", "ACCESS_TOKEN");

                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        DateTime expires = GetCookieExpires(cookieContainer,
                            new Uri(url6).Host + "/dte-agencia-virtual/dte-consulta", "ACCESS_TOKEN");

                        wSFacturas.guardarTokenSAT(_user, accessToken, felTokc, expires);
                    }

                    token = accessToken + "|" + felTokc;

                }
            }

            return token;

        }




        private static async Task<string> GetAccessToken(string _user, string _userDelegated)
        {
            string token = null;

            WSFacturas.WSFacturas wSFacturas = new WSFacturas.WSFacturas();
            token = wSFacturas.obtenerTokenSAT(_user);

            if (string.IsNullOrEmpty(token))
            {
                string pwd = wSFacturas.obtenerContraseniaSAT(_user);

                // La variable pwd esta en base64, se decodifica a texto plano para usarla en el login
                pwd = Encoding.UTF8.GetString(Convert.FromBase64String(pwd));

                var cookieContainer = new CookieContainer();

                var handler = new HttpClientHandler
                {
                    CookieContainer = cookieContainer,
                    AllowAutoRedirect = true,
                    UseCookies = true
                };

                using (var client = new HttpClient(handler))
                {
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    // ─── REQUEST 1: GET login para obtener cookies iniciales ───────────────
                    string url1 = "https://farm3.sat.gob.gt/";
                    client.BaseAddress = new Uri(url1);
                    client.DefaultRequestHeaders.Add("Accept", "application/json, text/html");
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
                    var response1 = await client.GetAsync("menu/login.jsf");
                    response1.EnsureSuccessStatusCode();
                    string html1 = await response1.Content.ReadAsStringAsync();

                    var doc1 = new HtmlDocument();
                    doc1.LoadHtml(html1);
                    // Extraer delegado control
                    var inputDelegado = doc1.DocumentNode.SelectSingleNode("//input[@aria-label='Permisos delegados']");
                    string inputIdDelegadoCtrl = inputDelegado?.GetAttributeValue("id", null);

                    // Extraer cookies del response 1
                    string jsessionId = GetCookieValue(cookieContainer, "farm3.sat.gob.gt/menu", "JSESSIONID");
                    string nscCookie = GetCookieValue(cookieContainer, "farm3.sat.gob.gt/menu", "NSC_mc_nfov_fyu");

                    // ─── REQUEST 2: POST login con credenciales ───────────────────────────
                    string url2 = $"https://farm3.sat.gob.gt/menu/login.jsf;jsessionid={jsessionId}";

                    var data2 = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("javax.faces.partial.ajax",    "true"),
                        new KeyValuePair<string, string>("javax.faces.source",          "formContent:cmdbtnIngresar"),
                        new KeyValuePair<string, string>("javax.faces.partial.execute", "@all"),
                        new KeyValuePair<string, string>("javax.faces.partial.render",  "formContent:otMensaje"),
                        new KeyValuePair<string, string>("formContent:cmdbtnIngresar",  "formContent:cmdbtnIngresar"),
                        new KeyValuePair<string, string>("formContent",                 "formContent"),
                        new KeyValuePair<string, string>("formContent:username",        _user),
                        new KeyValuePair<string, string>("formContent:password",        pwd),
                        new KeyValuePair<string, string>(inputIdDelegadoCtrl,           "on"),
                        new KeyValuePair<string, string>("formContent:inMaskVerifyCode",""),
                        new KeyValuePair<string, string>("javax.faces.ViewState",       "stateless")
                    });

                    var response2 = await client.PostAsync(url2, data2);
                    response2.EnsureSuccessStatusCode();
                    string doc2 = await response2.Content.ReadAsStringAsync();
                    if (doc2.Contains("Credenciales inválidas"))
                    {
                        throw new Exception("Credenciales inválidas");
                    }

                    // ─── REQUEST 3: GET portada para extraer Data de Delegado y ViewState ──────────────
                    string url3 = "https://farm3.sat.gob.gt/menu/portada.jsf";
                    var response3 = await client.GetAsync(url3);
                    string html3 = await response3.Content.ReadAsStringAsync();

                    var doc3 = new HtmlDocument();
                    doc3.LoadHtml(html3);


                    // Extraer ViewState
                    var inputViewState = doc3.DocumentNode.SelectSingleNode("//input[@id='j_id1:javax.faces.ViewState:0']");
                    string viewState = inputViewState?.GetAttributeValue("value", null);


                    OnClickData dataPortada_1 = HtmlOnClickExtractor.portada1_ExtractByNitTitular(html3, _userDelegated);


                    // ─── REQUEST 5: POST portada para seleccionar cuenta y datos de formulario ─────────
                    string url4 = "https://farm3.sat.gob.gt/menu/portada.jsf";

                    var pairs_4 = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("javax.faces.partial.ajax",    "true"),
                        new KeyValuePair<string, string>("javax.faces.source",          dataPortada_1.s),
                        new KeyValuePair<string, string>("javax.faces.partial.execute", "@all"),
                        new KeyValuePair<string, string>("javax.faces.partial.render",  dataPortada_1.u),
                        new KeyValuePair<string, string>(dataPortada_1.s,               dataPortada_1.s),
                        new KeyValuePair<string, string>("frmMenu",                     "frmMenu"),
                        new KeyValuePair<string, string>("frmMenu:idhUrlSelected",      "default.jsf"),
                        new KeyValuePair<string, string>("frmMenu:itBuscarMobile",      ""),
                        new KeyValuePair<string, string>("javax.faces.ViewState",       viewState ?? ""),
                    };

                    for (int i = 0; i < dataPortada_1.pa.Count; i++)
                    {
                        pairs_4.Add(new KeyValuePair<string, string>(dataPortada_1.pa[i].name, dataPortada_1.pa[i].value));
                    }

                    var data4 = new FormUrlEncodedContent(pairs_4);

                    var response4 = await client.PostAsync(url4, data4);
                    string html4 = await response4.Content.ReadAsStringAsync();


                    OnClickData dataPortada_2 = HtmlOnClickExtractor.portada1_ExtractByUrl(html4, "https://farm2.sat.gob.gt/menu-redir-web/go/recaudacion/fel/dte/dte-consulta.html");


                    // Extraer idhUrlSelected
                    var inputUrl = doc3.DocumentNode.SelectSingleNode("//input[@id='frmMenu:idhUrlSelected']");
                    string urlSelected = WebUtility.HtmlDecode(inputUrl?.GetAttributeValue("value", null))?.Replace(">", "%3E");                    

                    // Extraer URL dinámica desde JS
                    var matchUrl = Regex.Match(html3,
                        @"document\.getElementById\('frmMenu:idhUrlSelected'\)\.value\s*=\s*'([^']+)'");
                    string urlSelected2 = matchUrl.Success
                        ? matchUrl.Groups[1].Value.Replace(">", "%3E")
                        : null;

                    if (string.IsNullOrEmpty(urlSelected))
                        throw new Exception("No pudo iniciarse sesión con la SAT");
                    //return Content(HttpStatusCode.InternalServerError,
                    //        new { message = "No pudo iniciarse sesión con la SAT" });


                    // ─── REQUEST 5: POST portada para obtener felTokc y url_token ─────────
                    string url5 = "https://farm3.sat.gob.gt/menu/portada.jsf";

                    var pairs_5 = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("javax.faces.partial.ajax",    "true"),
                        new KeyValuePair<string, string>("javax.faces.source",          dataPortada_1.s),
                        new KeyValuePair<string, string>("javax.faces.partial.execute", "@all"),
                        new KeyValuePair<string, string>(dataPortada_1.s,               dataPortada_1.s),                                                                                                                        
                        new KeyValuePair<string, string>("frmMenu",                     "frmMenu"),
                        new KeyValuePair<string, string>("frmMenu:idhUrlSelected",      "default.jsf"),
                        new KeyValuePair<string, string>("frmMenu:itBuscarMobile",      ""),
                        new KeyValuePair<string, string>("javax.faces.ViewState",       viewState ?? "")
                    };

                    for (int i = 0; i < dataPortada_2.pa.Count; i++)
                    {
                        pairs_5.Add(new KeyValuePair<string, string>(dataPortada_2.pa[i].name, dataPortada_2.pa[i].value));
                    }

                    var data5 = new FormUrlEncodedContent(pairs_5);                    

                    var response5 = await client.PostAsync(url5, data5);
                    string html5 = await response5.Content.ReadAsStringAsync();

                    // Extraer url_token desde JS del response 5
                    var matchToken = Regex.Match(html5,
                        @"document\.getElementById\('iframeContent'\)\.contentWindow\.location\.replace\('([^']+)'\)");
                    string urlToken = matchToken.Success
                        ? matchToken.Groups[1].Value.Replace(">", "%3E")
                        : null;

                    if (string.IsNullOrEmpty(urlToken))
                        throw new Exception("No pudo generarse url de sesión con la SAT");
                    //return Content(HttpStatusCode.InternalServerError,
                    //        new { message = "No pudo generarse url de sesión con la SAT" });


                    string url5b = urlToken;
                    var response5b = await client.GetAsync(url5b);
                    string html5b = await response5b.Content.ReadAsStringAsync();

                    
                    // felTokc viene en las cookies del response 5
                    string felTokc = GetCookieValue(cookieContainer,
                        "farm3.sat.gob.gt", "felTokc");

                    // ─── REQUEST 6: GET url_token para obtener ACCESS_TOKEN ───────────────
                    string url6 = urlToken;
                    var response6 = await client.GetAsync(url6);
                    

                    string accessToken = GetCookieValue(cookieContainer,
                        "felcons.c.sat.gob.gt/dte-agencia-virtual/dte-consulta", "ACCESS_TOKEN");

                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        DateTime expires = GetCookieExpires(cookieContainer,
                            "felcons.c.sat.gob.gt/dte-agencia-virtual/dte-consulta", "ACCESS_TOKEN");

                        wSFacturas.guardarTokenSAT(_user, accessToken, felTokc, expires);
                    }

                    token = accessToken + "|" + felTokc;

                }
            }

            return token;

        }


    }



    public class MenuParam
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class OnClickData
    {
        public string s { get; set; }
        public string u { get; set; }
        public string f { get; set; }
        public List<MenuParam> pa { get; set; }
    }


    public class HtmlOnClickExtractor
    {
        public static OnClickData portada1_ExtractByNitTitular(string html, string nitBuscado)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Buscar todos los <a> que tengan onclick
            var enlaces = doc.DocumentNode.SelectNodes("//a[@onclick]");
            if (enlaces == null) return null;

            foreach (var enlace in enlaces)
            {
                string onclick = enlace.GetAttributeValue("onclick", "");

                // Extraer el JSON del interior de PrimeFaces.ab({...})
                var match = Regex.Match(onclick, @"PrimeFaces\.ab\((\{.*?\})\);", RegexOptions.Singleline);
                if (!match.Success) continue;

                string jsonRaw = match.Groups[1].Value;

                // Limpiar el JSON: convertir &quot; a "
                string jsonLimpio = System.Net.WebUtility.HtmlDecode(jsonRaw);

                // Convertir claves sin comillas a formato JSON válido: s: → "s":
                jsonLimpio = Regex.Replace(jsonLimpio, @"(\b\w+)(\s*):", "\"$1\"$2:");

                // Eliminar backslashes innecesarios en valores
                jsonLimpio = jsonLimpio.Replace(@"\-", "-");

                // Parsear el JSON
                OnClickData data = null;
                try
                {
                    data = JsonConvert.DeserializeObject<OnClickData>(jsonLimpio);
                }
                catch(Exception ex)
                {

                }

                // Filtrar por nitTitular
                var nitParam = data?.pa?.FirstOrDefault(p =>
                    p.name == "nitTitular" && p.value == nitBuscado);

                if (nitParam != null)
                    return data;
            }

            return null;
        }


        public static OnClickData portada1_ExtractByUrl(string html, string urlBuscado)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Buscar todos los <a> que tengan onclick
            var enlaces = doc.DocumentNode.SelectNodes("//a[@onclick]");
            if (enlaces == null) return null;

            foreach (var enlace in enlaces)
            {
                string onclick = enlace.GetAttributeValue("onclick", "");

                // Extraer el JSON del interior de PrimeFaces.ab({...})
                var match = Regex.Match(onclick, @"PrimeFaces\.ab\((\{.*?\})\);", RegexOptions.Singleline);
                if (!match.Success) continue;

                string jsonRaw = match.Groups[1].Value;

                // Limpiar el JSON: convertir &quot; a "
                string jsonLimpio = System.Net.WebUtility.HtmlDecode(jsonRaw);

                // Convertir claves sin comillas a formato JSON válido: s: → "s":
                jsonLimpio = Regex.Replace(jsonLimpio, @"(?<![""\\\/\w])(\w+)\s*:", "\"$1\":");

                // Eliminar backslashes innecesarios en valores
                jsonLimpio = jsonLimpio.Replace(@"\-", "-");

                // Parsear el JSON
                var data = JsonConvert.DeserializeObject<OnClickData>(jsonLimpio);

                // Filtrar por nitTitular
                var nitParam = data?.pa?.FirstOrDefault(p =>
                    p.name == "url" && p.value == urlBuscado);

                if (nitParam != null)
                    return data;
            }

            return null;
        }
    }
}
