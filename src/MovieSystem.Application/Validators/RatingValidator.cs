using FluentValidation;
using MovieSystem.Application.DTOs;

namespace MovieSystem.Application.Validators;

public class RatingValidator : AbstractValidator<RatingDto>
{
    public RatingValidator()
    {
        RuleFor(x => x.RatingId)
            .NotEmpty();

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required");

        RuleFor(x => x.MovieId)
            .NotEmpty().WithMessage("MovieId is required");

        RuleFor(x => x.Score)
            .InclusiveBetween(1, 10).WithMessage("Score must be between 1 and 10");
    }
}