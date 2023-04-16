using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Ftec.ProjetosWeb.GPStation.Dominio.Entidades
{
    public class Localizacao
    {
        public Guid IdDispositivo { get; set; }
        public DateTime DataHora { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        public Localizacao()
        {
            IdDispositivo = Guid.NewGuid();
            DataHora = DateTime.Now;
            Latitude = 0;
            Longitude = 0;
        }
    }
}
