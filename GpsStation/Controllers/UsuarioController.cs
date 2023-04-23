using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using GpsStation.Factory;
using GpsStation.Models;
using GpsStation.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Usuario = Ftec.ProjetosWeb.GPStation.Dominio.Entidades.Usuario;

namespace GpsStation.Controllers
{
	public class UsuarioController : Controller
	{

		public IActionResult Index()
		{
			List<UsuarioModel> usuarios = new List<UsuarioModel>();
			usuarios = UsuarioFactory.GeradorMoqUsuarios(5);
			ViewBag.Usuarios = usuarios;
			return View();
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

			//LEMBRAR QUE AQUI TEM QUE EXCLUIR TODOS OS DISPOSITIVOS VINCULADOS AO USUARIO

			//UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
			//usuarioAplicacao.Excluir(id);
			return RedirectToAction("Index");
		}


		[HttpPost]
		public IActionResult Gravar(UsuarioModel usuario)
		{
			UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
			usuarioAplicacao.Inserir(new Usuario()
			{
				Administrador = usuario.Administrador,
				Nome = usuario.Nome,
				Senha = usuario.Senha,
				Id = usuario.Id
			});

			return RedirectToAction("Index");

		}

		public IActionResult Inserir(UsuarioModel usuario)
		{
			return RedirectToAction("Index");
		}


		[HttpPost]
		public IActionResult Editar(UsuarioModel usuario)
		{
			UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
			usuarioAplicacao.Editar(new Usuario()
			{
				Administrador = usuario.Administrador,
				Nome = usuario.Nome,
				Senha = usuario.Senha,
				Id = usuario.Id
			});
			return RedirectToAction("Index");
		}

		public IActionResult Erro()
		{
			return View();
		}
	}
}
