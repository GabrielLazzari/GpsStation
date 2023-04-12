namespace GpsStation.Models
{
    public class LoginModel
    {
        public LoginModel()
        {
            username = "bruno";
            password = "123";
        }

        public string username { get; set; }
        public string password { get; set; }
    }
}
