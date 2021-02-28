using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TecSoftware.EntidadesDominio;

namespace TecSoftware.Api
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Ruleta, RuletaDto>().ReverseMap();
            CreateMap<Operacion, OperacionDto>().ReverseMap();
            CreateMap<RuletaApuesta, RuletaApuestaDto>().ReverseMap();
            CreateMap<Apuesta, ApuestaDto>().ReverseMap();
        }
    }
}
