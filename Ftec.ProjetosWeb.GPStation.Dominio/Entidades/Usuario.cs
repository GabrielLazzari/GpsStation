namespace Ftec.ProjetosWeb.GPStation.Dominio.Entidades
{
    public class Usuario
    {
		public Usuario()
		{
			Id = Guid.NewGuid();
			Administrador = false;
			Nome = string.Empty;
			Senha = string.Empty;
		}
		public Guid Id { get; set; }
		public Boolean Administrador { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
