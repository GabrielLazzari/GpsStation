namespace GpsStation.Models
{
    public class Usuario
    {
        public Usuario()
        {
            Administrador = false;
            Nome = string.Empty;
            Senha = string.Empty;
        }

        public bool Administrador { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
