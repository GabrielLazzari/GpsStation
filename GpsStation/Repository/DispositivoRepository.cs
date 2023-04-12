using GpsStation.Factory;
using GpsStation.Models;

namespace GpsStation.Repository
{
	public class DispositivoRepository
	{
		public DispositivoRepository() { }

		public List<DispositivoModel> ListarDispositivo()
		{
			List<DispositivoModel> dispositivos = new List<DispositivoModel>();
			dispositivos = DispositivoFactory.GeradorMoqDispositivos(5);
			return dispositivos;
		}
	}
}
