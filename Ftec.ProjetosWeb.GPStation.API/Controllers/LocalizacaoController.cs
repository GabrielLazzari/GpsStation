using Ftec.ProjetosWeb.GPStation.API.Models;
using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Aplicacao.DTO;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace Ftec.ProjetosWeb.GPStation.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocalizacaoController : ControllerBase
    {
        public LocalizacaoController() { }

		Logger _logger = LogManager.GetLogger(new 
            DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName.Replace("\\bin\\Debug", ""));

		[HttpPost]
        public IActionResult Post([FromBody]Guid id, DateTime dateTime, string latitude, string longitude)
        {
            try
            {
                ILocalizacaoPersistencia localizacaoPersistencia= new LocalizacaoPersistencia();
                LocalizacaoAplicacao localizacaoAplicacao = new LocalizacaoAplicacao(localizacaoPersistencia);

                if (localizacaoAplicacao.Inserir(new LocalizacaoDTO()
                {
                    IdDispositivo = id,
                    DataHora = dateTime,
                    Latitude = latitude,
                    Longitude = longitude
                }))

                    return Ok();
                else
                {
					_logger.Info("Nao foi possivel inserir a localizacao");
					return BadRequest();
                }
            }
            catch (Exception ex)
            {
				_logger.Info(ex.Message);
				return BadRequest(ex.Message);
            }
            
        }






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
				_logger.Info(ex.Message);
				return BadRequest(ex.Message);
            }
        }

    }
}
