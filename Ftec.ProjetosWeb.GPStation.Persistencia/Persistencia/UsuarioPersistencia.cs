using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia
{
	public class UsuarioPersistencia
	{
		public UsuarioPersistencia() { }

		public Boolean Inserir(Usuario usuario)
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
						comando.CommandText = "INSERT INTO[dbo].[usuario]([administrador],[nome],[senha],[Id_usuario])VALUES(@administrador,@nome,@senha,@id_usuario);";
						comando.Parameters.AddWithValue("administrador", usuario.Administrador);
						comando.Parameters.AddWithValue("nome", usuario.Nome);
						comando.Parameters.AddWithValue("senha", usuario.Senha);
						comando.Parameters.AddWithValue("id_usuario", usuario.Id_usuario);
						comando.ExecuteNonQuery();
						return true;
					}
				}
				catch (Exception ex)
				{
					return false;
				}
			}
		}
		//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public List<Usuario> Listar()
		{
			List<Usuario> usuarios = new List<Usuario>();
			string conexao = "Server = ACER_B\\TEW_SQLEXPRESS; Database = gpsstation; User Id = user; Password = 1234;";

			using (var con = new SqlConnection(conexao))
			{
				con.Open();
				try
				{
					using (var comando = new SqlCommand())
					{
						comando.Connection = con;
						comando.CommandText = "SELECT[administrador],[nome],[senha],[id_usuario]FROM[dbo].[usuario]";
						using (SqlDataReader reader = comando.ExecuteReader())
						{
							while (reader.Read())
							{
								usuarios.Add(new Usuario
								{
									Administrador = Convert.ToBoolean(reader["administrador"]),
									Nome = reader["nome"].ToString(),
									Senha = reader["senha"].ToString(),
									Id_usuario = Guid.Parse(reader["id_usuario"].ToString())
								});
							
							}
						}

					}
				}
				catch (Exception ex)
				{

				}
				return usuarios;
			}
		}
		//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public Boolean Editar(Usuario usuario)
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
						comando.CommandText = "UPDATE[dbo].[usuario]SET[nome]=@nome,[senha]=@senha WHERE[id_usuario]=@id_usuario;";
						comando.Parameters.AddWithValue("nome", usuario.Nome);
						comando.Parameters.AddWithValue("senha", usuario.Senha);
						comando.Parameters.AddWithValue("id_usuario", usuario.Id_usuario);
						comando.ExecuteNonQuery();
						return true;
					}
				}
				catch (Exception ex)
				{
					return false;
				}
			}
		}
		//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public Boolean Excluir(Guid id)
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
						comando.CommandText = "DELETE FROM[dbo].[usuario]WHERE[id_usuario]=@id_usuario;";
						comando.Parameters.AddWithValue("id_usuario", id);
						comando.ExecuteNonQuery();
						return true;
					}
				}
				catch (Exception ex)
				{
					return false;
				}
			}
		}
		//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public List<Usuario> Consultar(string nome)
		{
			List<Usuario> usuarios = new List<Usuario>();
			string conexao = "Server = ACER_B\\TEW_SQLEXPRESS; Database = gpsstation; User Id = user; Password = 1234;";

			using (var con = new SqlConnection(conexao))
			{
				con.Open();
				try
				{
					using (var comando = new SqlCommand())
					{
						comando.Connection = con;
						comando.CommandText = "SELECT[administrador],[nome],[senha],[id_usuario]FROM[dbo].[usuario]WHERE[nome]LIKE'%@nome%'";
						comando.Parameters.AddWithValue("nome", nome);
						using (SqlDataReader reader = comando.ExecuteReader())
						{
							while (reader.Read())
							{
								usuarios.Add(new Usuario
								{
									Administrador = Convert.ToBoolean(reader["administrador"]),
									Nome = reader["nome"].ToString(),
									Senha = reader["senha"].ToString(),
									Id_usuario = Guid.Parse(reader["id_usuario"].ToString())
								});

							}
						}

					}
				}
				catch (Exception ex)
				{

				}
				return usuarios;
			}
		}
	}
}


