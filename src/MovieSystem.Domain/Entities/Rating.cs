namespace MovieSystem.Domain.Entities;

public class Rating
{
    public Guid RatingId { get; set; }
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid MovieId { get; set; }
    public Movie? Movie { get; set; }

    public int Score { get; set; }
}