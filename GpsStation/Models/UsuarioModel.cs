using System.ComponentModel.DataAnnotations;

namespace GpsStation.Models
{
    public class UsuarioModel
    {
        public UsuarioModel()
        {
            Id = Guid.Empty;
            Nome = string.Empty;
            Senha = string.Empty;
        }
        public Guid Id { get; set; }

        [StringLength(50, ErrorMessage = "Nome com no máximo 50 caracteres")]
        public string Nome { get; set; }

        [StringLength(8, ErrorMessage = "Senha com no máximo 8 caracteres")]
        public string Senha { get; set; }

    }
}

