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
    public class UsuarioController : Controller
    {
        private APIHttpClient httpClient = new APIHttpClient(@"http://localhost:5135/");
        private string controller = "usuario";


        public UsuarioController(IConfiguration configuration) { }



        public IActionResult Index()
        {
            HttpContext.Session.SetString("usuario", "Teste de usuário logado");

            //chama a classe httpget, método get sem parâmetro e passa a controler dispositivo como parâmetro
            //direciona a chamada para a controller dispositivo do backend que possua um método get sem parâmetro
            var usuarioModel = httpClient.Get<List<UsuarioModel>>(controller);
            return View(usuarioModel);
        }



        public IActionResult Consultar(string nome)
        {
            //nome = "bruno";
            //DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
            //dispositivoAplicacao.Consultar(nome);

            string url = $"{controller}/{nome}";
            var usuarioModel = httpClient.Get<List<UsuarioModel>>(url);
            return View(usuarioModel);
        }



        //public IActionResult Listar()
        //{
        //    UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
        //    return Json(usuarioAplicacao.Listar());
        //}







        public IActionResult Gravar(UsuarioModel usuario)
        {

            //UsuarioModel usuarioModel = new UsuarioModel();
            //usuarioModel.Id = //Guid.Empty;
            //usuarioModel.Senha = //"888";
            //usuarioModel.Nome = //"bruno";

            //var objeto = new UsuarioModel()
            //{
            //    Id = usuario.Id,
            //    Nome = usuario.Nome,
            //    Senha = usuario.Senha
            //};

            httpClient.Post<UsuarioModel>(controller, usuario);
            return RedirectToAction("Index");
        }



        //public IActionResult Inserir(UsuarioModel usuario)
        //{
        //    return View("Inserir");
        //}







        public IActionResult Put(Guid id)//Guid id
        {
            //Guid.Parse("D526AC0B-AE5C-4B68-9F24-DC93D3EBFA3A");
            string url = $"{controller}/{id}";
            httpClient.Delete<Object>(url);
            return RedirectToAction("Index");
        }







        //public IActionResult Editar(Guid Id)
        //{
        //    UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
        //    Usuario usuario = usuarioAplicacao.SelecionarPorId(Id);
        //    UsuarioModel usuarioModel = new UsuarioModel()
        //    {
        //        Nome = usuario.Nome,
        //        Senha = usuario.Senha,
        //        Id = Id
        //    };
        //    return View(usuarioModel);
        //}
    }
}
