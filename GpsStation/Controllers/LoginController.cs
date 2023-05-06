using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using GpsStation.Factory;
using GpsStation.Models;
using GpsStation.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Usuario = Ftec.ProjetosWeb.GPStation.Dominio.Entidades;

namespace GpsStation.Controllers
{
    public class LoginController : Controller
    {
        LoginModel login = new ();

        public IActionResult Index()
        {
                return View();
        }

        //tipo de retorno do form da view do login
        [HttpPost]
        //método que recebe info do form login
        public void Confirmarlogin()
        {
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
            Boolean autorizado = usuarioAplicacao.Login(Request.Form["usuario"], Request.Form["senha"]);
          //  if (login.Nome == Request.Form["usuario"] && login.Senha == Request.Form["senha"])
          if(autorizado)
            {
                //se correto redireciona para controller Mapa action index
                Response.Redirect("/Mapa/Index");
            }
            else 
                //se errado redireciona para controller Login action index
                Response.Redirect("/Login/Index");

        }
    }
}
