using MediatR;

namespace Core.Models;

/// <summary>
/// Command for creating an animal
/// </summary>
public class CreateAnimalCommand : IRequest
{
    /// <summary>
    /// Animal name
    /// </summary>
    public string Name { get; set; }
}
