namespace GpsStation.Models
{
    public class LocalizacaoModel
    {
		public LocalizacaoModel()
		{
			IdDispositivo = Guid.Empty;
			DataHora = null; 
			Latitude = String.Empty;
			Longitude = String.Empty;
		}
		public Guid? IdDispositivo { get; set; }
		public DateTime? DataHora { get; set; } //datetime nullable
		public string Latitude { get; set; }
		public string Longitude { get; set; }
	}
}
