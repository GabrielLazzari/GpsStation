namespace GpsStation.Models
{
    public class Dispositivo
    {
        public Dispositivo()
        {
            Id = new Guid();
            IdUsuario = new Guid();
            Nome = string.Empty;
            Ativo = false;
            Localizacao = string.Empty;
        }

        Guid Id { get; set; }

        Guid IdUsuario { get; set; }
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
