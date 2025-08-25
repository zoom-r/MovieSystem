using FluentValidation;
using MovieSystem.Application.DTOs;

namespace MovieSystem.Application.Validators;

public class RatingValidator : AbstractValidator<RatingDto>
{
    public RatingValidator()
    {
        RuleFor(x => x.RatingId).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty().MaximumLength(50);
        RuleFor(x => x.MovieId).NotEmpty();
        RuleFor(x => x.Score).InclusiveBetween(1, 5);
    }
}