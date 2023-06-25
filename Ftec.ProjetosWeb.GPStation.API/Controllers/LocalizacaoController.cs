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
    [Route("[controller]")]
    [ApiController]
    public class LocalizacaoController : ControllerBase
    {
        public LocalizacaoController() { }





        [HttpPost]
        public IActionResult Post([FromBody]Guid id, DateTime dateTime, string latitude, string longitude)
        {
            try
            {
                ILocalizacaoPersistencia localizacaoPersistencia= new LocalizacaoPersistencia();
                LocalizacaoAplicacao localizacaoAplicacao = new LocalizacaoAplicacao(localizacaoPersistencia);

                if (localizacaoAplicacao.Inserir(new LocalizacaoDTO()
                {
                    IdDispositivo = id, // Guid.Parse("DAD64957-59CF-434C-A907-F7127EB7A36A".ToString()),
                    DataHora = dateTime, // DateTime.Parse("05 / 12 / 2023 22:51:00"),
                    Latitude = latitude, //"444",
                    Longitude = longitude // "555",
                }))
                
                return Ok();
              else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }








        //[HttpGet]
        //[Route("localizacao/localizacaoatual")]
        //public String LocalizacaoAtual(Guid Id)
        //{
        //   Localizacao localizacao = new Localizacao();
        //    LocalizacaoAplicacao localizacaoAplicacao = new LocalizacaoAplicacao();
        //    localizacao = localizacaoAplicacao.LocalizacaoAtual(Id);
        //        return JsonConvert.SerializeObject(localizacao);
        //}







        [HttpGet("{inicio},{fim},{dispositivo}")]
        public IActionResult Get(string inicio, string fim, string dispositivo)
        {
            try
            {
                List<LocalizacaoModel> localizacaoModel = new List<LocalizacaoModel>();
                ILocalizacaoPersistencia localizacaoPersistencia = new LocalizacaoPersistencia();
                LocalizacaoAplicacao localizacaoAplicacao = new LocalizacaoAplicacao(localizacaoPersistencia);

                var localizacao = localizacaoAplicacao.Consultar(DateTime.Parse(inicio), DateTime.Parse(fim), dispositivo);
                foreach (var loc in localizacao)
                {
                    localizacaoModel.Add(new LocalizacaoModel()
                    {
                        IdDispositivo = loc.IdDispositivo,
                        DataHora = loc.DataHora,
                        Latitude = loc.Latitude,
                        Longitude = loc.Longitude
                    });
                }
                return Ok(localizacaoModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
