using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia;
using GpsStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao
{
    public class LocalizacaoAplicacao
    {
        public LocalizacaoAplicacao() { }

       

        public List<Localizacao> Consultar(DateTime inicio, DateTime fim, String dispositivo)
        {
            LocalizcaoPersistencia localizacaoPersistencia = new LocalizcaoPersistencia();
            return localizacaoPersistencia.Consultar(inicio.ToString("yyyy-MM-dd HH:mm:ss"), fim.ToString("yyyy-MM-dd HH:mm:ss"), dispositivo);
        }

        public void Inserir(Localizacao localizacao)
        {
            LocalizcaoPersistencia localizcaoPersistencia = new LocalizcaoPersistencia();
            localizcaoPersistencia.Inserir(localizacao);
        }

       

        public Localizacao LocalizacaoAtual(Guid Id)
        {
            LocalizcaoPersistencia localizcaoPersistencia = new LocalizcaoPersistencia();
          return  localizcaoPersistencia.LocalizacaoAtual(Id);
        }
    }
}
