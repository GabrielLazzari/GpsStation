
using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using Ftec.ProjetosWeb.GPStation.MVC.API;


namespace GpsStation.Controllers
{
    public class UsuarioController : Controller
    {
        private APIHttpClient httpClient = new APIHttpClient(@"http://localhost:5135/");
        private string controller = "usuario";


        public UsuarioController(IConfiguration configuration) { }



        public IActionResult Index()
        {
            HttpContext.Session.SetString("usuario", "Teste de usuário logado");
            var usuarioModel = httpClient.Get<List<UsuarioModel>>(controller);
            return View(usuarioModel);
        }



        public IActionResult Consultar(string nome)
        {
            string url = $"{controller}/{nome}";
            var usuarioModel = httpClient.Get<List<UsuarioModel>>(url);
            return View(usuarioModel);
        }




        public IActionResult Gravar(UsuarioModel usuario)
        {
            httpClient.Post<UsuarioModel>(controller, usuario);
            return RedirectToAction("Index");
        }




        public IActionResult Put(Guid id)
        {
            string url = $"{controller}/{id}";
            httpClient.Delete<Object>(url);
            return RedirectToAction("Index");
        }
    }
}
