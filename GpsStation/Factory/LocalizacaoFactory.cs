using GpsStation.Models;

namespace GpsStation.Factory
{
    public class LocalizacaoFactory
    {
        public static List<LocalizacaoModel> GeradorMoqLocalizacoes(int numeroObjetos)
        {
            List<LocalizacaoModel> localizacoes = new List<LocalizacaoModel>();
            for (int i = 0; i < numeroObjetos; i++)
            {
                localizacoes.Add(new LocalizacaoModel()
                {
                    Latitude = String.Empty,
                    Longitude = String.Empty,
                    DataHora = DateTime.Now,
                    IdDispositivo = Guid.NewGuid()
                }) ;
            }
            return localizacoes;
        }
    }
}