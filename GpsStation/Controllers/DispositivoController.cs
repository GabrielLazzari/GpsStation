using GpsStation.Models;
using GpsStation.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GpsStation.Controllers
{
    public class DispositivoController : Controller
    {
        DispositivoModel dispositivo = new();
        public IActionResult Index()
        {
			DispositivoRepository dispositivoRepository = new DispositivoRepository();
			ViewBag.dispositivos = dispositivoRepository.ListarDispositivo();
			return View();
		}

        public IActionResult Excluir()
        {
            return RedirectToAction("Index");
        }

        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
