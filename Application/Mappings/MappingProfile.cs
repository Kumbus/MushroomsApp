using Application.DTOs.LocationDTOs;
using Application.DTOs.MushroomingDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Mushrooming, MushroomingDto>().ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location));

            CreateMap<CreateMushroomingDto, Mushrooming>();
            CreateMap<UpdateMushroomingDto, Mushrooming>();

            CreateMap<Location, LocationDto>();
        }
    }

}
