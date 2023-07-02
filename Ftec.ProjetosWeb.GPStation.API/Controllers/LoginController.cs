using Ftec.ProjetosWeb.GPStation.API.Models;
using Ftec.ProjetosWeb.GPStation.API.Services;
using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Aplicacao.DTO;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia;
using Microsoft.AspNetCore.Mvc;

namespace Ftec.ProjetosWeb.GPStation.API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		IUsuarioPersistencia minhainterface;
		UsuarioAplicacao aplicacao;

		public LoginController()
		{
			minhainterface = new UsuarioPersistencia();
			aplicacao = new UsuarioAplicacao(minhainterface);
		}



		[HttpPost]
		public IActionResult Post([FromBody] UsuarioModel usuario)
		{
			try
			{
				var usuarioDTO = new UsuarioDTO();
				usuarioDTO = aplicacao.Login(usuario.Nome, usuario.Senha);

				var token = TokenServices.GenerateToken(usuario);

				usuario.Token = token;

				usuario.Senha = string.Empty;

				return Ok(token);

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}

