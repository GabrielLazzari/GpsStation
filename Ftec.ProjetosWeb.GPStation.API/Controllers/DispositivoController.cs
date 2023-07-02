using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Microsoft.AspNetCore.Mvc;
using Ftec.ProjetosWeb.GPStation.API.Models;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia;
using Ftec.ProjetosWeb.GPStation.Aplicacao.DTO;
using NLog;

namespace Ftec.ProjetosWeb.GPStation.API.Controllers
{

	[Route("[controller]")]
	[ApiController]
	public class DispositivoController : ControllerBase
	{
		Logger _logger = LogManager.GetLogger(new
		DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName.Replace("\\bin\\Debug", ""));



		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				IDispositivoPersistencia dispositivoPersistencia = new DispositivoPersistencia();
				DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao(dispositivoPersistencia);
				List<DispositivoModel> dispositivoModel = new List<DispositivoModel>();

				var dispositivos = dispositivoAplicacao.Listar();
				foreach (var dispositivo in dispositivos)
				{
					dispositivoModel.Add(new DispositivoModel()
					{
						Id = dispositivo.Id,
						Nome = dispositivo.Nome,
						Latitude = dispositivo.Latitude,
						Longitude = dispositivo.Longitude
					});
				}
				
				return Ok(dispositivoModel);
			}
			catch (Exception ex)
			{
				_logger.Info(ex.Message);
				return BadRequest(ex.Message);
			}
;
		}









		[HttpGet("{nome}")]
		public IActionResult Get(String nome)
		{
			try
			{
				IDispositivoPersistencia dispositivoPersistencia = new DispositivoPersistencia();
				DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao(dispositivoPersistencia);
				List<DispositivoModel> dispositivoModel = new List<DispositivoModel>();

				var dispositivos = dispositivoAplicacao.Consultar(nome);
				foreach (var dispositivo in dispositivos)
				{
					dispositivoModel.Add(new DispositivoModel()
					{
						Id = dispositivo.Id,
						Nome = dispositivo.Nome,
						Latitude = dispositivo.Latitude,
						Longitude = dispositivo.Longitude
					});
				}
				return Ok(dispositivoModel);
			}
			catch (Exception ex)
			{
				_logger.Info(ex.Message);
				return BadRequest(ex.Message);
			}
		}







		[HttpPost]
		public IActionResult Post([FromBody] DispositivoModel dispositivoModel)
		{
			try
			{
				IDispositivoPersistencia dispositivoPersistencia = new DispositivoPersistencia();
				DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao(dispositivoPersistencia);
				DispositivoDTO dispositivo = new DispositivoDTO()
				{
					Id = dispositivoModel.Id,
					Longitude = dispositivoModel.Longitude,
					Latitude = dispositivoModel.Latitude,
					Nome = dispositivoModel.Nome,
				};

				if (dispositivoAplicacao.Inserir(dispositivo))
					return Ok();
				else
				{
					_logger.Info("Erro ao inserir o dispositivo");
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
				IDispositivoPersistencia dispositivoPersistencia = new DispositivoPersistencia();
				DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao(dispositivoPersistencia);
				if (dispositivoAplicacao.Excluir(Id))
					return Ok();
				else
				{
					_logger.Info("Erro ao excluir o dispositivo");
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

