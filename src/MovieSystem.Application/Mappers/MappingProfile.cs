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
            .ForMember(dest => dest.Director, opt => opt.Ignore())
            .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate.ToUniversalTime())); // prevent EF tracking issues

        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>()
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.ToUniversalTime()));
        
        CreateMap<Director, DirectorDto>();
        CreateMap<DirectorDto, Director>()
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToUniversalTime()));
        
        CreateMap<Rating, RatingDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
            .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Title));
        CreateMap<RatingDto, Rating>()
            .ForMember(dest => dest.User, opt => opt.Ignore())   // handled via UserId
            .ForMember(dest => dest.Movie, opt => opt.Ignore()); // handled via MovieId
    }
}