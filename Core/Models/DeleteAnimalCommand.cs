using MediatR;

namespace Core.Models;

/// <summary>
/// Command for deleting an animal
/// </summary>
public class DeleteAnimalCommand : IRequest
{
    /// <summary>
    /// Animal Id
    /// </summary>
    public int Id { get; set; }
}
