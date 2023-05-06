using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using GpsStation.Factory;
using GpsStation.Models;
using GpsStation.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GpsStation.Controllers
{
	public class DispositivoController : Controller
	{
		private DispositivoAplicacao dispositivoAplicacao;
		public DispositivoController()
		{
			dispositivoAplicacao = new DispositivoAplicacao();
		}


		public IActionResult Index()
		{
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
			return View(dispositivoModel);
		}




		public IActionResult Consultar(String nome)
		{
			dispositivoAplicacao.Consultar(nome);
			return Json(dispositivoAplicacao.Consultar(nome));
			
		}



		public IActionResult Inserir(DispositivoModel dispositivo)
		{
			return View("Inserir");
		}



		public IActionResult Editar(Guid Id)
		{
			DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
			Dispositivo dispositivo = dispositivoAplicacao.SelecionarPorId(Id);
			DispositivoModel dispositivoModel = new DispositivoModel()
			{
				Id = dispositivo.Id,
				Nome = dispositivo.Nome,
				Latitude = dispositivo.Latitude,
				Longitude = dispositivo.Longitude
			};
			return View(dispositivoModel);
		}



		[HttpPost]
		public IActionResult Gravar(DispositivoModel dispositivo)
		{
			DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
			dispositivoAplicacao.Inserir(new Dispositivo()
			{
				Id = dispositivo.Id,
				Nome = dispositivo.Nome,
				Latitude = dispositivo.Latitude,
				Longitude = dispositivo.Longitude
			});
			return RedirectToAction("Index");
		}



		public IActionResult Excluir(Guid Id)
		{
			dispositivoAplicacao.Excluir(Id);
			return RedirectToAction("Index");
		}
	}
}
