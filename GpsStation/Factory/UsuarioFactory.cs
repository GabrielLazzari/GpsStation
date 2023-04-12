using GpsStation.Models;

namespace GpsStation.Factory
{
    public class UsuarioFactory
    {
        public static List<UsuarioModel> GeradorMoqUsuarios(int numeroObjetos)
        {
            List<UsuarioModel> usuarios = new List<UsuarioModel>();
            for (int i = 0; i < numeroObjetos; i++)
            {
                usuarios.Add(new UsuarioModel()
                {
                    Administrador = true,
                    Nome = "",//string.Empty,
                    Senha = "",//string.Empty,
                    Id_usuario = Guid.NewGuid()
                }); 
            }
            return usuarios;
        }
    }
}
