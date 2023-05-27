﻿using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
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

        List<Localizacao> relatorio = null;


        //******* LEMBRAR DE SUBSTITUIR PELA STRING QUE JÁ ESTÁ SALVA NO appsettings.json ********

        string stringconexao = "Server = ACER_B\\TEW_SQLEXPRESS; Database = gpsstation; User Id = user; Password = 1234;";
        //"Server = sdb; Database = teste_bruno; User Id = sa; Password = 217799;";




        public List<Localizacao> Consultar(String inicio, String fim, String dispositivo)

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
                                });
                            }
                            return relatorio;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
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

                        comando.Parameters.AddWithValue("IdDispositivo", localizacao.IdDispositivo);
                        comando.Parameters.AddWithValue("DataHora", localizacao.DataHora);
                        comando.Parameters.AddWithValue("Latitude", localizacao.Latitude);
                        comando.Parameters.AddWithValue("Longitude", localizacao.Longitude);
                        comando.ExecuteNonQuery();

                    }
                }
                catch (Exception ex)
                {
                    // registrar log de erro na inserção
                }
            }
        }




        public Localizacao LocalizacaoAtual(Guid dispositivo)
        {
            string conexao = stringconexao;
            Localizacao localizacao = null;

            using (var con = new SqlConnection(conexao))
            {
                con.Open();
                try
                {
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = con;
                        comando.CommandText =
 "SELECT TOP 1 [DataHora],[Latitude],[Longitude]FROM[dbo].[localizacao]WHERE[IdDispositivo]=@dispositivo ORDER BY [DataHora] DESC";
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
                catch (Exception ex)
                {
                    return null;
                }
                return null;
            }
        }







    }
}

