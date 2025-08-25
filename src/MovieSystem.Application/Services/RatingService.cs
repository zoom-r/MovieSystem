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
    
    public RatingDto GetById(Guid id) =>
        _mapper.Map<RatingDto>(_ratingRepository.GetByIdAsync(id).Result);
    
    public IEnumerable<RatingDto> GetAll() =>
        _mapper.Map<IEnumerable<RatingDto>>(_ratingRepository.GetAllAsync().Result);
    
    public IEnumerable<RatingDto> GetByMovieId(Guid movieId) =>
        _mapper.Map<IEnumerable<RatingDto>>(_ratingRepository.GetByMovieIdAsync(movieId).Result);
    
    public IEnumerable<RatingDto> GetByUserId(Guid userId) =>
        _mapper.Map<IEnumerable<RatingDto>>(_ratingRepository.GetByUserIdAsync(userId).Result);
    
    public void Add(Rating rating) =>
        _ratingRepository.AddAsync(rating).Wait();
    
    public void Update(Rating rating) =>
        _ratingRepository.UpdateAsync(rating).Wait();
    
    public void Delete(Guid id) =>
        _ratingRepository.DeleteAsync(id).Wait();
}