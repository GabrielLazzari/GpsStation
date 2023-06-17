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
    public class UsuarioPersistencia : IUsuarioPersistencia
    {
        List<Usuario> usuarios = null;
        Usuario usuario = null;
        private string stringconexao;
        private readonly IConfiguration conexao;

        public void conectar()
        {
            stringconexao = conexao.GetConnectionString("conexao");
        }


        //******* LEMBRAR DE SUBSTITUIR PELA STRING QUE JÁ ESTÁ SALVA NO appsettings.json ********

        //string stringconexao = "Server = ACER_B\\TEW_SQLEXPRESS; Database = gpsstation; User Id = user; Password = 1234;";
        //"Server = sdb; Database = teste_bruno; User Id = sa; Password = 217799;";

        public List<Usuario> Consultar(string nome)
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
                            "SELECT[Nome],[Senha],[Id]FROM[dbo].[usuario]WHERE[Nome]=@nome ORDER BY [Nome]";//like '%@nome%' nao recupera nenhum registro
                        comando.Parameters.AddWithValue("nome", nome);
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            usuarios = new List<Usuario>();
                            while (reader.Read())
                            {
                                usuarios.Add(new Usuario
                                {
                                    Nome = reader["nome"].ToString(),
                                    Senha = reader["senha"].ToString(),
                                    Id = Guid.Parse(reader["Id"].ToString())
                                });
                            }
                            sqlTransaction.Commit();
                            return usuarios;
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

        public bool Editar(Usuario usuario)
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
                        comando.CommandText = "UPDATE[dbo].[usuario]SET[Nome]=@nome,[Senha]=@senha WHERE[Id]=@Id;";
                        comando.Parameters.AddWithValue("nome", usuario.Nome);
                        comando.Parameters.AddWithValue("senha", usuario.Senha);
                        comando.Parameters.AddWithValue("Id", usuario.Id);
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
                        comando.CommandText = "DELETE FROM[dbo].[usuario]WHERE[Id]=@Id;";
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

        public bool Inserir(Usuario usuario)
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
                        comando.CommandText = "INSERT INTO[dbo].[usuario]([Nome],[Senha],[Id])VALUES(@nome,@senha,@Id);";
                        comando.Parameters.AddWithValue("nome", usuario.Nome);
                        comando.Parameters.AddWithValue("senha", usuario.Senha);
                        comando.Parameters.AddWithValue("Id", usuario.Id);
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

        public List<Usuario> Listar()
        {
            var con = new SqlConnection(stringconexao);
            SqlTransaction sqlTransaction = con.BeginTransaction();
            try
            {
                //*******TESTE DO EXCEPTION FILTER**********
                //throw new System.Exception("teste"); 

                using (con)
                {

                    con.Open();
                    //throw new System.Exception("teste");
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = con;
                        comando.CommandText = "SELECT[Nome],[Senha],[Id]FROM[dbo].[usuario] ORDER BY [Nome]";
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            usuarios = new List<Usuario>();
                            while (reader.Read())
                            {
                                usuarios.Add(new Usuario
                                {
                                    Nome = reader["nome"].ToString(),
                                    Senha = reader["senha"].ToString(),
                                    Id = Guid.Parse(reader["Id"].ToString())
                                });
                            }
                            sqlTransaction.Commit();
                            return usuarios;
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

        public bool Login(string usuario, string senha)
        {
            var con = new SqlConnection(stringconexao);
            SqlTransaction sqlTransaction = con.BeginTransaction();
            try
            {
                Usuario login = new Usuario();
                using (con)
                {

                    con.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = con;
                        comando.CommandText = "SELECT[Nome],[Senha]FROM[dbo].[usuario]WHERE[Nome]='@usuario' AND[Senha]='@senha'";
                        comando.Parameters.AddWithValue("usuario", usuario);
                        comando.Parameters.AddWithValue("senha", senha);
                        comando.ExecuteReader();
                        sqlTransaction.Commit();
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            return reader.HasRows;
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
                return false;
            }

        }

        public Usuario SelecionarPorId(Guid Id)
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
                        comando.CommandText = "SELECT[Nome],[Senha],[Id]FROM[dbo].[usuario]WHERE[Id]=Id";
                        comando.Parameters.AddWithValue("Id", Id);
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                usuario = new Usuario();
                                usuario.Nome = reader["nome"].ToString();
                                usuario.Senha = reader["senha"].ToString();
                                usuario.Id = Guid.Parse(reader["Id"].ToString());
                                sqlTransaction.Commit();
                                return usuario;
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
