using MovieSystem.Domain.Entities;

namespace MovieSystem.Domain.Interfaces;

public interface IMovieRepository
{
    Task<Movie?> GetByIdAsync(Guid id);
    Task<IEnumerable<Movie>> GetAllAsync();
    Task<IEnumerable<Movie>> GetByDirectorIdAsync(Guid directorId);
    Task<IEnumerable<Movie>> GetByUserIdWithRatingsAsync(Guid userId);
    Task<IEnumerable<Movie>> GetTopRatedAsync(int count);

    Task AddAsync(Movie movie);
    Task UpdateAsync(Movie movie);
    Task DeleteAsync(Guid id);
}