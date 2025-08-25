using Microsoft.EntityFrameworkCore;
using MovieSystem.Domain.Entities;
using MovieSystem.Domain.Interfaces;
using MovieSystem.Infrastructure.Data;

namespace MovieSystem.Infrastructure.Repositories;

public class RatingRepository : IRatingRepository
{
    private readonly AppDbContext _context;

    public RatingRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Rating?> GetByIdAsync(Guid id) =>
        await _context.Ratings
            .Include(r => r.User)
            .Include(r => r.Movie)
            .FirstOrDefaultAsync(r => r.RatingId == id);

    public async Task<IEnumerable<Rating>> GetAllAsync() =>
        await _context.Ratings.Include(r => r.User).Include(r => r.Movie).ToListAsync();

    public async Task<IEnumerable<Rating>> GetByMovieIdAsync(Guid movieId) =>
        await _context.Ratings
            .Where(r => r.MovieId == movieId)
            .Include(r => r.User)
            .ToListAsync();

    public async Task<IEnumerable<Rating>> GetByUserIdAsync(Guid userId) =>
        await _context.Ratings
            .Where(r => r.UserId == userId)
            .Include(r => r.Movie)
            .ToListAsync();

    public async Task AddAsync(Rating rating)
    {
        await _context.Ratings.AddAsync(rating);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Rating rating)
    {
        _context.Ratings.Update(rating);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Ratings.FindAsync(id);
        if (entity != null)
        {
            _context.Ratings.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}