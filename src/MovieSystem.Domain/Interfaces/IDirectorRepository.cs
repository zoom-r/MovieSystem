using MovieSystem.Domain.Entities;

namespace MovieSystem.Domain.Interfaces;

public interface IDirectorRepository
{
    Task<Director?> GetByIdAsync(Guid id);
    Task<IEnumerable<Director>> GetAllAsync();
    Task<IEnumerable<Movie>> GetMoviesWithAverageRatingAsync(Guid directorId);

    Task AddAsync(Director director);
    Task UpdateAsync(Director director);
    Task DeleteAsync(Guid id);
}