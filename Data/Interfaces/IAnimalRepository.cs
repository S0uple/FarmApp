using Data.Models;

namespace Data.Interfaces;

public interface IAnimalRepository
{
    Task<IEnumerable<Animal>> GetAnimals(CancellationToken ct);

    Task CreateAnimal(Animal animal, CancellationToken ct);

    Task DeleteAnimal(int id, CancellationToken ct);

    Task<bool> CheckIfNameIsUniqueAsync(string name, CancellationToken ct);
}
