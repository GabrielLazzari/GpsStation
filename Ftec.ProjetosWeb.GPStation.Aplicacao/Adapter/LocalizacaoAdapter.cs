using Ftec.ProjetosWeb.GPStation.Aplicacao.DTO;
using Ftec.ProjetosWeb.GPStation.Dominio.Entidades;

namespace Ftec.ProjetosWeb.GPStation.Aplicacao.Adapters
{
    public static class LocalizacaoAdapter
    {
        public static Localizacao ToLocalizacao(LocalizacaoDTO localizacaoDTO)
        {
            return new Localizacao
            {
                IdDispositivo = localizacaoDTO.IdDispositivo,
                DataHora = localizacaoDTO.DataHora ?? default(DateTime), // Caso seja nulo, define o valor padrão do DateTime
                Latitude = localizacaoDTO.Latitude,
                Longitude = localizacaoDTO.Longitude
            };
        }

        public static LocalizacaoDTO ToLocalizacaoDTO(Localizacao localizacao)
        {
            return new LocalizacaoDTO
            {
                IdDispositivo = localizacao.IdDispositivo,
                DataHora = localizacao.DataHora,
                Latitude = localizacao.Latitude,
                Longitude = localizacao.Longitude
            };
        }
    }
}
