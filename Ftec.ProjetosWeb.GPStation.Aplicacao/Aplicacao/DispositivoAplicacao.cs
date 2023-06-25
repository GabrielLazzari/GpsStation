using Ftec.ProjetosWeb.GPStation.Aplicacao.Adapter;
using Ftec.ProjetosWeb.GPStation.Aplicacao.DTO;
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

        public DispositivoAplicacao(IDispositivoPersistencia dispositivoPersistencia)
        {
            //instancia a classe que implementa os métodos da Interface
            //utiliza a mesma variável que era usada para instanciar a classe persistência, mas agora chamando pela interface e
            //não diretamente pela classe
            this.dispositivoPersistencia = dispositivoPersistencia;
        }

        public List<DispositivoDTO> Listar()
        {
            var dispositivos =  dispositivoPersistencia.Listar();
            var dispositivosDTO = new List<DispositivoDTO>();
            if (dispositivos is not null)
            {
                foreach (var dispositivo in dispositivos)
                {
                    dispositivosDTO.Add(DispositivoAdapter.ToDispositivoDTO(dispositivo));
                }
                return dispositivosDTO;
            }
            else
                return null;
        }

        public Boolean Inserir(DispositivoDTO dispositivoDTO)
        {
            var dispositivo = new Dispositivo();
            dispositivo = DispositivoAdapter.ToDispositivo(dispositivoDTO);

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

        public List<DispositivoDTO> Consultar(string nome)
        {
            var dispositivos = dispositivoPersistencia.Consultar(nome);
            var dispositivosDTO = new List<DispositivoDTO>();
            if (dispositivos is not null)
            {
                foreach (var dispositivo in dispositivos)
                {
                    dispositivosDTO.Add(DispositivoAdapter.ToDispositivoDTO(dispositivo));
                }
                return dispositivosDTO;
            }
            else
                return null;
        }

        public Boolean Editar(Dispositivo dispositivo)
        {
            return dispositivoPersistencia.Editar(dispositivo);
        }

        public Boolean Excluir(Guid id)
        {
            return dispositivoPersistencia.Excluir(id);

        }

        public DispositivoDTO SelecionarPorId(Guid Id)
        {
            var dispositivo = dispositivoPersistencia.SelecionarPorId(Id);
            var dispositivoDTO = new DispositivoDTO();
                dispositivoDTO = DispositivoAdapter.ToDispositivoDTO(dispositivo);
            return dispositivoDTO;
        }
    }
}
