using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Aplicacao.DTO
{
    public class LocalizacaoDTO
    {
        public Guid? IdDispositivo { get; set; }
        public DateTime? DataHora { get; set; } //datetime nullable
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
