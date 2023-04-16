using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Ftec.ProjetosWeb.GPStation.Dominio.Entidades
{
    public class Usuario
    {
        public Boolean Administrador { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public Guid Id_usuario { get; set; }

        public Usuario() { 
        
            Administrador = false;
            Nome = string.Empty;
            Senha = string.Empty;
            Id_usuario = Guid.NewGuid();
        
        }
    }
}
