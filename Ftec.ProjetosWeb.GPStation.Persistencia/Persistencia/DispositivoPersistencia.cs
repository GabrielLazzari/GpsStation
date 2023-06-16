using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using GpsStation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia
{
    public class DispositivoPersistencia : IDispositivoPersistencia
    {
        public DispositivoPersistencia() { }
        List<Dispositivo> dispositivos = null;
        Dispositivo dispositivo = null;


        //******* LEMBRAR DE SUBSTITUIR PELA STRING QUE JÁ ESTÁ SALVA NO appsettings.json ********

        string stringconexao = "Server = ACER_B\\TEW_SQLEXPRESS; Database = gpsstation; User Id = user; Password = 1234;";
        //"Server = sdb; Database = teste_bruno; User Id = sa; Password = 217799;";

        public List<Dispositivo> Consultar(string nome)
        {
            var con = new SqlConnection(stringconexao);
            SqlTransaction sqlTransaction = con.BeginTransaction();
            try
            {
                using (con)
                {
                    con.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Transaction = sqlTransaction;
                        comando.Connection = con;
                        comando.CommandText =
                            "SELECT[Id],[Nome],[Latitude],[Longitude]FROM[dbo].[dispositivo]WHERE[Nome]=@Nome ORDER BY [Nome]";//like '%@nome%' nao recupera nenhum registro
                        comando.Parameters.AddWithValue("Nome", nome);
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            dispositivos = new List<Dispositivo>();
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
                            sqlTransaction.Commit();
                            return dispositivos;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                string Mensagem = ex.Message;
                string Metodo = MethodBase.GetCurrentMethod().Name;
                string Classe = MethodBase.GetCurrentMethod().DeclaringType.Name;
                DateTime dateTime = DateTime.Now;
                ErroPersistencia erro = new ErroPersistencia();
                erro.Inserir(Mensagem, Metodo, Classe, dateTime);
                return null;
            }
        }

        public bool Editar(Dispositivo dispositivo)
        {
            var con = new SqlConnection(stringconexao);
            SqlTransaction sqlTransaction = con.BeginTransaction();
            try
            {
                using (con)
                {
                    con.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = con;
                        comando.CommandText = "UPDATE[dbo].[dispositivo]SET[Nome]=@Nome WHERE[Id]=@Id;";
                        comando.Parameters.AddWithValue("Id", dispositivo.Id);
                        comando.Parameters.AddWithValue("Nome", dispositivo.Nome);
                        comando.ExecuteNonQuery();
                        sqlTransaction.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                string Mensagem = ex.Message;
                string Metodo = MethodBase.GetCurrentMethod().Name;
                string Classe = MethodBase.GetCurrentMethod().DeclaringType.Name;
                DateTime dateTime = DateTime.Now;
                ErroPersistencia erro = new ErroPersistencia();
                erro.Inserir(Mensagem, Metodo, Classe, dateTime);
                return false;
            }

        }

        public bool Excluir(Guid id)
        {
            var con = new SqlConnection(stringconexao);
            SqlTransaction sqlTransaction = con.BeginTransaction();
            try
            {
                using (con)
                {
                    con.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = con;
                        comando.CommandText = "DELETE FROM[dbo].[dispositivo]WHERE[Id]=@Id;";
                        comando.Parameters.AddWithValue("Id", id.ToString());
                        comando.ExecuteNonQuery();
                        sqlTransaction.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                string Mensagem = ex.Message;
                string Metodo = MethodBase.GetCurrentMethod().Name;
                string Classe = MethodBase.GetCurrentMethod().DeclaringType.Name;
                DateTime dateTime = DateTime.Now;
                ErroPersistencia erro = new ErroPersistencia();
                erro.Inserir(Mensagem, Metodo, Classe, dateTime);
                return false;
            }

        }

        public bool Inserir(Dispositivo dispositivo)
        {
            var con = new SqlConnection(stringconexao);
            SqlTransaction sqlTransaction = con.BeginTransaction();
            try
            {
                using (con)
                {
                    con.Open();
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
                        sqlTransaction.Commit();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                string Mensagem = ex.Message;
                string Metodo = MethodBase.GetCurrentMethod().Name;
                string Classe = MethodBase.GetCurrentMethod().DeclaringType.Name;
                DateTime dateTime = DateTime.Now;
                ErroPersistencia erro = new ErroPersistencia();
                erro.Inserir(Mensagem, Metodo, Classe, dateTime);
                return false;
            }

        }

        public List<Dispositivo> Listar()
        {
            var con = new SqlConnection(stringconexao);
            SqlTransaction sqlTransaction = con.BeginTransaction();
            try
            {
                using (con)
                {

                    con.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = con;
                        comando.CommandText = "SELECT[Id],[Nome],[Latitude],[Longitude]FROM[dbo].[dispositivo]ORDER BY [Nome]";
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            dispositivos = new List<Dispositivo>();
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
                            sqlTransaction.Commit();
                            return dispositivos;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
                string Mensagem = ex.Message;
                string Metodo = MethodBase.GetCurrentMethod().Name;
                string Classe = MethodBase.GetCurrentMethod().DeclaringType.Name;
                DateTime dateTime = DateTime.Now;
                ErroPersistencia erro = new ErroPersistencia();
                erro.Inserir(Mensagem, Metodo, Classe, dateTime);
                return null;
            }

        }

        public Dispositivo SelecionarPorId(Guid Id)
        {
            var con = new SqlConnection(stringconexao);
            SqlTransaction sqlTransaction = con.BeginTransaction();
            try
            {
                using (con)
                {

                    con.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = con;
                        comando.CommandText =
                            "SELECT[Id],[Nome],[Latitude],[Longitude]FROM[dbo].[dispositivo]WHERE[Id]=@Id";
                        comando.Parameters.AddWithValue("Id", Id);
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                dispositivo = new Dispositivo();
                                dispositivo.Id = Guid.Parse(reader["Id"].ToString());
                                dispositivo.Nome = reader["Nome"].ToString();
                                dispositivo.Latitude = reader["Latitude"].ToString();
                                dispositivo.Longitude = reader["Longitude"].ToString();
                                sqlTransaction.Commit();
                                return dispositivo;
                            }
                            else
                                return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sqlTransaction.Rollback();
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
