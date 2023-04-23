namespace GpsStation.Models
{
    public class DispositivoModel
    {
		public DispositivoModel()
		{
			Id = new Guid();
			IdUsuario = new Guid();
			Nome = string.Empty;
			Ativo = false;
			Localizacao = string.Empty;
		}

		public Guid Id { get; set; }
		public Guid IdUsuario { get; set; }
		public string Nome { get; set; }
		public bool Ativo { get; set; }
		public string Localizacao { get; set; }

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
