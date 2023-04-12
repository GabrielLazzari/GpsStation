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
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            ViewBag.Usuarios = usuarioRepository.ListarUsuario();
            return View();
        }




        public IActionResult Editar(Guid id)
        {
            //UsuarioRepository usuarioRepository = new UsuarioRepository();
            //ViewBag.Usuario = usuarioRepository.ConsultarUsuario(id);// recupera do banco ou pode ser implementado para recuperar da própra index
           UsuarioModel usuario= new UsuarioModel()
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
            UsuarioRepository usuarioRepository = new UsuarioRepository();
            usuarioRepository.InserirUsuario(usuario);
            ViewBag.Usuario = usuario;
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
