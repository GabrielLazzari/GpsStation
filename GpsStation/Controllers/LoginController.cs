
using Microsoft.AspNetCore.Mvc;
using Ftec.ProjetosWeb.GPStation.MVC.API;

namespace GpsStation.Controllers
{
    public class LoginController : Controller
    {

        private string strConexao;
        private APIHttpClient httpClient = new APIHttpClient(@"http://localhost:5135/");
        private string controller = "usuario";


        public LoginController(IConfiguration configuration)
        {
            strConexao = configuration.GetConnectionString("stringconexao");
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Confirmarlogin(String usuario, String senha)
        {
            string url = $"{controller}/{usuario},{senha}";
            Guid token = httpClient.Get<Guid>(url);

            if (token == Guid.Empty)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return RedirectToAction("Index", "Mapa");
            }

        }
    }
}
