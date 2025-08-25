namespace MovieSystem.Application.DTOs;

public class MovieDto
{
    public Guid MovieId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string DirectorName { get; set; } = string.Empty;
}