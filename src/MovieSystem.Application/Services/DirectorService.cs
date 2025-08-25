using AutoMapper;
using MovieSystem.Application.DTOs;
using MovieSystem.Domain.Entities;
using MovieSystem.Domain.Interfaces;

namespace MovieSystem.Application.Services;

public class DirectorService
{
    private readonly IMapper _mapper;
    private readonly IDirectorRepository _directorRepository;

    public DirectorService(IMapper mapper, IDirectorRepository directorRepository)
    {
        _mapper = mapper;
        _directorRepository = directorRepository;
    }

    public async Task<DirectorDto?> GetByIdAsync(Guid id)
    {
        var director = await _directorRepository.GetByIdAsync(id);
        return _mapper.Map<DirectorDto>(director);
    }

    public async Task<IEnumerable<DirectorDto>> GetAllAsync()
    {
        var directors = await _directorRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<DirectorDto>>(directors);
    }

    public async Task<IEnumerable<MovieDto>> GetMoviesWithAverageRatingAsync(Guid directorId)
    {
        var movies = await _directorRepository.GetMoviesWithAverageRatingAsync(directorId);
        return _mapper.Map<IEnumerable<MovieDto>>(movies);
    }

    public async Task AddAsync(DirectorDto dto)
    {
        var director = _mapper.Map<Director>(dto);
        await _directorRepository.AddAsync(director);
    }

    public async Task UpdateAsync(DirectorDto dto)
    {
        var director = _mapper.Map<Director>(dto);
        await _directorRepository.UpdateAsync(director);
    }

    public async Task DeleteAsync(Guid id) =>
        await _directorRepository.DeleteAsync(id);
}