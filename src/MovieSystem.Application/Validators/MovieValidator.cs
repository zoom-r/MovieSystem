using FluentValidation;
using MovieSystem.Application.DTOs;

namespace MovieSystem.Application.Validators;

public class MovieValidator : AbstractValidator<MovieDto>
{
    public MovieValidator()
    {
        RuleFor(x => x.MovieId).NotEmpty();
        RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Genre).NotEmpty();
        RuleFor(x => x.ReleaseDate).LessThan(DateTime.Now);
    }
}