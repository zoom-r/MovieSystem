namespace MovieSystem.Application.DTOs;

public class RatingDto
{
    public Guid RatingId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public Guid MovieId { get; set; }
    public int Score { get; set; }
}