using AutoMapper;
using ApiPaisesProyecto.Entidades;
using ApiPaisesProyecto.Models;

namespace ApiPaisesProyecto.Servicios
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Distrito, DistritoDto>()
                .ForMember(dest => dest.Antiguedad, opt => opt.MapFrom(src => DateTime.Now.Year - src.FechaFundacion.Year));
            CreateMap<DistritoCreateDto, Distrito>();
            CreateMap<DistritoUpdateDto, Distrito>();

            CreateMap<Apartamento, ApartamentoDto>();
            CreateMap<ApartamentoCreateDto, Apartamento>();
            CreateMap<ApartamentoUpdateDto, Apartamento>();
        }
    }
}
