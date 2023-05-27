using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace GpsStation.Controllers
{
    public class DispositivoController : Controller
    {
        private string strConexao;
        public DispositivoController(IConfiguration configuration)
        {
            strConexao = configuration.GetConnectionString("stringconexao");
        }


        public IActionResult Index()
        {
            HttpContext.Session.SetString("usuario", "Teste de usuário logado");
            DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
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
            DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
            dispositivoAplicacao.Consultar(nome);
            return Json(dispositivoAplicacao.Consultar(nome));

        }



        //public IActionResult Inserir(DispositivoModel dispositivo)
        //{
        //    return View("Inserir");
        //}



        //public IActionResult Editar(Guid Id)
        //{
        //    DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
        //    Dispositivo dispositivo = dispositivoAplicacao.SelecionarPorId(Id);
        //    DispositivoModel dispositivoModel = new DispositivoModel()
        //    {
        //        Id = dispositivo.Id,
        //        Nome = dispositivo.Nome,
        //        Latitude = dispositivo.Latitude,
        //        Longitude = dispositivo.Longitude
        //    };
        //    return View(dispositivoModel);
        //}



        [HttpPost]
        public IActionResult Gravar(DispositivoModel dispositivo)
        {
            if (ModelState.IsValid)
            {
                DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
                dispositivoAplicacao.Inserir(new Dispositivo()
                {
                    Id = dispositivo.Id,
                    Nome = dispositivo.Nome,
                    Latitude = dispositivo.Latitude,
                    Longitude = dispositivo.Longitude
                });
            }
            return RedirectToAction("Index");
        }



        public IActionResult Excluir(Guid Id)
        {
            DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
            dispositivoAplicacao.Excluir(Id);
            return RedirectToAction("Index");
        }
    }
}
