using AutoMapper;
using MovieSystem.Application.DTOs;
using MovieSystem.Domain.Entities;
using MovieSystem.Domain.Interfaces;

namespace MovieSystem.Application.Services;

public class RatingService
{
    private readonly IMapper _mapper;
    private readonly IRatingRepository _ratingRepository;

    public RatingService(IMapper mapper, IRatingRepository ratingRepository)
    {
        _mapper = mapper;
        _ratingRepository = ratingRepository;
    }

    public async Task<RatingDto?> GetByIdAsync(Guid id)
    {
        var rating = await _ratingRepository.GetByIdAsync(id);
        return _mapper.Map<RatingDto>(rating);
    }

    public async Task<IEnumerable<RatingDto>> GetAllAsync()
    {
        var ratings = await _ratingRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<RatingDto>>(ratings);
    }

    public async Task<IEnumerable<RatingDto>> GetByMovieIdAsync(Guid movieId)
    {
        var ratings = await _ratingRepository.GetByMovieIdAsync(movieId);
        return _mapper.Map<IEnumerable<RatingDto>>(ratings);
    }

    public async Task<IEnumerable<RatingDto>> GetByUserIdAsync(Guid userId)
    {
        var ratings = await _ratingRepository.GetByUserIdAsync(userId);
        return _mapper.Map<IEnumerable<RatingDto>>(ratings);
    }

    public async Task AddAsync(RatingDto dto)
    {
        var rating = _mapper.Map<Rating>(dto);
        await _ratingRepository.AddAsync(rating);
    }

    public async Task UpdateAsync(RatingDto dto)
    {
        var rating = _mapper.Map<Rating>(dto);
        await _ratingRepository.UpdateAsync(rating);
    }

    public async Task DeleteAsync(Guid id) =>
        await _ratingRepository.DeleteAsync(id);
}