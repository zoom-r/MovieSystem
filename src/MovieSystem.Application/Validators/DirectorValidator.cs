using FluentValidation;
using MovieSystem.Application.DTOs;

namespace MovieSystem.Application.Validators;

public class DirectorValidator : AbstractValidator<DirectorDto>
{
    public DirectorValidator()
    {
        RuleFor(x => x.DirectorId)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Director name is required")
            .MaximumLength(100);

        RuleFor(x => x.BirthDate)
            .LessThan(DateTime.Now).WithMessage("Birth date must be in the past");

        RuleFor(x => x.Nationality)
            .NotEmpty().WithMessage("Nationality is required")
            .MaximumLength(50);
    }
}