using Ftec.ProjetosWeb.GPStation.Aplicacao.Adapters;
using Ftec.ProjetosWeb.GPStation.Aplicacao.DTO;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao
{
    public class UsuarioAplicacao
    {
        IUsuarioPersistencia usuarioPersistencia;

        public UsuarioAplicacao(IUsuarioPersistencia usuarioPersistencia)
        {
            this.usuarioPersistencia = usuarioPersistencia;
        }


        public Boolean Inserir(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario();
            usuario = UsuarioAdapter.ToUsuario(usuarioDTO);

            if (usuario.Id == Guid.Empty)
            {
                usuario.Id = Guid.NewGuid();
                return usuarioPersistencia.Inserir(usuario);
            }
            else
            {
                return Editar(usuarioDTO);
            }
        }




        public List<UsuarioDTO> Consultar(string nome)
        {
            var usuarioDTO = new List<UsuarioDTO>();
            var usuarios = usuarioPersistencia.Consultar(nome);
            if (usuarios is not null)
            {
                foreach (var item in usuarios)
                {
                    usuarioDTO.Add(UsuarioAdapter.ToUsuarioDTO(item));
                }
                return usuarioDTO;
            }
            else
                return null;
        }




        public List<UsuarioDTO> Listar()
        {
            var usuarioDTO = new List<UsuarioDTO>();
            var usuarios = usuarioPersistencia.Listar();
            if (usuarios is not null)
            {
                foreach (var item in usuarios)
                {
                    usuarioDTO.Add(UsuarioAdapter.ToUsuarioDTO(item));
                }
                return usuarioDTO;
            }
            else
                return null;
        }



        public Boolean Editar(UsuarioDTO usuarioDTO)
        {
            Usuario usuario = new Usuario();
            usuario = UsuarioAdapter.ToUsuario(usuarioDTO);
            return usuarioPersistencia.Editar(usuario);
        }



        public Boolean Excluir(Guid id)
        {
            return usuarioPersistencia.Excluir(id);
        }



        public Guid Login(string usuario, string senha)
        {
            if (usuarioPersistencia.Login(usuario, senha))
                return new Guid();
            else
                return Guid.Empty;
        }



        public UsuarioDTO SelecionarPorId(Guid Id)
        {
            var usuario = usuarioPersistencia.SelecionarPorId(Id);
            return UsuarioAdapter.ToUsuarioDTO(usuario);
        }


    }
}
