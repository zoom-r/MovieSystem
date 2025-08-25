using MovieSystem.Domain.Entities;

namespace MovieSystem.Domain.Interfaces;

public interface IRatingRepository
{
    Task<Rating?> GetByIdAsync(Guid id);
    Task<IEnumerable<Rating>> GetAllAsync();
    Task<IEnumerable<Rating>> GetByMovieIdAsync(Guid movieId);
    Task<IEnumerable<Rating>> GetByUserIdAsync(Guid userId);

    Task AddAsync(Rating rating);
    Task UpdateAsync(Rating rating);
    Task DeleteAsync(Guid id);
}