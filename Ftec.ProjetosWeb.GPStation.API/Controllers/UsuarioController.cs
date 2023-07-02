using Ftec.ProjetosWeb.GPStation.API.Models;
using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Aplicacao.DTO;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia;
using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NLog;

namespace Ftec.ProjetosWeb.GPStation.API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class UsuarioController : ControllerBase
	{
		public UsuarioController() { }

		Logger _logger = LogManager.GetLogger(new
			DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName.Replace("\\bin\\Debug", ""));

		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				IUsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
				UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioPersistencia);
				List<UsuarioModel> usuariosModel = new List<UsuarioModel>();
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
				return Ok(usuariosModel);
			}
			catch (Exception ex)
			{
				_logger.Info(ex.Message);
				return BadRequest(ex.Message);
			}

		}






		[HttpGet("{nome}")]
		public IActionResult Get(String nome)
		{
			try
			{
				IUsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
				UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioPersistencia);
				List<UsuarioModel> usuariosModel = new List<UsuarioModel>();
				var usuarios = usuarioAplicacao.Consultar(nome);

				foreach (var usuario in usuarios)
				{
					usuariosModel.Add(new UsuarioModel()
					{
						Id = usuario.Id,
						Nome = usuario.Nome,
						Senha = usuario.Senha
					});
				}
				return Ok(usuariosModel);

			}
			catch (Exception ex)
			{
				_logger.Info(ex.Message);
				return BadRequest(ex.Message);
			}

		}



		[HttpPost]
		public IActionResult Post([FromBody] UsuarioModel usuarioModel)
		{
			try
			{
				IUsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
				UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioPersistencia);

				UsuarioDTO usuarioDTO = new UsuarioDTO()
				{
					Nome = usuarioModel.Nome,
					Senha = usuarioModel.Senha,
					Id = usuarioModel.Id
				};
				if (usuarioAplicacao.Inserir(usuarioDTO))
					return Ok();
				else
				{
					_logger.Info("Nao foi possivel inserir o usuario");
					return BadRequest();
				}
			}
			catch (Exception ex)
			{
				_logger.Info(ex.Message);
				return BadRequest(ex.Message);
			}


		}










		[HttpDelete("{Id}")]
		public IActionResult Delete(Guid Id)
		{

			try
			{
				IUsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
				UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioPersistencia);
				if (usuarioAplicacao.Excluir(Id))
					return Ok();
				else
				{
					_logger.Info("Nao foi possivel excluir o usuario");
					return BadRequest();
				}
			}
			catch (Exception ex)
			{
				_logger.Info(ex.Message);
				return BadRequest(ex.Message);
			}
		}








		[HttpPut]
		[Route("usuario/editar")]
		public IActionResult Editar(string nome, string senha, Guid id)
		{
			try
			{
				IUsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
				UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioPersistencia);

				UsuarioDTO usuarioDTO = new UsuarioDTO();
				usuarioDTO.Nome = nome;
				usuarioDTO.Senha = senha;
				usuarioDTO.Id = id;

				if (usuarioAplicacao.Editar(usuarioDTO))
					return Ok();
				else
				{
					_logger.Info("Nao foi possivel alterar o usuario");
					return BadRequest();
				}
			}
			catch (Exception ex)
			{
				_logger.Info(ex.Message);
				return BadRequest(ex.Message);
			}

		}

	}
}

