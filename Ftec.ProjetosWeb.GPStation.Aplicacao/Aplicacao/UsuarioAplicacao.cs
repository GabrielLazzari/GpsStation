using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
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
		public Boolean Inserir(Usuario usuario)
		{
			UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
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
			UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
			return usuarioPersistencia.Consultar(nome);
		}

		public List<Usuario> Listar()
		{
			UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
			return usuarioPersistencia.Listar();
		}

		public Boolean Editar(Usuario usuario)
		{
			UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
			return usuarioPersistencia.Editar(usuario);
		}

		public Boolean Excluir(Guid id)
		{
			UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
			return usuarioPersistencia.Excluir(id);

		}

		public Boolean Login(String usuario, String senha)
		{
			UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
			return usuarioPersistencia.Login(usuario, senha);
		}

		public Usuario SelecionarPorId(Guid Id)
		{
			UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
			return usuarioPersistencia.SelecionarPorId(Id);
		}
	}
}
