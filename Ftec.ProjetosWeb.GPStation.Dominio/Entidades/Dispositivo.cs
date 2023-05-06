namespace GpsStation.Models
{
    public class Dispositivo
    {
        public Dispositivo()
        {
            Id = Guid.Empty;
            Nome = string.Empty;
            Latitude = string.Empty;
            Longitude = string.Empty;
        }

        public Guid? Id { get; set; }
        public string Nome { get; set; }
        public string Latitude { get; set; }
		public string Longitude { get; set; }

		/*
         {
            [pontoz: 10, pontoy: 20],
            [pontoz: 10, pontoy: 20]
         [pontoz: 10, pontoy: 20]
         [pontoz: 10, pontoy: 20]
         [pontoz: 10, pontoy: 20]
         [pontoz: 10, pontoy: 20]
        
        }
         */
	}
}
