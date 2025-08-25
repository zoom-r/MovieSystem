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

    public async Task<MovieDto?> GetByIdAsync(Guid id)
    {
        var movie = await _movieRepository.GetByIdAsync(id);
        return _mapper.Map<MovieDto>(movie);
    }

    public async Task<IEnumerable<MovieDto>> GetAllAsync()
    {
        var movies = await _movieRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MovieDto>>(movies);
    }

    public async Task<IEnumerable<MovieDto>> GetByDirectorIdAsync(Guid directorId)
    {
        var movies = await _movieRepository.GetByDirectorIdAsync(directorId);
        return _mapper.Map<IEnumerable<MovieDto>>(movies);
    }

    public async Task<IEnumerable<MovieDto>> GetByUserIdWithRatingsAsync(Guid userId)
    {
        var movies = await _movieRepository.GetByUserIdWithRatingsAsync(userId);
        return _mapper.Map<IEnumerable<MovieDto>>(movies);
    }

    public async Task<IEnumerable<MovieDto>> GetTopRatedAsync(int count)
    {
        var movies = await _movieRepository.GetTopRatedAsync(count);
        return _mapper.Map<IEnumerable<MovieDto>>(movies);
    }

    public async Task AddAsync(MovieDto dto)
    {
        var movie = _mapper.Map<Movie>(dto);
        await _movieRepository.AddAsync(movie);
    }

    public async Task UpdateAsync(MovieDto dto)
    {
        var movie = _mapper.Map<Movie>(dto);
        await _movieRepository.UpdateAsync(movie);
    }

    public async Task DeleteAsync(Guid id) =>
        await _movieRepository.DeleteAsync(id);
}