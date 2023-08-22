using AutoMapper;
using Quiero_revisar.Data_Entities;
using Quiero_revisar.Models;

namespace Quiero_revisar
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CatalogoEntity, CatalogoViewModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.descripcion));

            CreateMap<CatalogoViewModel, CatalogoEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.descripcion));
        }
    }
}
