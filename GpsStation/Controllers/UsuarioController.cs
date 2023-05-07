using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Microsoft.AspNetCore.Http;

namespace GpsStation.Controllers
{
    public class UsuarioController : Controller
    {
        private string strConexao;
        public UsuarioController(IConfiguration configuration)
        {
            strConexao = configuration.GetConnectionString("stringconexao");
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString("usuario", "Teste de usuário logado");
            List<UsuarioModel> usuariosModel = new List<UsuarioModel>();
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
            var usuarios = usuarioAplicacao.Listar();

            foreach (var usuario in usuarios)
            {
                usuariosModel.Add(new UsuarioModel()
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Senha = usuario.Senha
                });
            }
            return View(usuariosModel);
        }



        public IActionResult Consultar(string nome)
        {
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
            return Json(usuarioAplicacao.Consultar(nome));
        }



        public IActionResult Listar()
        {
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
            return Json(usuarioAplicacao.Listar());
        }




        public IActionResult Excluir(Guid id)
        {
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
            usuarioAplicacao.Excluir(id);
            return RedirectToAction("Index");
        }




        [HttpPost]
        public IActionResult Gravar(UsuarioModel usuario)
        {
            if (ModelState.IsValid)
            {
                UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
                usuarioAplicacao.Inserir(new Usuario()
                {
                    Nome = usuario.Nome,
                    Senha = usuario.Senha,
                    Id = usuario.Id,
                });
            }
            return RedirectToAction("Index");
        }



        public IActionResult Inserir(UsuarioModel usuario)
        {
            return View("Inserir");
        }




        public IActionResult Editar(Guid Id)
        {
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
            Usuario usuario = usuarioAplicacao.SelecionarPorId(Id);
            UsuarioModel usuarioModel = new UsuarioModel()
            {
                Nome = usuario.Nome,
                Senha = usuario.Senha,
                Id = Id
            };
            return View(usuarioModel);
        }
    }
}
