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

        public IActionResult Excluir(Guid Id)
        {
            return RedirectToAction("Index");
        }

        public IActionResult Inserir(DispositivoModel dispositivo)
        {
			return RedirectToAction("Index");
		}

		public IActionResult Gravar(DispositivoModel dispositivoModel)
		{
			return RedirectToAction("Index");
		}
	}
}
