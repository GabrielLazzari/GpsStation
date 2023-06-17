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
    public class DispositivoAplicacao
    {
        //cria variável do tipo da interface
        IDispositivoPersistencia dispositivoPersistencia;

        public DispositivoAplicacao()
        {
            //instancia a classe que implementa os métodos da Interface
            //utiliza a mesma variável que era usada para instanciar a classe persistência, mas agora chamando pela interface e
            //não diretamente pela classe
            dispositivoPersistencia = new DispositivoPersistencia();
        }

        public List<Dispositivo> Listar()
        {
            return dispositivoPersistencia.Listar();
        }

        public Boolean Inserir(Dispositivo dispositivo)
        {
            if (dispositivo.Id == Guid.Empty || dispositivo.Id == null)
            {
                dispositivo.Id = Guid.NewGuid();
                dispositivo.Latitude = "0";
                dispositivo.Longitude = "0";
                return dispositivoPersistencia.Inserir(dispositivo);
            }
            else
            {
                return Editar(dispositivo);
            }
        }

        public List<Dispositivo> Consultar(string nome)
        {
            return dispositivoPersistencia.Consultar(nome);
        }

        public Boolean Editar(Dispositivo dispositivo)
        {
            return dispositivoPersistencia.Editar(dispositivo);

        }

        public Boolean Excluir(Guid id)
        {
            return dispositivoPersistencia.Excluir(id);

        }

        public Dispositivo SelecionarPorId(Guid Id)
        {
            return dispositivoPersistencia.SelecionarPorId(Id);
        }
    }
}
