using GpsStation.Factory;
using GpsStation.Models;

namespace GpsStation.Repository
{
	public class UsuarioRepository
	{

		public UsuarioRepository()
		{

		}



		public List<UsuarioModel> ListarUsuario()
		{
			List<UsuarioModel> usuarios = new List<UsuarioModel>();
			usuarios = UsuarioFactory.GeradorMoqUsuarios(5);
			return usuarios;
		}



		public UsuarioModel ConsultarUsuario(Guid id)
		{
			List<UsuarioModel> usuarios = new List<UsuarioModel>();
			try
			{
				for (int i = 0; i < usuarios.Count; i++)
				{
					//if (usuarios[i].Id_usuario == id)
					//	return usuarios[i];
				}
				return null;
			}
			catch (Exception ex)
			{
				return null;
			}
		}




		public Boolean InserirUsuario(UsuarioModel usuario)
		{
			List<UsuarioModel> usuarios = new List<UsuarioModel>();
			try
			{
				usuarios.Add(new UsuarioModel()
				{
					//Administrador = usuario.Administrador,
					Nome = usuario.Nome,
					Senha = usuario.Senha,
				//	Id_usuario = Guid.NewGuid()
				});
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}




		public Boolean ExcluirUsuario(Guid id)
		{
			List<UsuarioModel> usuarios = new List<UsuarioModel>();
			try
			{
				usuarios.Remove(ConsultarUsuario(id));
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

	}
}
