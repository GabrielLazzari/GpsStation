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
                    Latitude = -29.165896+i + 0.000008-i,
                    Longitude = -51.183160+i + 0.000009-i,
                    DataHora = DateTime.Now,
                    IdDispositivo = Guid.NewGuid()
                }) ;
            }
            return localizacoes;
        }
    }
}