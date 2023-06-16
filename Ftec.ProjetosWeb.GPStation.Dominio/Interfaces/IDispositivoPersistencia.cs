using GpsStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Dominio.Interfaces
{
    public interface IDispositivoPersistencia
    {
        public List<Dispositivo> Consultar(string nome);
        public Boolean Editar(Dispositivo dispositivo);
        public Boolean Excluir(Guid id);
        public Boolean Inserir(Dispositivo dispositivo);
        public List<Dispositivo> Listar();
        public Dispositivo SelecionarPorId(Guid Id);
    }
}
