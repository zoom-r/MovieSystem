namespace MovieSystem.Domain.Entities;

public class Director
{
    public Guid DirectorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string Nationality { get; set; } = string.Empty;

    // Navigation
    public ICollection<Movie> Movies { get; set; } = new List<Movie>();
}