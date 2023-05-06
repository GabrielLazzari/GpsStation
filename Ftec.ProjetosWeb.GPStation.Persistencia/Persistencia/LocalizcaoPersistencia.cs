using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using GpsStation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia
{
	public class LocalizcaoPersistencia
	{
		public LocalizcaoPersistencia() { }
        string stringconexao = "Server = ACER_B\\TEW_SQLEXPRESS; Database = gpsstation; User Id = user; Password = 1234;";
      //"Server = sdb; Database = teste_bruno; User Id = sa; Password = 217799;";
        public List<Localizacao> Consultar(String inicio, String fim, String dispositivo)

		{
			List<Localizacao> relatorio = new List<Localizacao>();
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
						"SELECT[DataHora],[Latitude],[Longitude]FROM[dbo].[localizacao]WHERE[DataHora]>=@inicio AND[DataHora]<=@fim AND[IdDispositivo]=@dispositivo";

						//"SELECT[dbo].[localizacao].[DataHora],[dbo].[localizacao].[Latitude],[dbo].[localizacao].[Longitude],[dbo].[dispositivo].[Nome] from[dbo].[localizacao] INNER JOIN[dbo].[dispositivo]ON[dbo].[localizacao].[IdDispositivo] =[dbo].[dispositivo].[Id] AND[dbo].[localizacao].[DataHora]>= @inicio AND[dbo].[localizacao].[DataHora] <= @fim AND[dbo].[dispositivo].[Id] = @dispositivo";

						comando.Parameters.AddWithValue("dispositivo", dispositivo);
						comando.Parameters.AddWithValue("inicio", inicio);
						comando.Parameters.AddWithValue("fim", fim);
						//'2023-04-30 23:21:12'
						using (SqlDataReader reader = comando.ExecuteReader())
						{
							while (reader.Read())
							{
								relatorio.Add(new Localizacao
								{
									DataHora = (DateTime)reader["DataHora"],
									Latitude = reader["Latitude"].ToString(),
									Longitude = reader["Longitude"].ToString(),
									
								}) ;
							}
						}
					}
				}
				catch (Exception ex)
				{

				}
				return relatorio;
			}
		}

		public void Inserir(Localizacao localizacao)
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
"INSERT INTO[dbo].[localizacao]([IdDispositivo],[DataHora],[Latitude],[Longitude])VALUES(@IdDispositivo,@DataHora,@Latitude,@Longitude);";

						//"INSERT INTO[dbo].[dispositivo] ([Id],[IdUsuario],[Nome],[Ativo],[Latitude],[Longitude])VALUES(@Id,@IdUsuario,@Nome,@Ativo,@Latitude,@Longitude);";

						comando.Parameters.AddWithValue("IdDispositivo", localizacao.IdDispositivo);
						comando.Parameters.AddWithValue("DataHora", localizacao.DataHora);
						comando.Parameters.AddWithValue("Latitude", localizacao.Latitude);
						comando.Parameters.AddWithValue("Longitude", localizacao.Longitude);
						comando.ExecuteNonQuery();

					}
				}
				catch (Exception ex)
				{

				}
			}
		}
	}
}
