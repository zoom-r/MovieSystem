using Microsoft.EntityFrameworkCore;
using MovieSystem.Domain.Entities;

namespace MovieSystem.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Rating> Ratings => Set<Rating>();
    public DbSet<Director> Directors => Set<Director>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User
        modelBuilder.Entity<User>(e =>
        {
            e.HasKey(u => u.UserId);
            e.Property(u => u.Email).IsRequired();
            e.HasMany(u => u.Ratings).WithOne(r => r.User).HasForeignKey(r => r.UserId);
        });

        // Director
        modelBuilder.Entity<Director>(e =>
        {
            e.HasKey(d => d.DirectorId);
            e.Property(d => d.Name).IsRequired();
            e.HasMany(d => d.Movies).WithOne(m => m.Director).HasForeignKey(m => m.DirectorId);
        });

        // Movie
        modelBuilder.Entity<Movie>(e =>
        {
            e.HasKey(m => m.MovieId);
            e.Property(m => m.Title).IsRequired();
            e.HasMany(m => m.Ratings).WithOne(r => r.Movie).HasForeignKey(r => r.MovieId);
        });

        // Rating
        modelBuilder.Entity<Rating>(e =>
        {
            e.HasKey(r => r.RatingId);
            e.Property(r => r.Score).IsRequired();
        });
    }
}