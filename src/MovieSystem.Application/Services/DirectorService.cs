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
    
    public DirectorDto Get(Guid id) =>
        _mapper.Map<DirectorDto>(_directorRepository.GetByIdAsync(id).Result);
    
    public IEnumerable<DirectorDto> GetAll() =>
        _mapper.Map<IEnumerable<DirectorDto>>(_directorRepository.GetAllAsync().Result);
    
    public IEnumerable<MovieDto> GetMoviesWithAverageRating(Guid directorId) =>
        _mapper.Map<IEnumerable<MovieDto>>(_directorRepository.GetMoviesWithAverageRatingAsync(directorId).Result);
    
    public void Add(Director director) =>
        _directorRepository.AddAsync(director).Wait();
    
    public void Update(Director director) =>
        _directorRepository.UpdateAsync(director).Wait();
    
    public void Delete(Guid id) =>
        _directorRepository.DeleteAsync(id).Wait();
}