using AutoMapper;
using Capacitacion.Modelos;
using Data.Models;

namespace Core.EF.Utils
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Reparticion, Reparticiones>().ForMember(dest => dest.IdReparticion, opts => opts.MapFrom(src => src.IdReparticion))
                    .ForMember(dest => dest.Nombre, opts => opts.MapFrom(src => src.Nombre)).ReverseMap();
        }
    }
}