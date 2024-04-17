using MediatR;

namespace Core.Models;

/// <summary>
/// Query for checking is animal name is unique
/// </summary>
public class CheckAnimalNameQuery : IRequest<bool>
{
    /// <summary>
    /// Animal name
    /// </summary>
    public required string Name { get; set; }
}
