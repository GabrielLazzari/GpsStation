using GpsStation.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GpsStation.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Index()
        {
			LocalizacaoRepository localizacaoRepository = new LocalizacaoRepository();
            ViewBag.localizacoes = localizacaoRepository.ListarLocalizacao();
			return View();
        }
    }
}
