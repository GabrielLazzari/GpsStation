namespace Ftec.ProjetosWeb.GPStation.Dominio.Entidades
{
    public class Localizacao
    {
		public Localizacao()
		{
			IdDispositivo = Guid.Empty;
			DataHora = null;
			Latitude = string.Empty;
			Longitude = string.Empty;
		}
		public Guid? IdDispositivo { get; set; }
        public DateTime? DataHora { get; set; } //datetime nullable
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
