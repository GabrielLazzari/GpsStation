using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Aplicacao.DTO
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
