using FluentValidation;
using MovieSystem.Application.DTOs;

namespace MovieSystem.Application.Validators;

public class MovieValidator : AbstractValidator<MovieDto>
{
    public MovieValidator()
    {
        RuleFor(x => x.MovieId)
            .NotEmpty();

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(100).WithMessage("Title must not exceed 100 characters");

        RuleFor(x => x.Genre)
            .NotEmpty().WithMessage("Genre is required");

        RuleFor(x => x.ReleaseDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Release date cannot be in the future");

        RuleFor(x => x.DirectorId)
            .NotEmpty().WithMessage("DirectorId is required");
    }
}