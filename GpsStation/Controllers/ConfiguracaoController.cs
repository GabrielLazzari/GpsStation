using Microsoft.AspNetCore.Mvc;

namespace GpsStation.Controllers
{
    public class ConfiguracaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
