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

		[HttpPost]
		public IActionResult Inserir(DispositivoModel dispositivo)
        {
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Gravar(DispositivoModel dispositivoModel)
		{
			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Pesquisar(string descricao)
		{
			DispositivoRepository dispositivoRepository = new DispositivoRepository();
			List<DispositivoModel> dispositivos = dispositivoRepository.ListarDispositivo();
			if (!string.IsNullOrEmpty(descricao))
			{
				dispositivos = dispositivos.Where(d => d.Nome.ToLower().Contains(descricao.ToLower())).ToList();
			}

			return Json(dispositivos);
		}
	}
}
