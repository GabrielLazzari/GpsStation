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
    public class LocalizacaoController : Controller
    {

        private APIHttpClient httpClient = new APIHttpClient(@"http://localhost:5135/");
        private string controller = "localizacao";


        public LocalizacaoController(IConfiguration configuration) {}



        public IActionResult Index()
        {
            controller = "dispositivo";
            var dispositivoModel = httpClient.Get<List<DispositivoModel>>(controller);
            return View(dispositivoModel);
        }






        public IActionResult Consultar(DateTime inicio, DateTime fim, String dispositivo)
        {
            controller = "localizacao";
            string stringinicio = inicio.ToString("yyyy-MM-dd HH:mm:ss");
            string stringfim = fim.ToString("yyyy-MM-dd HH:mm:ss");

            string url = $"{controller}/{stringinicio},{stringfim},{dispositivo}";
            var localizacaoModel = httpClient.Get<List<LocalizacaoModel>>(url);
            return Json(localizacaoModel);
        }






        /******* O MÉTODO INSERIR FOI UTILIZADO APENAS PARA TESTE, SERÁ SUBSTITUÍDO PELA API************/
        public IActionResult Inserir()
        {
            controller = "localizacao";
           LocalizacaoModel localizacao = new LocalizacaoModel()
            {
                IdDispositivo = Guid.Parse("DAD64957-59CF-434C-A907-F7127EB7A36A".ToString()),
                DataHora = DateTime.Parse("05 / 03 / 2023 22:51:00"),
                Latitude = "2",
                Longitude = "3",
            };

            httpClient.Post<LocalizacaoModel>(controller, localizacao);
            return RedirectToAction("Index");
        }




            //public IActionResult Consultar(DateTime inicio, DateTime fim, String dispositivo)
            //{

            //    List<LocalizacaoModel> localizacaoModel = new List<LocalizacaoModel>();
            //    LocalizacaoAplicacao localizacaoAplicacao = new LocalizacaoAplicacao();
            //    var localizacao = localizacaoAplicacao.Consultar(inicio, fim, dispositivo);
            //    foreach (var loc in localizacao)
            //    {
            //        localizacaoModel.Add(new LocalizacaoModel()
            //        {
            //            IdDispositivo = loc.IdDispositivo,
            //            DataHora = loc.DataHora,
            //            Latitude = loc.Latitude,
            //            Longitude = loc.Longitude
            //        });
            //    }
            //    return Json(localizacaoModel);

            //}





            /******* O MÉTODO INSERIR FOI UTILIZADO APENAS PARA TESTE, SERÁ SUBSTITUÍDO PELA API************/
        //    public void Inserir_()
        //{
        //    LocalizacaoAplicacao localizacaoAplicacao = new LocalizacaoAplicacao();
        //    localizacaoAplicacao.Inserir(new Localizacao()
        //    {
        //        IdDispositivo = Guid.Parse("DAD64957-59CF-434C-A907-F7127EB7A36A".ToString()),
        //        DataHora = DateTime.Parse("05 / 03 / 2023 22:51:00"),
        //        Latitude = "2",
        //        Longitude = "3",
        //    });
        //}
    }
}
