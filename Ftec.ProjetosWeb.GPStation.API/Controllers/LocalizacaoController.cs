using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ftec.ProjetosWeb.GPStation.API.Controllers
{
    public class LocalizacaoController
    {
        public LocalizacaoController() { }

        [HttpPost]
        [Route("localizacao/inserir")]
        public void Inserir(Guid id, DateTime dateTime, string latitude, string longitude)
        {
            LocalizacaoAplicacao localizacaoAplicacao = new LocalizacaoAplicacao();
            localizacaoAplicacao.Inserir(new Localizacao()
            {
                IdDispositivo = Guid.Parse("DAD64957-59CF-434C-A907-F7127EB7A36A".ToString()),
                DataHora = DateTime.Parse("05 / 12 / 2023 22:51:00"),
                Latitude = "444",
                Longitude = "555",
            });
        }




        [HttpGet]
        [Route("localizacao/localizacaoatual")]
        public String LocalizacaoAtual(Guid Id)
        {
           Localizacao localizacao = new Localizacao();
            LocalizacaoAplicacao localizacaoAplicacao = new LocalizacaoAplicacao();
            localizacao = localizacaoAplicacao.LocalizacaoAtual(Id);
                return JsonConvert.SerializeObject(localizacao);
        }




    }
}
