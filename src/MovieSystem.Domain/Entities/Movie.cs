namespace MovieSystem.Domain.Entities;

public class Movie
{
    public Guid MovieId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }

    public Guid DirectorId { get; set; }
    public Director Director { get; set; } = null!;

    // Navigation
    public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}