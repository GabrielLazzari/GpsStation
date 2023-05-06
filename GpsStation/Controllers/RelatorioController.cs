using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using GpsStation.Factory;
using GpsStation.Models;
using GpsStation.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;

namespace GpsStation.Controllers
{
	public class RelatorioController : Controller
	{

		public IActionResult Index()
		{
			/*List<LocalizacaoModel> localizacaoModels = new List<LocalizacaoModel>();
			return View(localizacaoModels);*/

			/*List<DispositivoModel> dispositivoModel = new List<DispositivoModel>();
			DispositivoAplicacao dispositivoAplicacao1 = new DispositivoAplicacao();
			var dispositivos1 = dispositivoAplicacao1.Listar();
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
			return View(dispositivoModel);*/
			//-----------------------------------------------------------------------------
			Inserir();
			//List<RelatorioModel> relatorioModel = new List<RelatorioModel>();
			List<DispositivoModel> dispositivoModel = new List<DispositivoModel>();

			DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
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
			return View(dispositivoModel);









		}
		

	
		public IActionResult Consultar(DateTime inicio, DateTime fim, String dispositivo)
		{
			/*LocalizacaoAplicacao localizacaoAplicacao = new LocalizacaoAplicacao();
			List<LocalizacaoModel> localizacaoModel = new List<LocalizacaoModel>();
			//fim = DateTime.Now;
			//inicio = new DateTime(2022, 4, 30, 15, 00, 00);
			//inicio = DateTime.Parse("2023-04-30 15:00:00");
			//dispositivo = "11111111-1111-1111-1111-111111111111";

			var localizacoes = localizacaoAplicacao.Consultar(inicio, fim, dispositivo);

			foreach (var loc in localizacoes)
			{
				localizacaoModel.Add(new LocalizacaoModel()
				{
					DataHora = loc.DataHora,
					Latitude = loc.Latitude,
					Longitude = loc.Longitude
				});
			}
			return View(localizacaoModel);*/
			//-------------------------------------------------------------------------------
			//RelatorioModel relatorioModel = new RelatorioModel();
			List<LocalizacaoModel> localizacaoModel = new List<LocalizacaoModel>();	
		LocalizacaoAplicacao localizacaoAplicacao = new LocalizacaoAplicacao();
			var localizacao = localizacaoAplicacao.Consultar(inicio,fim,dispositivo);
			foreach (var loc in localizacao)
			{
				localizacaoModel.Add(new LocalizacaoModel()
				{
					IdDispositivo = loc.IdDispositivo,
					DataHora = loc.DataHora,
					Latitude = loc.Latitude,
					Longitude = loc.Longitude
				});
			}
			//return View("Index",relatorioModel);
			return Json(localizacaoModel);

		}



		public void Inserir()
		{
			//LocalizacaoFactory criar = new LocalizacaoFactory();
			//List<LocalizacaoModel> localizacoes = new List<LocalizacaoModel>();
		//	localizacoes=criar.GeradorMoqLocalizacoes(5);
		//	localizacaoModel = localizacoes[0];
			LocalizacaoAplicacao localizacaoAplicacao = new LocalizacaoAplicacao();

			localizacaoAplicacao.Inserir(new Localizacao()
			{
				IdDispositivo = Guid.Parse("DAD64957-59CF-434C-A907-F7127EB7A36A".ToString()),// localizacaoModel.IdDispositivo,
				DataHora = DateTime.Parse("05 / 03 / 2023 22:51:00"),// localizacaoModel.DataHora,
				Latitude ="2", //localizacaoModel.Latitude,
				Longitude ="3",// localizacaoModel.Longitude
			}) ;
		
		}
	}
}
