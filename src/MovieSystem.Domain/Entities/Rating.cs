namespace MovieSystem.Domain.Entities;

public class Rating
{
    public Guid RatingId { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid MovieId { get; set; }
    public Movie Movie { get; set; } = null!;

    public int Score { get; set; }
}