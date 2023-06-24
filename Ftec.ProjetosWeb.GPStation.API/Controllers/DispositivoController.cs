using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Ftec.ProjetosWeb.GPStation.API.Models;
using NLog.Web;
using Microsoft.AspNetCore;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia;
using Ftec.ProjetosWeb.GPStation.Aplicacao.DTO;

namespace Ftec.ProjetosWeb.GPStation.API.Controllers
{
    //cria a rota com o nome da controler que for passada como parâmetro na chamada do apihttpclient do MVC
    [Route("[controller]")]
    [ApiController]
    public class DispositivoController : ControllerBase
    {
        //public DispositivoController() { }

        private readonly ILogger<DispositivoController> _logger;

        public DispositivoController(ILogger<DispositivoController> logger)
        {
            _logger = logger;
        }



        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IDispositivoPersistencia dispositivoPersistencia = new DispositivoPersistencia();
                DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao(dispositivoPersistencia);
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
                _logger.LogInformation("HomeController.Index method called!!!");
                return Ok(dispositivoModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
;
        }









        [HttpGet("{nome}")]
        public IActionResult Get(String nome)
        {
            try
            {
                IDispositivoPersistencia dispositivoPersistencia = new DispositivoPersistencia();
                DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao(dispositivoPersistencia);
                List<DispositivoModel> dispositivoModel = new List<DispositivoModel>();

                var dispositivos = dispositivoAplicacao.Consultar(nome);
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
                return Ok(dispositivoModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }







        //[HttpPost]
        //[Route("dispositivo/inserir")]
        //public Boolean Inserir(Guid id, string nome, string latitude, string longitude)
        //{
        //    Dispositivo dispositivo = new Dispositivo();
        //    dispositivo.Id = id;
        //    dispositivo.Longitude = longitude;
        //    dispositivo.Latitude = latitude;
        //    dispositivo.Nome = nome;
        //    DispositivoAplicacao dispositivoAplicação = new DispositivoAplicacao();
        //    return dispositivoAplicação.Inserir(dispositivo);
        //}

        [HttpPost]
        public IActionResult Post([FromBody] DispositivoModel dispositivoModel)
        {
            try
            {
                IDispositivoPersistencia dispositivoPersistencia = new DispositivoPersistencia();
                DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao(dispositivoPersistencia);
                DispositivoDTO dispositivo = new DispositivoDTO()
                {
                    Id = dispositivoModel.Id,
                    Longitude = dispositivoModel.Longitude,
                    Latitude = dispositivoModel.Latitude,
                    Nome = dispositivoModel.Nome,
                };
                if (dispositivoAplicacao.Inserir(dispositivo))
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
                IDispositivoPersistencia dispositivoPersistencia = new DispositivoPersistencia();
                DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao(dispositivoPersistencia);
                if (dispositivoAplicacao.Excluir(Id))
                    return Ok();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }








        //[HttpPut]
        //[Route("dispositivo/editar")]
        //public Boolean Editar(Guid id, string nome, string latitude, string longitude)
        //{
        //    Dispositivo dispositivo = new Dispositivo();
        //    dispositivo.Id = id;
        //    dispositivo.Longitude = longitude;
        //    dispositivo.Latitude = latitude;
        //    dispositivo.Nome = nome;
        //    DispositivoAplicacao dispositivoAplicação = new DispositivoAplicacao();
        //    return dispositivoAplicação.Editar(dispositivo);
        //}








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