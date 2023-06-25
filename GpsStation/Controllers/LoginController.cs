using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Usuario = Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia;

namespace GpsStation.Controllers
{
    public class LoginController : Controller
    {

        private string strConexao;
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
            IUsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioPersistencia);
            Boolean autorizado = usuarioAplicacao.Login(usuario, senha);
            //  if (login.Nome == Request.Form["usuario"] && login.Senha == Request.Form["senha"])
            if (autorizado)
            {
                //se correto redireciona para controller Mapa action index
                return RedirectToAction("Index", "Mapa");
            }
            else
            {
                //se errado retorna mensagem de login incorreto
                return RedirectToAction("Index", "Login");
                //return Json(autorizado);
            }

        }
    }
}
