namespace GpsStation.Models
{
    public class LoginModel
    {
        public LoginModel()
        {
            Nome = String.Empty;
            Senha = String.Empty;
        }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
