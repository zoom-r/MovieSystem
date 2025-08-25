using AutoMapper;
using MovieSystem.Application.DTOs;
using MovieSystem.Domain.Entities;
using MovieSystem.Domain.Interfaces;

namespace MovieSystem.Application.Services;

public class MovieService
{
    private readonly IMapper _mapper;
    private readonly IMovieRepository _movieRepository;
    
    public MovieService(IMapper mapper, IMovieRepository movieRepository)
    {
        _mapper = mapper;
        _movieRepository = movieRepository;
    }
    
    public MovieDto GetById(Guid id) =>
        _mapper.Map<MovieDto>(_movieRepository.GetByIdAsync(id).Result);
    
    public IEnumerable<MovieDto> GetAll() =>
        _mapper.Map<IEnumerable<MovieDto>>(_movieRepository.GetAllAsync().Result);
    
    public IEnumerable<MovieDto> GetByDirectorId(Guid directorId) =>
        _mapper.Map<IEnumerable<MovieDto>>(_movieRepository.GetByDirectorIdAsync(directorId).Result);
    
    public IEnumerable<MovieDto> GetByUserIdWithRatings(Guid userId) =>
        _mapper.Map<IEnumerable<MovieDto>>(_movieRepository.GetByUserIdWithRatingsAsync(userId).Result);
    
    public IEnumerable<MovieDto> GetTopRated(int count) =>
        _mapper.Map<IEnumerable<MovieDto>>(_movieRepository.GetTopRatedAsync(count).Result);
    
    public void Add(Movie movie) =>
        _movieRepository.AddAsync(movie).Wait();
    
    public void Update(Movie movie) =>
        _movieRepository.UpdateAsync(movie).Wait();
    
    public void Delete(Guid id) =>
        _movieRepository.DeleteAsync(id).Wait();
}