﻿using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
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
    public class UsuarioPersistencia
    {
        public UsuarioPersistencia() { }

        List<Usuario> usuarios = null;
        Usuario usuario = null;


        //******* LEMBRAR DE SUBSTITUIR PELA STRING QUE JÁ ESTÁ SALVA NO appsettings.json ********

        string stringconexao = "Server = ACER_B\\TEW_SQLEXPRESS; Database = gpsstation; User Id = user; Password = 1234;";
        //"Server = sdb; Database = teste_bruno; User Id = sa; Password = 217799;";


        public Boolean Inserir(Usuario usuario)
        {
            try
            {
                string conexao = stringconexao;

                using (var con = new SqlConnection(conexao))
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
                        return true;
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
                return false;
            }

        }






        public List<Usuario> Listar()
        {
            try
            {
                //*******TESTE DO EXCEPTION FILTER**********
                //throw new System.Exception("teste"); 

                string conexao = stringconexao;

                using (var con = new SqlConnection(conexao))
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
                            return usuarios;
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





        public Boolean Editar(Usuario usuario)
        {
            try
            {
                string conexao = stringconexao;

                using (var con = new SqlConnection(conexao))
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
                        return true;
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
                return false;
            }

        }





        public Boolean Excluir(Guid id)
        {
            try
            {
                string conexao = stringconexao;

                using (var con = new SqlConnection(conexao))
                {

                    con.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = con;
                        comando.CommandText = "DELETE FROM[dbo].[usuario]WHERE[Id]=@Id;";
                        comando.Parameters.AddWithValue("Id", id.ToString());
                        comando.ExecuteNonQuery();
                        return true;
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
                return false;
            }

        }




        public List<Usuario> Consultar(string nome)
        {
            try
            {
                string conexao = stringconexao;

                using (var con = new SqlConnection(conexao))
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
                            return usuarios;
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





        public Boolean Login(string usuario, string senha)
        {
            try
            {
                Usuario login = new Usuario();
                string conexao = stringconexao;

                using (var con = new SqlConnection(conexao))
                {

                    con.Open();
                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = con;
                        comando.CommandText = "SELECT[Nome],[Senha]FROM[dbo].[usuario]WHERE[Nome]='@usuario' AND[Senha]='@senha'";
                        comando.Parameters.AddWithValue("usuario", usuario);
                        comando.Parameters.AddWithValue("senha", senha);
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            return reader.HasRows;
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
                return false;
            }

        }






        public Usuario SelecionarPorId(Guid Id)
        {
            try
            {
                string conexao = stringconexao;

                using (var con = new SqlConnection(conexao))
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


