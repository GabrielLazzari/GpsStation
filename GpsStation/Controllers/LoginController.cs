using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Usuario = Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia;
using System.Net.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Ftec.ProjetosWeb.GPStation.MVC.API;

namespace GpsStation.Controllers
{
    public class LoginController : Controller
    {

        private string strConexao;
        private APIHttpClient httpClient = new APIHttpClient(@"http://localhost:5135/");
        private string controller = "usuario";
        public LoginController(IConfiguration configuration)
        {
            strConexao = configuration.GetConnectionString("stringconexao");
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Confirmarlogin(String usuario, String senha)
        {
            string url = $"{controller}/{usuario},{senha}";
            Guid token = httpClient.Get<Guid>(url);


            //Boolean autorizado = usuarioAplicacao.Login(usuario, senha);
            //  if (login.Nome == Request.Form["usuario"] && login.Senha == Request.Form["senha"])
            if (token == Guid.Empty)
            {
                //se errado retorna para index
                return RedirectToAction("Index", "Login");
            }
            else
            {
                //se correto redireciona para controller Mapa action index
                return RedirectToAction("Index", "Mapa");
            }

        }
    }
}
