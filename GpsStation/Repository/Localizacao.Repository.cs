using GpsStation.Factory;
using GpsStation.Models;

namespace GpsStation.Repository
{
	public class LocalizacaoRepository
	{
		public LocalizacaoRepository()
		{ }

		public List<LocalizacaoModel> ListarLocalizacao()
		{
			List<LocalizacaoModel> localizacoes = new List<LocalizacaoModel>();
			localizacoes = LocalizacaoFactory.GeradorMoqLocalizacoes(5);
			return localizacoes;
		}
	}
}
