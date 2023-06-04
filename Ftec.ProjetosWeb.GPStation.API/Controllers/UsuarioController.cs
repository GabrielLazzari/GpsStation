using Ftec.ProjetosWeb.GPStation.API.Models;
using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ftec.ProjetosWeb.GPStation.API.Controllers
{
    //cria a rota com o nome da controler que for passada como parâmetro na chamada do apihttpclient do MVC
    [Route("[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public UsuarioController() { }









        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
                List<UsuarioModel> usuariosModel = new List<UsuarioModel>();
                var usuarios = usuarioAplicacao.Listar();
                foreach (var usuario in usuarios)
                {
                    usuariosModel.Add(new UsuarioModel()
                    {
                        Id = usuario.Id,
                        Nome = usuario.Nome,
                        Senha = usuario.Senha
                    });
                }
                return Ok(usuariosModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }









        [HttpGet("{nome}")]
        public IActionResult Get(String nome)
        {
            try
            {
                UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
                List<UsuarioModel> usuariosModel = new List<UsuarioModel>();
                var usuarios = usuarioAplicacao.Consultar(nome);
                foreach (var usuario in usuarios)
                {
                    usuariosModel.Add(new UsuarioModel()
                    {
                        Id = usuario.Id,
                        Nome = usuario.Nome,
                        Senha = usuario.Senha
                    });
                }
                return Ok(usuariosModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }







        [HttpPost]
        public IActionResult Post([FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();

                Usuario usuario = new Usuario()
                {
                    Nome = usuarioModel.Nome,
                    Senha = usuarioModel.Senha,
                    Id = usuarioModel.Id
                };
                if (usuarioAplicacao.Inserir(usuario))
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }










        [HttpDelete("{Id}")]
        public IActionResult Delete(Guid Id)
        {
            
            try
            {
                UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao();
                if (usuarioAplicacao.Excluir(Id))
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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