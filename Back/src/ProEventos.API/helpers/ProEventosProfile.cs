using AutoMapper;
using ProEventos.Application.Dtos;
using ProEventos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.helpers
{
    public class ProEventosProfile: Profile
    {
        public ProEventosProfile()
        {
            CreateMap<Evento, EventoDto>().ReverseMap();
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            CreateMap<Palestrante, PalestranteDto>().ReverseMap();
        }
    }
}
