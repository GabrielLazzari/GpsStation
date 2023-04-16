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
        public String Inserir(Usuario usuario)
        {
			 UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
			usuario.Id_usuario=Guid.NewGuid();
            //regras de negocio
            if(string.IsNullOrEmpty(usuario.Nome) ) {
                throw new ApplicationException("");
            }
            return usuarioPersistencia.Inserir(usuario);
        }
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public List<Usuario> Consultar(int n)
        {
			UsuarioPersistencia usuarioPersistencia = new UsuarioPersistencia();
			List<Usuario> usuarios = new List<Usuario>();
            return usuarioPersistencia.Consultar(n);
		}
		//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------


	}
}
