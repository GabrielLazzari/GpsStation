using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using GpsStation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia
{
	public class DispositivoPersistencia
	{
		public DispositivoPersistencia() { }
        string stringconexao = "Server = ACER_B\\TEW_SQLEXPRESS; Database = gpsstation; User Id = user; Password = 1234;";
      //  "Server = sdb; Database = teste_bruno; User Id = sa; Password = 217799;";
        public List<Dispositivo> Consultar(string nome)

		{
			List<Dispositivo> dispositivos = new List<Dispositivo>();
			string conexao = stringconexao;

			using (var con = new SqlConnection(conexao))
			{
				con.Open();
				try
				{
					using (var comando = new SqlCommand())
					{
						comando.Connection = con;
						comando.CommandText =
							"SELECT[Id],[Nome],[Latitude],[Longitude]FROM[dbo].[dispositivo]WHERE[Nome]LIKE'%@Nome%'ORDER BY [Nome]";
						comando.Parameters.AddWithValue("Nome", nome);
						using (SqlDataReader reader = comando.ExecuteReader())
						{
							while (reader.Read())
							{
								dispositivos.Add(new Dispositivo
								{
									Id = Guid.Parse(reader["Id"].ToString()),
									Nome = reader["Nome"].ToString(),
									Latitude = reader["Latitude"].ToString(),
									Longitude = reader["Longitude"].ToString()
								});
							}
						}
					}
				}
				catch (Exception ex)
				{

				}
				return dispositivos;
			}
		}
		//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public Boolean Editar(Dispositivo dispositivo)
		{
			string conexao = stringconexao;

			using (var con = new SqlConnection(conexao))
			{
				con.Open();
				try
				{
					using (var comando = new SqlCommand())
					{
						comando.Connection = con;
						comando.CommandText =
"UPDATE[dbo].[dispositivo]SET[Nome]=@Nome WHERE[Id]=@Id;";
						comando.Parameters.AddWithValue("Id", dispositivo.Id);
						comando.Parameters.AddWithValue("Nome", dispositivo.Nome);
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
		//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public Boolean Excluir(Guid id)
		{
			string conexao = stringconexao;

			using (var con = new SqlConnection(conexao))
			{
				con.Open();
				try
				{
					using (var comando = new SqlCommand())
					{
						comando.Connection = con;
						comando.CommandText = "DELETE FROM[dbo].[dispositivo]WHERE[Id]=@Id;";
						comando.Parameters.AddWithValue("Id", id.ToString());
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
	
		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public Boolean Inserir(Dispositivo dispositivo)
		{
			string conexao = stringconexao;

			using (var con = new SqlConnection(conexao))
			{
				con.Open();
				try
				{
					using (var comando = new SqlCommand())
					{
						comando.Connection = con;
						comando.CommandText =
"INSERT INTO[dbo].[dispositivo] ([Id],[Nome],[Latitude],[Longitude])VALUES(@Id,@Nome,@Latitude,@Longitude);";

						comando.Parameters.AddWithValue("Id", dispositivo.Id);
						comando.Parameters.AddWithValue("Nome", dispositivo.Nome);
						comando.Parameters.AddWithValue("Latitude", dispositivo.Latitude);
						comando.Parameters.AddWithValue("Longitude", dispositivo.Longitude);
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
		//-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
		public List<Dispositivo> Listar()
		{
			List<Dispositivo> dispositivos = new List<Dispositivo>();
			string conexao = stringconexao;

			using (var con = new SqlConnection(conexao))
			{
				con.Open();
				try
				{
					using (var comando = new SqlCommand())
					{
						comando.Connection = con;
						comando.CommandText = "SELECT[Id],[Nome],[Latitude],[Longitude]FROM[dbo].[dispositivo]ORDER BY [Nome]";
						using (SqlDataReader reader = comando.ExecuteReader())
						{
							while (reader.Read())
							{
								dispositivos.Add(new Dispositivo
								{
									Id = Guid.Parse(reader["Id"].ToString()),
									Nome = reader["Nome"].ToString(),
									Latitude = reader["Latitude"].ToString(),
									Longitude = reader["Longitude"].ToString()
								});
							}
						}
					}
				}
				catch (Exception ex)
				{

				}
				return dispositivos;
			}
		}

		public Dispositivo SelecionarPorId(Guid Id)
		{
			Dispositivo dispositivo = new Dispositivo();
			string conexao = stringconexao;

			using (var con = new SqlConnection(conexao))
			{
				con.Open();
				try
				{
					using (var comando = new SqlCommand())
					{
						comando.Connection = con;
						comando.CommandText =
							"SELECT[Id],[Nome],[Latitude],[Longitude]FROM[dbo].[dispositivo]WHERE[Id]=@Id";
						comando.Parameters.AddWithValue("Id", Id);
						using (SqlDataReader reader = comando.ExecuteReader())
						{
							reader.Read();

							dispositivo.Id = Guid.Parse(reader["Id"].ToString());
							dispositivo.Nome = reader["Nome"].ToString();
							dispositivo.Latitude = reader["Latitude"].ToString();
							dispositivo.Longitude = reader["Longitude"].ToString();
							
						}
					}
				}
				catch (Exception ex)
				{

				}
				return dispositivo;
			}
		}
	}
}
