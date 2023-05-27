using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ftec.ProjetosWeb.GPStation.API.Controllers
{
    public class RelatorioController
    {
        public RelatorioController() { }


        [HttpGet]
        [Route("relatorio/listar")]
        public String Listar()
        {
            List<Dispositivo> dispositivos = new List<Dispositivo>();
            DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
            dispositivos = dispositivoAplicacao.Listar();
            return JsonConvert.SerializeObject(dispositivos);
        }




        [HttpGet]
        [Route("relatorio/consultar")]
        public String Consultar(DateTime inicio, DateTime fim, String dispositivo)
        {
            List<Localizacao> localizacoes= new List<Localizacao>();
            LocalizacaoAplicacao localizacaoAplicacao = new LocalizacaoAplicacao();
            localizacoes = localizacaoAplicacao.Consultar(inicio, fim, dispositivo);
            return JsonConvert.SerializeObject(localizacoes);
        }



    }
}
