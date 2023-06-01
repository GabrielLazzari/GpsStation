namespace Ftec.ProjetosWeb.GPStation.API.Models
{
    public class ErroModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
