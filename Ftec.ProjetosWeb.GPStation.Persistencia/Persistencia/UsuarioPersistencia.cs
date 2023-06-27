using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using Ftec.ProjetosWeb.GPStation.Dominio.Interfaces;
using System.Data.SqlClient;
using System.Reflection;


namespace Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia
{
	public class UsuarioPersistencia : IUsuarioPersistencia
	{
		List<Usuario> usuarios = null;
		Usuario usuario = null;
		private SqlTransaction transacao;

		private string stringconexao = "Server = ACER_B\\TEW_SQLEXPRESS; Database = gpsstation; User Id = user; Password = 1234;";
		//"Server = sdb; Database = teste_bruno; User Id = sa; Password = 217799;";

		public List<Usuario> Consultar(string nome)
		{
			var con = new SqlConnection(stringconexao);

			con.Open();
			try
			{
				using (con)
				{
					using (var comando = new SqlCommand())
					{
						comando.Connection = con;
						comando.CommandText =
							"SELECT[Nome],[Senha],[Id]FROM[dbo].[usuario]WHERE[Nome]=@nome ORDER BY [Nome]";
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



		public bool Editar(Usuario usuario)
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
						comando.CommandText = "UPDATE[dbo].[usuario]SET[Nome]=@nome,[Senha]=@senha WHERE[Id]=@Id;";
						comando.Parameters.AddWithValue("nome", usuario.Nome);
						comando.Parameters.AddWithValue("senha", usuario.Senha);
						comando.Parameters.AddWithValue("Id", usuario.Id);
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



		public bool Excluir(Guid id)
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
						comando.CommandText = "DELETE FROM[dbo].[usuario]WHERE[Id]=@Id;";
						comando.Parameters.AddWithValue("Id", id.ToString());
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




		public bool Inserir(Usuario usuario)
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
						comando.CommandText = "INSERT INTO[dbo].[usuario]([Nome],[Senha],[Id])VALUES(@nome,@senha,@Id);";
						comando.Parameters.AddWithValue("nome", usuario.Nome);
						comando.Parameters.AddWithValue("senha", usuario.Senha);
						comando.Parameters.AddWithValue("Id", usuario.Id);
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



		public List<Usuario> Listar()
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




		public bool Login(string usuario, string senha)
		{
			var con = new SqlConnection(stringconexao);

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
			var con = new SqlConnection(stringconexao);

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
