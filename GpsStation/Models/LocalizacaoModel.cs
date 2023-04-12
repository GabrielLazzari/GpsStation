namespace GpsStation.Models
{
    public class LocalizacaoModel
    {
        public double Latitude { get; set; }
        public double Longitude { get; set;}
        public DateTime DataHora { get; set;}
        public Guid IdDispositivo { get; set;}

    }
}
