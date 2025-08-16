using System;
using System.Collections.Generic;

namespace MovieSystem.Infrastructure.Models;

public partial class Rating
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public Guid MovieId { get; set; }

    public float Rating1 { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
