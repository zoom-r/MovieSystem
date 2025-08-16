using System;
using System.Collections.Generic;

namespace MovieSystem.Infrastructure.Models;

public partial class Director
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string Nationality { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
