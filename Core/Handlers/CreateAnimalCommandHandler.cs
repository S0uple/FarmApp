using Core.Extensions;
using Core.Mappers;
using Core.Models;
using Data.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Handlers;

internal class CreateAnimalCommandHandler(ILogger<CreateAnimalCommandHandler> logger, IValidator<CreateAnimalCommand> validator, IAnimalRepository animalRepository) : IRequestHandler<CreateAnimalCommand>
{
    public async Task Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
    {
        await validator.ValidateAndThrowAsync(request, cancellationToken);

        var animal = AnimalMapper.MapFromCreateCommand(request);
        await animalRepository.CreateAnimal(animal, cancellationToken);

        logger.LogAnimalCreated(request.Name);
    }
}
