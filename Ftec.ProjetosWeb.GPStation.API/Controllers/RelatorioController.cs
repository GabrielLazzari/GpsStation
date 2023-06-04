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

    public class RelatorioController : ControllerBase
    {
        public RelatorioController() { }


        //[HttpGet]
        //public String Listar()
        //{
        //    List<Dispositivo> dispositivos = new List<Dispositivo>();
        //    DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
        //    dispositivos = dispositivoAplicacao.Listar();
        //    return JsonConvert.SerializeObject(dispositivos);
        //}




        [HttpGet("{inicio},{fim},{dispositivo}")]

        public IActionResult Get(DateTime inicio, DateTime fim, String dispositivo)
        {
            try
            {
                List<LocalizacaoModel> localizacaoModel = new List<LocalizacaoModel>();
                LocalizacaoAplicacao localizacaoAplicacao = new LocalizacaoAplicacao();
                var localizacao = localizacaoAplicacao.Consultar(inicio, fim, dispositivo);
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
