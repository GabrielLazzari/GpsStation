using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
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
        ILocalizacaoPersistencia localizacaoPersistencia;
        public LocalizacaoAplicacao()
        {
            localizacaoPersistencia = new LocalizacaoPersistencia();
        }

       

        public List<Localizacao> Consultar(DateTime inicio, DateTime fim, String dispositivo)
        {
            return localizacaoPersistencia.Consultar(inicio.ToString("yyyy-MM-dd HH:mm:ss"), fim.ToString("yyyy-MM-dd HH:mm:ss"), dispositivo);
        }

        public void Inserir(Localizacao localizacao)
        {
            localizacaoPersistencia.Inserir(localizacao);
        }

       

        public Localizacao LocalizacaoAtual(Guid Id)
        {
          return  localizacaoPersistencia.LocalizacaoAtual(Id);
        }
    }
}
