using Microsoft.AspNetCore.Mvc;

namespace GpsStation.Controllers
{
    public class AndarilhoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
