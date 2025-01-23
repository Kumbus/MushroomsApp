using Application.DTOs.LocationDTOs;
using Application.DTOs.MushroomDTOs;
using Application.DTOs.MushroomingDTOs;
using Application.DTOs.MushroomingMushroomDTOs;
using Application.DTOs.MushroomingMushroomPhotoDTOs;
using Application.DTOs.SpeciesDTOs;
using Application.DTOs.UserDTOs;
using Application.DTOs.UserReviewDTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Mushrooming, MushroomingDto>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.CollectedMushrooms, opt => opt.MapFrom(src => src.CollectedMushrooms));
            CreateMap<CreateMushroomingDto, Mushrooming>();
            CreateMap<UpdateMushroomingDto, Mushrooming>();

            CreateMap<Mushroom, MushroomDto>().ForMember(dest => dest.Species, opt => opt.MapFrom(src => src.Species));
            CreateMap<CreateMushroomDto, Mushroom>();
            CreateMap<UpdateMushroomDto, Mushroom>();

            CreateMap<Location, LocationDto>();
            CreateMap<CreateLocationDto, Location>();
            CreateMap<UpdateLocationDto, Location>();

            CreateMap<Species, SpeciesDto>();
            CreateMap<CreateSpeciesDto, Species>();
            CreateMap<UpdateSpeciesDto, Species>();

            CreateMap<MushroomingMushroom, MushroomingMushroomDto>()
            .ForMember(dest => dest.Mushroom, opt => opt.MapFrom(src => src.Mushroom))
            .ForMember(dest => dest.CollectedBy, opt => opt.MapFrom(src => src.CollectedBy));
            CreateMap<CreateMushroomingMushroomDto, MushroomingMushroom>();
            CreateMap<UpdateMushroomingMushroomDto, MushroomingMushroom>();

            CreateMap<User, UserDto>();
            CreateMap<UpdateUserDto, User>()
                .ForMember(dest => dest.RefreshToken, opt => opt.Ignore())
                .ForMember(dest => dest.RefreshTokenExpiryTime, opt => opt.Ignore());

            CreateMap<MushroomingMushroomPhoto, MushroomingMushroomPhotoDto>();
            CreateMap<CreateMushroomingMushroomPhotoDto, MushroomingMushroomPhoto>();
            CreateMap<UpdateMushroomingMushroomPhotoDto, MushroomingMushroomPhoto>();

            CreateMap<UserReview, UserReviewDto>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Mushrooming, opt => opt.MapFrom(src => src.Mushrooming));
            CreateMap<CreateUserReviewDto, UserReview>();
            CreateMap<UpdateUserReviewDto, UserReview>();
        }
    }
}
