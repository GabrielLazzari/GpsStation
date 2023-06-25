using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Http;
using Ftec.ProjetosWeb.GPStation.MVC.API;

namespace GpsStation.Controllers
{
    public class MapaController : Controller
    {
        private APIHttpClient httpClient = new APIHttpClient(@"http://localhost:5135/");
        private string strConexao;
        public MapaController(IConfiguration configuration)
        {
            strConexao = configuration.GetConnectionString("stringconexao");
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString("usuario", "Teste de usuário logado");

            @ViewBag.Latitude = string.Empty;
            @ViewBag.Longitude = string.Empty;
            @ViewBag.Tipo = string.Empty;

            var id = HttpContext.Session.GetString("id");
            if (id != null)
            {
                Guid Id = new Guid(id);

                string latitude = string.Empty;
                string longitude = string.Empty;

                var tipoSalvo = HttpContext.Session.GetString("tipo");
                var tipo = "ponto";
                if (tipoSalvo != null)
                {
                    if (!string.IsNullOrEmpty(tipoSalvo))
                    {
                        tipo = tipoSalvo;
                    }
                }

                if (tipo == "ponto")
                {
                    string url = $"Dispositivo/{id}";
                    var dispositivoModel = httpClient.Get<DispositivoModel>(url);

                    latitude = dispositivoModel.Latitude;
                    longitude = dispositivoModel.Longitude;
                }
                else if(tipo == "linha")
                {
                    var dataInicio = HttpContext.Session.GetString("dataInicio");
                    var dataFim = HttpContext.Session.GetString("dataFim");

                    string url = $"Localizacao/{dataInicio},{dataFim},{id}";
                    var localizacaoModel = httpClient.Get<List<LocalizacaoModel>>(url);

                    foreach (var item in localizacaoModel)
                    {
                        latitude += latitude + ",";
                        longitude += longitude + ",";
                    }
                }

                if (!string.IsNullOrEmpty(latitude))
                {
                    if (latitude.Substring(longitude.Length - 1, 1) == ",")
                    {
                        latitude = latitude.Remove(latitude.Length - 1, 1);
                    }
                }
                if (!string.IsNullOrEmpty(longitude))
                {
                    if (longitude.Substring(longitude.Length - 1, 1) == ",")
                    {
                        longitude = longitude.Remove(longitude.Length - 1, 1);
                    }
                }

                @ViewBag.Latitude = latitude;
                @ViewBag.Longitude = longitude;
                @ViewBag.Tipo = tipo;
            }

            return View();
        }

        public IActionResult VisualizarLocalizacao(Guid Id)
        {
            HttpContext.Session.SetString("id", Id.ToString());
            HttpContext.Session.SetString("tipo", "ponto");
            return RedirectToAction("Index");
        }

        public IActionResult VisualizarLocalizacaoRelatorio(Guid Id, string dataInicio, string dataFim)
        {
            if (string.IsNullOrEmpty(dataInicio))
            {
                dataInicio = string.Empty;
            }
            if (string.IsNullOrEmpty(dataFim))
            {
                dataFim = string.Empty;
            }

            HttpContext.Session.SetString("id", Id.ToString());
            HttpContext.Session.SetString("tipo", "linha");
            HttpContext.Session.SetString("dataInicio", dataInicio);
            HttpContext.Session.SetString("dataFim", dataFim);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}