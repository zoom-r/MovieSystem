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
        CreateMap<MovieDto, Movie>()
            .ForMember(dest => dest.Director, opt => opt.Ignore()); // prevent EF tracking issues
        
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>();
        
        CreateMap<Director, DirectorDto>();
        CreateMap<DirectorDto, Director>();
        
        CreateMap<Rating, RatingDto>()
            .ForMember(dest => dest.UserName, 
                opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"));
        CreateMap<RatingDto, Rating>()
            .ForMember(dest => dest.User, opt => opt.Ignore())   // handled via UserId
            .ForMember(dest => dest.Movie, opt => opt.Ignore()); // handled via MovieId
    }
}