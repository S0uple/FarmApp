using Core.Mappers;
using Core.Models;
using Data.Interfaces;
using MediatR;

namespace Core.Handlers;

internal class GetAnimalsQueryHandler(IAnimalRepository animalRepository) : IRequestHandler<GetAnimalsQuery, IEnumerable<AnimalModel>>
{
    public async Task<IEnumerable<AnimalModel>> Handle(GetAnimalsQuery _, CancellationToken cancellationToken)
    {
        var result = await animalRepository.GetAnimals(cancellationToken);
        return result.Select(AnimalMapper.MapToModel).ToList();
    }
}
