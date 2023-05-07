using System.ComponentModel.DataAnnotations;

namespace GpsStation.Models
{
    public class DispositivoModel
    {
        public DispositivoModel()
        {
            Id = Guid.Empty;
            Nome = string.Empty;
            Latitude = string.Empty;
            Longitude = string.Empty;
        }
        public Guid? Id { get; set; }

        [StringLength(50, ErrorMessage = "Nome com no máximo 50 caracteres")]
        public string Nome { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}
