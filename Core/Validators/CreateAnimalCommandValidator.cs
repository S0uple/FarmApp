using Core.Models;
using Data.Interfaces;
using FluentValidation;

namespace Core.Validators;

internal class CreateAnimalCommandValidator : AbstractValidator<CreateAnimalCommand>
{
    public CreateAnimalCommandValidator(IAnimalRepository animalRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(1)
            .WithMessage("Name should not be empty");

        RuleFor(x => x.Name)
            .MaximumLength(50)
            .WithMessage("Name should not be longer than 50 characters");

        RuleFor(x => x.Name)
            .MustAsync(animalRepository.CheckIfNameIsUniqueAsync)
            .WithMessage("Name should be unique");
    }
}
