
using Microsoft.AspNetCore.Mvc;
using Ftec.ProjetosWeb.GPStation.MVC.API;
using GpsStation.Models;

namespace GpsStation.Controllers
{
    public class LoginController : Controller
    {

        private string strConexao;
        private APIHttpClient httpClient = new APIHttpClient(@"http://localhost:5135/");
        private string controller = "login";


        public LoginController(IConfiguration configuration)
        {
            strConexao = configuration.GetConnectionString("stringconexao");
        }


        public IActionResult Index()
        {
            return View();
        }


		public IActionResult ConfirmarLogin(string usuario, string senha)
		{
            UsuarioModel usuarioModel = new UsuarioModel()
            {
                Nome = usuario,
                Senha = senha,
                Id = Guid.Empty
            };
			httpClient.Post<UsuarioModel>(controller, usuarioModel);
			return RedirectToAction("Index");
		}

    }
}
