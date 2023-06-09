﻿using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;


namespace Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia
{
	public class LocalizacaoPersistencia : ILocalizacaoPersistencia
	{
		public LocalizacaoPersistencia() { }
		private List<Localizacao> relatorio = null;
		private SqlTransaction transacao;

		private string stringconexao = "Server = ACER_B\\TEW_SQLEXPRESS; Database = gpsstation; User Id = user; Password = 1234;";
		//"Server = sdb; Database = teste_bruno; User Id = sa; Password = 217799;";

		public List<Localizacao> Consultar(string inicio, string fim, string dispositivo)
		{
			var con = new SqlConnection(stringconexao);

			try
			{
				using (con)
				{

					con.Open();
					using (var comando = new SqlCommand())
					{
						comando.Connection = con;
						comando.CommandText =
						"SELECT[DataHora],[Latitude],[Longitude]FROM[dbo].[localizacao]WHERE[DataHora]>=@inicio AND[DataHora]<=@fim AND[IdDispositivo]=@dispositivo";
						comando.Parameters.AddWithValue("dispositivo", dispositivo);
						comando.Parameters.AddWithValue("inicio", inicio);
						comando.Parameters.AddWithValue("fim", fim);
						using (SqlDataReader reader = comando.ExecuteReader())
						{
							relatorio = new List<Localizacao>();
							while (reader.Read())
							{
								relatorio.Add(new Localizacao
								{
									DataHora = (DateTime)reader["DataHora"],
									Latitude = reader["Latitude"].ToString(),
									Longitude = reader["Longitude"].ToString(),
									IdDispositivo = Guid.Parse(dispositivo),
								});
							}

							return relatorio;
						}
					}
				}
			}
			catch (Exception ex)
			{

				string Mensagem = ex.Message;
				string Metodo = MethodBase.GetCurrentMethod().Name;
				string Classe = MethodBase.GetCurrentMethod().DeclaringType.Name;
				DateTime dateTime = DateTime.Now;
				ErroPersistencia erro = new ErroPersistencia();
				erro.Inserir(Mensagem, Metodo, Classe, dateTime);
				return null;
			}

		}



		public bool Inserir(Localizacao localizacao)
		{
			var con = new SqlConnection(stringconexao);

			try
			{
				con.Open();
				transacao = con.BeginTransaction();
				using (var comando = new SqlCommand())
				{
					comando.Transaction = transacao;
					comando.Connection = con;
					comando.CommandText ="INSERT INTO[dbo].[localizacao]([IdDispositivo],[DataHora],[Latitude],[Longitude])VALUES(@IdDispositivo,@DataHora,@Latitude,@Longitude);";
					comando.Parameters.AddWithValue("IdDispositivo", localizacao.IdDispositivo);
					comando.Parameters.AddWithValue("DataHora", localizacao.DataHora);
					comando.Parameters.AddWithValue("Latitude", localizacao.Latitude);
					comando.Parameters.AddWithValue("Longitude", localizacao.Longitude);
					comando.ExecuteNonQuery();
					transacao.Commit();
				}
			}
			catch (Exception ex)
			{
				if (con.State == ConnectionState.Open)
				{
					transacao.Rollback();
					con.Dispose();
				}
				string Mensagem = ex.Message;
				string Metodo = MethodBase.GetCurrentMethod().Name;
				string Classe = MethodBase.GetCurrentMethod().DeclaringType.Name;
				DateTime dateTime = DateTime.Now;
				ErroPersistencia erro = new ErroPersistencia();
				erro.Inserir(Mensagem, Metodo, Classe, dateTime);
				return false;
			}
			con.Dispose();
			return true;
		}



		public Localizacao LocalizacaoAtual(Guid dispositivo)
		{
			var con = new SqlConnection(stringconexao);
			Localizacao localizacao = null;
			try
			{
				con.Open();
				using (con)
				{
					using (var comando = new SqlCommand())
					{
						comando.Connection = con;
						comando.CommandText = "SELECT TOP 1 [DataHora],[Latitude],[Longitude]FROM[dbo].[localizacao]WHERE[IdDispositivo]=@dispositivo ORDER BY [DataHora] DESC";
						comando.Parameters.AddWithValue("dispositivo", dispositivo);
						using (SqlDataReader reader = comando.ExecuteReader())
						{
							localizacao = new Localizacao();
							while (reader.Read())
							{
								localizacao.DataHora = (DateTime)reader["DataHora"];
								localizacao.Latitude = reader["Latitude"].ToString();
								localizacao.Longitude = reader["Longitude"].ToString();
							}
							return localizacao;
						}
					}
				}
			}
			catch (Exception ex)
			{
				string Mensagem = ex.Message;
				string Metodo = MethodBase.GetCurrentMethod().Name;
				string Classe = MethodBase.GetCurrentMethod().DeclaringType.Name;
				DateTime dateTime = DateTime.Now;
				ErroPersistencia erro = new ErroPersistencia();
				erro.Inserir(Mensagem, Metodo, Classe, dateTime);
				return null;
			}
		}
	}
}
