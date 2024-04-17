namespace Core.Models;

/// <summary>
/// Animal model
/// </summary>
public class AnimalModel
{
    /// <summary>
    /// Animal Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Animal name
    /// </summary>
    public required string Name { get; set; }
}
