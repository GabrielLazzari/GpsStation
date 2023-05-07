using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace GpsStation.Controllers
{
    public class MapaController : Controller
    {

        private string strConexao;
        public MapaController(IConfiguration configuration)
        {
            strConexao = configuration.GetConnectionString("stringconexao");
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString("usuario", "Teste de usuário logado");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}