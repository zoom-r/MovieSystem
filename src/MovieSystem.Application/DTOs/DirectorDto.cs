namespace MovieSystem.Application.DTOs;

public class DirectorDto
{
    public Guid DirectorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string Nationality { get; set; } = string.Empty;
}