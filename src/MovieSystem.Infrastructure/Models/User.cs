using System;
using System.Collections.Generic;

namespace MovieSystem.Infrastructure.Models;

public partial class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
