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
			usuario.Id_usuario = Guid.NewGuid();
			return usuarioPersistencia.Inserir(usuario);
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

		public void Editar(Usuario usuario)
		{
			UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
			usuarioPersistencia.Editar(usuario);
			throw new NotImplementedException();
		}

		public void Excluir(Guid id)
		{
			UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
			usuarioPersistencia.Excluir(id);
			throw new NotImplementedException();
		}
	}
}
