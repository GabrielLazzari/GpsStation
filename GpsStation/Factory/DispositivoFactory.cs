using GpsStation.Models;

namespace GpsStation.Factory
{
    public class DispositivoFactory
    {
        public static List<DispositivoModel> GeradorMoqDispositivos(int numeroObjetos)
        {
            List<DispositivoModel> dispositivos = new List<DispositivoModel>();
            for (int i = 0; i < numeroObjetos; i++)
            {
                dispositivos.Add(new DispositivoModel()
                {
                Id_dispositivo = new Guid(),
                IdUsuario = new Guid(),
                Nome = "disp",
                Ativo = false
            });
            }
            return dispositivos;
        }
    }
}
