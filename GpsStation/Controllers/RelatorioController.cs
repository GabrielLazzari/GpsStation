using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Microsoft.AspNetCore.Http;

namespace GpsStation.Controllers
{
    public class RelatorioController : Controller
    {
        private string strConexao;
        public RelatorioController(IConfiguration configuration)
        {
            strConexao = configuration.GetConnectionString("stringconexao");

        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString("usuario", "Teste de usuário logado");
            Inserir();
            List<DispositivoModel> dispositivoModel = new List<DispositivoModel>();

            DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
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
            return View(dispositivoModel);









        }



        public IActionResult Consultar(DateTime inicio, DateTime fim, String dispositivo)
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
            return Json(localizacaoModel);

        }





        /******* O MÉTODO INSERIR FOI UTILIZADO APENAS PARA TESTE, SERÁ SUBSTITUÍDO PELA API************/
        public void Inserir()
        {
            LocalizacaoAplicacao localizacaoAplicacao = new LocalizacaoAplicacao();
            localizacaoAplicacao.Inserir(new Localizacao()
            {
                IdDispositivo = Guid.Parse("DAD64957-59CF-434C-A907-F7127EB7A36A".ToString()),
                DataHora = DateTime.Parse("05 / 03 / 2023 22:51:00"),
                Latitude = "2",
                Longitude = "3",
            });
        }
    }
}
