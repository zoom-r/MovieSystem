namespace MovieSystem.Application.DTOs;

public class RatingDto
{
    public Guid RatingId { get; set; }
    public Guid UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public Guid MovieId { get; set; }
    public string MovieName { get; set; } = string.Empty;
    public int Score { get; set; }
}