using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia
{
	public class UsuarioPersistencia
	{
		public UsuarioPersistencia() { }

		public String Inserir(Usuario usuario)
		{
			string conexao = "Server = ACER_B\\TEW_SQLEXPRESS; Database = gpsstation; User Id = user; Password = 1234;";

			using (var con = new SqlConnection(conexao))
			{
				con.Open();
				try
				{
					using (var comando = new SqlCommand())
					{
						comando.Connection = con;
						comando.CommandText = "INSERT INTO[dbo].[usuario] ([administrador] ,[nome] ,[senha] ,[Id_usuario]) VALUES(@administrador, @nome, @senha, @id_usuario);";
						comando.Parameters.AddWithValue("administrador", usuario.Administrador);
						comando.Parameters.AddWithValue("nome", usuario.Nome);
						comando.Parameters.AddWithValue("senha", usuario.Senha);
						comando.Parameters.AddWithValue("id_usuario", usuario.Id_usuario);
						comando.ExecuteNonQuery();
						return "inserido";
					}
				}
				catch (Exception ex)
				{
					return "ocorreu um erro";
				}

			}

		}
		//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public List<Usuario> Consultar(int n)
		{
			List<Usuario> usuarios = new List<Usuario>();
			for (int i = 0; i < n; i++)
			{
				usuarios.Add(new Usuario()
				{
					Administrador = true,
					Nome = "teste",//string.Empty,
					Senha = "",//string.Empty,
					Id_usuario = Guid.NewGuid()
				});
			}
			return usuarios;
		}
		//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------











		//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	}
}


