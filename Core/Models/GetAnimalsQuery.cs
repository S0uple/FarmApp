using MediatR;

namespace Core.Models;

/// <summary>
/// Query for getting all animals
/// </summary>
public class GetAnimalsQuery : IRequest<IEnumerable<AnimalModel>>
{
}
