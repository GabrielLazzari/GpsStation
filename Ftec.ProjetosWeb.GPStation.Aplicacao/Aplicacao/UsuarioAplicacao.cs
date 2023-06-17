using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Aplicacao.Aplicacao
{
	public class UsuarioAplicacao
	{
		IUsuarioPersistencia usuarioPersistencia;

		public UsuarioAplicacao()
		{
			usuarioPersistencia = new UsuarioPersistencia();
		}
		public Boolean Inserir(Usuario usuario)
		{
			if (usuario.Id == Guid.Empty)
			{
				usuario.Id = Guid.NewGuid();
				return usuarioPersistencia.Inserir(usuario);
			}
			else
			{
				return Editar(usuario);
			}
		}

		public List<Usuario> Consultar(string nome)
		{
			return usuarioPersistencia.Consultar(nome);
		}

		public List<Usuario> Listar()
		{
			return usuarioPersistencia.Listar();
		}

		public Boolean Editar(Usuario usuario)
		{
			return usuarioPersistencia.Editar(usuario);
		}

		public Boolean Excluir(Guid id)
		{
			return usuarioPersistencia.Excluir(id);

		}

		public Boolean Login(String usuario, String senha)
		{
			return usuarioPersistencia.Login(usuario, senha);
		}

		public Usuario SelecionarPorId(Guid Id)
		{
			return usuarioPersistencia.SelecionarPorId(Id);
		}
	}
}
