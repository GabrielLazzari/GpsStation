using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using Ftec.ProjetosWeb.GPStation.MVC.API;


namespace GpsStation.Controllers
{
    public class DispositivoController : Controller
    {
        private APIHttpClient httpClient = new APIHttpClient(@"http://localhost:5135/");
        private string controller = "dispositivo";

        public DispositivoController(IConfiguration configuration) { }

        public IActionResult Index()
        {
            //chama a classe httpclient, método get sem parâmetro e passa a controler dispositivo como parâmetro
            //direciona a chamada para a controller dispositivo do backend que possua um método get sem parâmetro
            var dispositivoModel = httpClient.Get<List<DispositivoModel>>(controller);
            return View(dispositivoModel);
        }


        public IActionResult Consultar(String nome)
        {
            string url = $"{controller}/{nome}";
            var dispositivoModel = httpClient.Get<List<DispositivoModel>>(url);
            return View(dispositivoModel);
        }



        public IActionResult Consultar(Guid id)
        {
            string url = $"{controller}/{id}";
            var dispositivoModel = httpClient.Get<DispositivoModel>(url);
            return View(dispositivoModel);
        }



        public IActionResult Gravar(DispositivoModel dispositivo)
        {
            httpClient.Post<DispositivoModel>(controller, dispositivo);
            return RedirectToAction("Index");
        }



        public IActionResult Excluir(Guid id)
        {
            string url = $"{controller}/{id}";
            httpClient.Delete<Object>(url);
            return RedirectToAction("Index");
        }
    }
}
