using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ftec.ProjetosWeb.GPStation.API.Controllers
{
    public class UsuarioController : ControllerBase
    {
        public UsuarioController() { }









        [HttpGet]
        [Route("usuario/listar")]
        public String Listar()
        {
            List<Usuario> usuarios = new List<Usuario>();
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
            usuarios = usuarioAplicacao.Listar();
            return JsonConvert.SerializeObject(usuarios);
        }









        [HttpGet]
        [Route("usuario/consultar")]
        public String Consultar(string nome)
        {
            List<Usuario> usuarios = new List<Usuario>();
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
            usuarios = usuarioAplicacao.Consultar(nome);
            return JsonConvert.SerializeObject(usuarios);
        }







        [HttpPost]
        [Route("usuario/inserir")]
        public Boolean Inserir(string nome, string senha, Guid id)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = nome;
            usuario.Senha = senha;
            usuario.Id = id;
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
            return usuarioAplicacao.Inserir(usuario);
        }










        [HttpDelete]
        [Route("usuario/excluir")]
        public Boolean Excluir(Guid Id)
        {
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
            return usuarioAplicacao.Excluir(Id);
        }








        [HttpPut]
        [Route("usuario/editar")]
        public Boolean Editar(string nome, string senha, Guid id)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = nome;
            usuario.Senha = senha;
            usuario.Id = id;
            UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
            return usuarioAplicacao.Editar(usuario);
        }



    }
}

//usuarios.Add(new Usuario()
//{
//    Nome = "Bruno",
//    Senha = "1234",
//    Id = new Guid()
//});
//usuarios.Add(new Usuario()
//{
//    Nome = "Maria",
//    Senha = "567",
//    Id = new Guid()
//});