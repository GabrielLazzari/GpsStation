using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;

using GpsStation.Factory;
using GpsStation.Models;
using GpsStation.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace GpsStation.Controllers
{
	public class UsuarioController : Controller
	{

		public IActionResult Index()
		{
			//UsuarioRepository usuarioRepository = new UsuarioRepository();
			//ViewBag.Usuarios = usuarioRepository.ListarUsuario();
			UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
			//ViewBag.Usuarios = usuarioAplicacao.Consultar(2);
			return View();
		}

		public IActionResult Trocar(Guid cod)
		{
			var usuariotrocado = new UsuarioModel();
			usuariotrocado.Nome = "TROCADO";
			usuariotrocado.Id_usuario = cod;
			return Json(usuariotrocado);
		}
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public IActionResult Consultar(string nome)
		{
			UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
			return Json(usuarioAplicacao.Consultar(nome));
		}
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------


		public IActionResult Editar(Guid id)
		{
			//UsuarioRepository usuarioRepository = new UsuarioRepository();
			//ViewBag.Usuario = usuarioRepository.ConsultarUsuario(id);// recupera do banco ou pode ser implementado para recuperar da própra index
			UsuarioModel usuario = new UsuarioModel()
			{
				Administrador = true,
				Nome = "",//string.Empty,
				Senha = "",//string.Empty,
				Id_usuario = Guid.NewGuid()
			};
			ViewBag.Usuario = usuario;

			if (ViewBag.Usuario != null)
				return View();
			else
				return RedirectToAction("Erro");
		}



		public IActionResult Erro()
		{
			return View();
		}




		public IActionResult Inserir()
		{
			return View();
		}




		[HttpPost]
		public IActionResult Gravar(UsuarioModel usuario)
		{

			UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
			// cria um objeto anônimo do tipo Dominio.Usuario para receber o usuario passado por parâmetro e coverter 
			usuarioAplicacao.Inserir(new Ftec.ProjetosWeb.GPStation.Dominio.Entidades.Usuario()
			{
				Administrador = usuario.Administrador,
				Nome = usuario.Nome,
				Senha = usuario.Senha,
				Id_usuario = usuario.Id_usuario
			});
			Console.Write(usuarioAplicacao.Inserir);
			return RedirectToAction("Index");

		}
		//redireciona para action index da controller home
		//return RedirectToAction("Index","Home");














		//public IActionResult Gravar(UsuarioModel usuario)
		//{
		//    List<UsuarioModel> usuarios = UsuarioFactory.GeradorMoqUsuarios(1);
		//    usuarios[0].Id_usuario = usuario.Id_usuario;
		//    usuarios[0].Nome = usuario.Nome;
		//    usuarios[0].Senha = usuario.Senha;
		//    usuarios[0].Administrador = usuario.Administrador;
		//    ViewBag.Usuarios = usuarios;
		//    return RedirectToAction("Editar");
		//}




	}
}
