using Microsoft.EntityFrameworkCore;
using MovieSystem.Domain.Entities;
using MovieSystem.Domain.Interfaces;
using MovieSystem.Infrastructure.Data;

namespace MovieSystem.Infrastructure.Repositories;

public class DirectorRepository : IDirectorRepository
{
    private readonly AppDbContext _context;

    public DirectorRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Director?> GetByIdAsync(Guid id) =>
        await _context.Directors
            .Include(d => d.Movies)
            .ThenInclude(m => m.Ratings)
            .FirstOrDefaultAsync(d => d.DirectorId == id);

    public async Task<IEnumerable<Director>> GetAllAsync() =>
        await _context.Directors.Include(d => d.Movies).ToListAsync();

    public async Task<IEnumerable<Movie>> GetMoviesWithAverageRatingAsync(Guid directorId) =>
        await _context.Movies
            .Where(m => m.DirectorId == directorId)
            .Include(m => m.Ratings)
            .ToListAsync();

    public async Task AddAsync(Director director)
    {
        await _context.Directors.AddAsync(director);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Director director)
    {
        _context.Directors.Update(director);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.Directors.FindAsync(id);
        if (entity != null)
        {
            _context.Directors.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}