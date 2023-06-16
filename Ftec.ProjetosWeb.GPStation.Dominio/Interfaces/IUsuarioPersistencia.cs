using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Dominio.Interfaces
{
    public interface IUsuarioPersistencia
    {
        public Boolean Inserir(Usuario usuario);

        public List<Usuario> Listar();

        public Boolean Editar(Usuario usuario);

        public Boolean Excluir(Guid id);

        public List<Usuario> Consultar(string nome);

        public Boolean Login(string usuario, string senha);

        public Usuario SelecionarPorId(Guid Id);

    }
}
