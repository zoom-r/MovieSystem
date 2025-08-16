using System;
using System.Collections.Generic;

namespace MovieSystem.Infrastructure.Models;

public partial class Movie
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public DateOnly ReleaseDate { get; set; }

    public Guid DirectorId { get; set; }

    public virtual Director Director { get; set; } = null!;

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
