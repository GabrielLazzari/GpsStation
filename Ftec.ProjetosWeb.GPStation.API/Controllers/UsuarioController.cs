using Ftec.ProjetosWeb.GPStation.API.Models;
using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Aplicacao.DTO;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia;
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
                IUsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
                UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioPersistencia);
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
                IUsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
                UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioPersistencia);
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




        [HttpGet("{usuario},{senha}")]
        public IActionResult Get(string usuario, string senha)
        {
            try
            {
                IUsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
                UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioPersistencia);
                Guid token = usuarioAplicacao.Login(usuario,senha);
                return Ok(token);

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
                IUsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
                UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioPersistencia);

                UsuarioDTO usuarioDTO = new UsuarioDTO()
                {
                    Nome = usuarioModel.Nome,
                    Senha = usuarioModel.Senha,
                    Id = usuarioModel.Id
                };
                if (usuarioAplicacao.Inserir(usuarioDTO))
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
                IUsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
                UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioPersistencia);
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
        public IActionResult Editar(string nome, string senha, Guid id)
        {
            try
            {
                IUsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
                UsuarioAplicacao usuarioAplicacao = new UsuarioAplicacao(usuarioPersistencia);

                UsuarioDTO usuarioDTO = new UsuarioDTO();
                usuarioDTO.Nome = nome;
                usuarioDTO.Senha = senha;
                usuarioDTO.Id = id;

                if (usuarioAplicacao.Editar(usuarioDTO))
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

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