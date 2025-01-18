using Application.DTOs.LocationDTOs;
using Application.DTOs.MushroomDTOs;
using Application.DTOs.MushroomingDTOs;
using Application.DTOs.SpeciesDTOs;
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

            CreateMap<Mushroom, MushroomDto>().ForMember(dest => dest.Species, opt => opt.MapFrom(src => src.Species));
            CreateMap<CreateMushroomDto, Mushroom>();
            CreateMap<UpdateMushroomDto, Mushroom>();

            CreateMap<Location, LocationDto>();

            CreateMap<Species, SpeciesDto>();
            CreateMap<CreateSpeciesDto, Species>();
            CreateMap<UpdateSpeciesDto, Species>();
        }
    }

}
