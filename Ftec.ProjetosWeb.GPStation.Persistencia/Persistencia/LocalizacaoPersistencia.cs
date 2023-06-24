using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia
{
    public class LocalizacaoPersistencia : ILocalizacaoPersistencia
    {
        public LocalizacaoPersistencia(){ }
        private List<Localizacao> relatorio = null;
        private SqlTransaction transacao;
     

        //******* LEMBRAR DE SUBSTITUIR PELA STRING QUE JÁ ESTÁ SALVA NO appsettings.json ********

       private  string stringconexao = "Server = ACER_B\\TEW_SQLEXPRESS; Database = gpsstation; User Id = user; Password = 1234;";
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

            con.Open();
            try
            {
                using (con)
                {
                    transacao = con.BeginTransaction();
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
                        transacao.Commit();
                 return true;

                    }
                }
            }
            catch (Exception ex)
            {
               transacao.Rollback();
                string Mensagem = ex.Message;
                string Metodo = MethodBase.GetCurrentMethod().Name;
                string Classe = MethodBase.GetCurrentMethod().DeclaringType.Name;
                DateTime dateTime = DateTime.Now;
                ErroPersistencia erro = new ErroPersistencia();
                erro.Inserir(Mensagem, Metodo, Classe, dateTime);
                return false;
            }

        }

        public Localizacao LocalizacaoAtual(Guid dispositivo)
        {
            var con = new SqlConnection(stringconexao);
            con.Open();
            try
            {
                Localizacao localizacao = null;

                using (con)
                {
                    transacao = con.BeginTransaction();
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
                           transacao.Commit();
                            return localizacao;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                transacao.Rollback();
                string Mensagem = ex.Message;
                string Metodo = MethodBase.GetCurrentMethod().Name;
                string Classe = MethodBase.GetCurrentMethod().DeclaringType.Name;
                DateTime dateTime = DateTime.Now;
                ErroPersistencia erro = new ErroPersistencia();
                erro.Inserir(Mensagem, Metodo, Classe, dateTime);
                return null;
            }
            return null;

        }
    }
}
