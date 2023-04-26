namespace Ftec.ProjetosWeb.GPStation.Dominio.Entidades
{
    public class Localizacao
    {
		public Localizacao()
		{
			IdDispositivo = Guid.NewGuid();
			DataHora = DateTime.Now;
			Latitude = 0;
			Longitude = 0;
		}
		public Guid IdDispositivo { get; set; }
        public DateTime DataHora { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
