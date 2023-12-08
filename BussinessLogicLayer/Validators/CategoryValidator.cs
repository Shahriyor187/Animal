using DataAccsesLayer.Entities;
using FluentValidation;

namespace BusnisLogicLayer.Validators;

public class CategoryValidator : AbstractValidator<AnimalCategory>
{
    public CategoryValidator()
    {
        RuleFor (c => c.Name)
            .NotEmpty()
            .WithMessage("Category name cannot be empty")
            .MinimumLength(3)
            .WithMessage("Category name cannot be shorter than 3 characters")
            .MaximumLength(50)
            .WithMessage("Category name cannot be longer than 50 characters");
    }
}
