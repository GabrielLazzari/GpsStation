using Microsoft.AspNetCore.Mvc;

namespace GpsStation.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            /*if (!UsuarioController.admin)
            {
                RedirectToAction("Cadastro");
            }*/
            return View();
        }
    }
}
