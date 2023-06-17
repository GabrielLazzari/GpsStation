using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Dominio.Interfaces
{
    public interface ILocalizacaoPersistencia
    {
        public List<Localizacao> Consultar(String inicio, String fim, String dispositivo);

        public bool Inserir(Localizacao localizacao);

        public Localizacao LocalizacaoAtual(Guid dispositivo);


    }
}
