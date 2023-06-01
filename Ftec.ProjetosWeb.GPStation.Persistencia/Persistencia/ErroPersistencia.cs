using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.ProjetosWeb.GPStation.Persistencia.Persistencia
{
    public class ErroPersistencia
    {
        public ErroPersistencia() { }

        public void Inserir(string Mensagem, string Classe, string Metodo, DateTime dateTime)
        {
            string caminho = "C:/Users/Bruno/Documents/GitHub/GpsStation/LogErro.txt";
            using (StreamWriter writer = new StreamWriter(caminho, true))
            {
                writer.Write($"Data/Hora: {dateTime} | ");
                writer.Write($"Mensagem: {Mensagem} | ");
                writer.Write($"Classe: {Classe} | ");
                writer.Write($"Metodo: {Metodo} | ");
                writer.WriteLine($" ");
                writer.WriteLine($" ");
            }
        }
    }
}
