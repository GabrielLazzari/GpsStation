using System.Data.SqlClient;

namespace GpsStation.Models
{
	public class UsuarioModel
	{
		public UsuarioModel() { }
		public UsuarioModel(Boolean administrador, string nome, string senha, Guid id_usuario)
		{
			Administrador = administrador;
			Nome = nome;
			Senha = senha;
			Id_usuario = id_usuario;
		}
		public Boolean Administrador { get; set; }
		public string Nome { get; set; }
		public string Senha { get; set; }
		public Guid Id_usuario { get; set; }

	}
}

