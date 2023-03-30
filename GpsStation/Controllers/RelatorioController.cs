using Microsoft.AspNetCore.Mvc;

namespace GpsStation.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
