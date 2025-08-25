using FluentValidation;
using MovieSystem.Application.DTOs;

namespace MovieSystem.Application.Validators;

public class RatingValidator : AbstractValidator<RatingDto>
{
    public RatingValidator()
    {
        
    }
}