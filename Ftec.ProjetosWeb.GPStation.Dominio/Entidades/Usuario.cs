namespace Ftec.ProjetosWeb.GPStation.Dominio.Entidades
{
	public class Usuario
	{
		public Usuario()
		{
			Id = Guid.Empty;
			Nome = string.Empty;
			Senha = string.Empty;
		}
		public Guid Id { get; set; }
		public string Nome { get; set; }
		public string Senha { get; set; }
	}
}
