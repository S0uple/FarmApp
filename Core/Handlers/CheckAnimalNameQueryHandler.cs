using Core.Models;
using Data.Interfaces;
using MediatR;

namespace Core.Handlers;

internal class CheckAnimalNameQueryHandler(IAnimalRepository animalRepository) : IRequestHandler<CheckAnimalNameQuery, bool>
{
    public async Task<bool> Handle(CheckAnimalNameQuery query, CancellationToken cancellationToken)
    {
        return await animalRepository.CheckIfNameIsUniqueAsync(query.Name, cancellationToken);
    }
}
