using Microsoft.EntityFrameworkCore;
using MovieSystem.Domain.Entities;
using MovieSystem.Domain.Interfaces;
using MovieSystem.Infrastructure.Data;

namespace MovieSystem.Infrastructure.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly AppDbContext _context;

    public MovieRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Movie?> GetByIdAsync(Guid id) =>
        await _context.Movies
            .Include(m => m.Director)
            .Include(m => m.Ratings)
            .FirstOrDefaultAsync(m => m.MovieId == id);

    public async Task<IEnumerable<Movie>> GetAllAsync() =>
        await _context.Movies.Include(m => m.Director).Include(m => m.Ratings).ToListAsync();

    public async Task<IEnumerable<Movie>> GetByDirectorIdAsync(Guid directorId) =>
        await _context.Movies
            .Where(m => m.DirectorId == directorId)
            .Include(m => m.Ratings)
            .ToListAsync();

    public async Task<IEnumerable<Movie>> GetByUserIdWithRatingsAsync(Guid userId) =>
        await _context.Movies
            .Include(m => m.Ratings)
            .Where(m => m.Ratings.Any(r => r.UserId == userId))
            .ToListAsync();

    public async Task<IEnumerable<Movie>> GetTopRatedAsync(int count) =>
        await _context.Movies
            .Include(m => m.Ratings)
            .OrderByDescending(m => m.Ratings.Any() ? m.Ratings.Average(r => r.Score) : 0)
            .Take(count)
            .ToListAsync();

    public async Task AddAsync(Movie movie)
    {
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Movie movie)
    {
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Movies.FindAsync(id);
        if (entity != null)
        {
            _context.Movies.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}