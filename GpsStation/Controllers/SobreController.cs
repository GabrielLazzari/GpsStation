using Microsoft.AspNetCore.Mvc;

namespace GpsStation.Controllers
{
    public class SobreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
