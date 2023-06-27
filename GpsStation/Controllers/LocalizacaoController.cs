
using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using Ftec.ProjetosWeb.GPStation.MVC.API;


namespace GpsStation.Controllers
{
    public class LocalizacaoController : Controller
    {

        private APIHttpClient httpClient = new APIHttpClient(@"http://localhost:5135/");
        private string controller = "localizacao";


        public LocalizacaoController(IConfiguration configuration) {}



        public IActionResult Index()
        {
            controller = "dispositivo";
            var dispositivoModel = httpClient.Get<List<DispositivoModel>>(controller);
            return View(dispositivoModel);
        }




        public IActionResult Consultar(DateTime inicio, DateTime fim, String dispositivo)
        {
            controller = "localizacao";
            string stringinicio = inicio.ToString("yyyy-MM-dd HH:mm:ss");
            string stringfim = fim.ToString("yyyy-MM-dd HH:mm:ss");

            string url = $"{controller}/{stringinicio},{stringfim},{dispositivo}";
            var localizacaoModel = httpClient.Get<List<LocalizacaoModel>>(url);
            return Json(localizacaoModel);
        }



     
        public IActionResult Inserir(Guid id, DateTime dateTime, string latitude, string longitude)
        {
            controller = "localizacao";
            LocalizacaoModel localizacao = new LocalizacaoModel()
            {
                IdDispositivo = id,
                DataHora = dateTime, 
                Latitude = latitude,
                Longitude = longitude
            };
            httpClient.Post<LocalizacaoModel>(controller, localizacao);
            return RedirectToAction("Index");
        }
    }
}
