﻿using Ftec.ProjetosWeb.GPStation.Aplicacao.DTO;
using GpsStation.Models;


namespace Ftec.ProjetosWeb.GPStation.Aplicacao.Adapter
{
    public static class DispositivoAdapter
    {
        public static Dispositivo ToDispositivo(DispositivoDTO dispositivoDTO)
        {
            return new Dispositivo
            {
                Id = dispositivoDTO.Id,
                Nome = dispositivoDTO.Nome,
                Latitude = dispositivoDTO.Latitude,
                Longitude = dispositivoDTO.Longitude
            };
        }

        public static DispositivoDTO ToDispositivoDTO(Dispositivo dispositivo)
        {
            return new DispositivoDTO
            {
                Id = dispositivo.Id,
                Nome = dispositivo.Nome,
                Latitude = dispositivo.Latitude,
                Longitude = dispositivo.Longitude
            };
        }
    }
}