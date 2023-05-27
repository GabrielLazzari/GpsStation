using Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using GpsStation.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Ftec.ProjetosWeb.GPStation.API.Controllers
{
    public class DispositivoController
    {
        public DispositivoController() { }






        [HttpGet]
        [Route("dispositivo/listar")]
        public String Listar()
        {
            List<Dispositivo> dispositivos = new List<Dispositivo>();
            DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
            dispositivos = dispositivoAplicacao.Listar();
             return JsonConvert.SerializeObject(dispositivos); 
        }









        [HttpGet]
        [Route("dispositivo/consultar")]
        public String Consultar(string nome)
        {
            List<Dispositivo> dispositivos = new List<Dispositivo>();
            DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
            dispositivos = dispositivoAplicacao.Consultar(nome);
            return JsonConvert.SerializeObject(dispositivos);
        }







        [HttpPost]
        [Route("dispositivo/inserir")]
        public Boolean Inserir(Guid id, string nome, string latitude, string longitude)
        {
            Dispositivo dispositivo = new Dispositivo();
            dispositivo.Id = id;
            dispositivo.Longitude = longitude;
            dispositivo.Latitude = latitude;
            dispositivo.Nome = nome;
            DispositivoAplicacao dispositivoAplicação = new DispositivoAplicacao();
            return dispositivoAplicação.Inserir(dispositivo);
        }










        [HttpDelete]
        [Route("dispositivo/excluir")]
        public Boolean Excluir(Guid Id)
        {
            DispositivoAplicacao dispositivoAplicacao = new DispositivoAplicacao();
            return dispositivoAplicacao.Excluir(Id);
        }








        [HttpPut]
        [Route("dispositivo/editar")]
        public Boolean Editar(Guid id, string nome, string latitude, string longitude)
        {
            Dispositivo dispositivo = new Dispositivo();
            dispositivo.Id = id;
            dispositivo.Longitude = longitude;
            dispositivo.Latitude = latitude;
            dispositivo.Nome = nome;
            DispositivoAplicacao dispositivoAplicação = new DispositivoAplicacao();
            return dispositivoAplicação.Editar(dispositivo);
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