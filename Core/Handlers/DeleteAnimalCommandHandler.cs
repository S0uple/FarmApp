using Core.Extensions;
using Core.Models;
using Data.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Core.Handlers;

internal class DeleteAnimalCommandHandler(ILogger<DeleteAnimalCommandHandler> logger, IAnimalRepository animalRepository) : IRequestHandler<DeleteAnimalCommand>
{
    public async Task Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
    {
        await animalRepository.DeleteAnimal(request.Id, cancellationToken);

        logger.LogAnimalDeleted(request.Id);
    }
}
