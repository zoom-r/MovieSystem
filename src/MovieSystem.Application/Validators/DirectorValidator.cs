using FluentValidation;
using MovieSystem.Application.DTOs;

namespace MovieSystem.Application.Validators;

public class DirectorValidator : AbstractValidator<DirectorDto>
{
    public DirectorValidator()
    {
        RuleFor(x => x.DirectorId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.BirthDate).LessThan(DateTime.Now);
        RuleFor(x => x.Nationality).NotEmpty().MaximumLength(100);
    }
}