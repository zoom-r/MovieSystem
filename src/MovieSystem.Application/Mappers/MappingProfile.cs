using AutoMapper;
using MovieSystem.Application.DTOs;
using MovieSystem.Domain.Entities;

namespace MovieSystem.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Movie, MovieDto>()
            .ForMember(dest => dest.DirectorName, opt => opt.MapFrom(src => src.Director.Name));
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        CreateMap<Director, DirectorDto>();
        CreateMap<Rating, RatingDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));
    }
}