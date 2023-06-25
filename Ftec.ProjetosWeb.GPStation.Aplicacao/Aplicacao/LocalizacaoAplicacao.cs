using Ftec.ProjetosWeb.GPStation.Aplicacao.Adapters;
using Ftec.ProjetosWeb.GPStation.Aplicacao.DTO;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia;
using GpsStation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao
{
    public class LocalizacaoAplicacao
    {
        ILocalizacaoPersistencia localizacaoPersistencia;
        public LocalizacaoAplicacao(ILocalizacaoPersistencia localizacaoPersistencia)
        {
            this.localizacaoPersistencia = localizacaoPersistencia;
        }



        public List<LocalizacaoDTO> Consultar(DateTime inicio, DateTime fim, String dispositivo)
        {
            var localizacoes = localizacaoPersistencia.Consultar(inicio.ToString("yyyy-MM-dd HH:mm:ss"), fim.ToString("yyyy-MM-dd HH:mm:ss"), dispositivo);
            var localizacoesDTO = new List<LocalizacaoDTO>();
            if (localizacoes is not null)
            {
                foreach (var item in localizacoes)
                {
                    localizacoesDTO.Add(LocalizacaoAdapter.ToLocalizacaoDTO(item));
                }
                return localizacoesDTO;
            }
            else
                return null;
        }

        public bool Inserir(LocalizacaoDTO localizacaoDTO)
        {
            var localizacao = new Localizacao();
            localizacao = LocalizacaoAdapter.ToLocalizacao(localizacaoDTO);
            return localizacaoPersistencia.Inserir(localizacao);
        }



        public LocalizacaoDTO LocalizacaoAtual(Guid Id)
        {
            var localizacao = localizacaoPersistencia.LocalizacaoAtual(Id);
            return LocalizacaoAdapter.ToLocalizacaoDTO(localizacao);
        }
    }
}
