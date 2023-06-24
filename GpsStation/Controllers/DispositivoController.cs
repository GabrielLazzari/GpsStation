using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Ftec.ProjetosWeb.GPStation.MVC.API;
using System.Reflection.Metadata;
using System;

namespace GpsStation.Controllers
{
    public class DispositivoController : Controller
    {
        private APIHttpClient httpClient = new APIHttpClient(@"http://localhost:5135/");
        private string controller = "dispositivo";

        public DispositivoController(IConfiguration configuration) { }




        // LISTAR - INDEX
        public IActionResult Index()
        {
            //chama a classe httpclient, método get sem parâmetro e passa a controler dispositivo como parâmetro
            //direciona a chamada para a controller dispositivo do backend que possua um método get sem parâmetro
            var dispositivoModel = httpClient.Get<List<DispositivoModel>>(controller);
            return View(dispositivoModel);
        }

        //public IActionResult Index()
        //{
        //    HttpContext.Session.SetString("usuario", "Teste de usuário logado");
        //    DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
        //    List<DispositivoModel> dispositivoModel = new List<DispositivoModel>();
        //    var dispositivos = dispositivoAplicacao.Listar();
        //    foreach (var dispositivo in dispositivos)
        //    {
        //        dispositivoModel.Add(new DispositivoModel()
        //        {
        //            Id = dispositivo.Id,
        //            Nome = dispositivo.Nome,
        //            Latitude = dispositivo.Latitude,
        //            Longitude = dispositivo.Longitude
        //        });
        //    }
        //    return View(dispositivoModel);
        //}












        // CONSULTAR
        public IActionResult Consultar(String nome)
        {
            nome = "inserir";
            //DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
            //dispositivoAplicacao.Consultar(nome);

            string url = $"{controller}/{nome}";
            var dispositivoModel = httpClient.Get<List<DispositivoModel>>(url);
            return View(dispositivoModel);
        }

        // CONSULTAR
        public IActionResult Consultar(Guid id)
        {
            //DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
            //dispositivoAplicacao.Consultar(nome);

            string url = $"{controller}/{id}";
            var dispositivoModel = httpClient.Get<DispositivoModel>(url);
            return View(dispositivoModel);
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








        //GRAVAR
        public IActionResult Gravar()//DispositivoModel dispositivo
        {
            DispositivoModel dispositivo = new DispositivoModel();
            dispositivo.Id = Guid.Empty;
            dispositivo.Longitude = "888";
            dispositivo.Latitude = "9999";
            dispositivo.Nome = "inserir";

            var objeto = new DispositivoModel()
            {
                Id = dispositivo.Id,
                Latitude = dispositivo.Latitude,
                Longitude = dispositivo.Longitude,
                Nome = dispositivo.Nome
            };
            httpClient.Post<DispositivoModel>(controller, objeto);
            return RedirectToAction("Index");
        }










        //EXCLUIR
        public IActionResult Excluir()//Guid Id
        {
            Guid Id = Guid.Parse("403B71AB-1146-461C-B68D-EABFD008537D");
            string url = $"{controller}/{Id}";
            httpClient.Delete<Object>(url);
            return RedirectToAction("Index");

        }
    }
}
