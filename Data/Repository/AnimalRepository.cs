using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

internal class AnimalRepository(FarmDbContext dbContext) : IAnimalRepository
{
    public async Task<IEnumerable<Animal>> GetAnimals(CancellationToken ct)
    {
        return await dbContext.Animals.ToListAsync(ct);
    }

    public async Task CreateAnimal(Animal animal, CancellationToken ct)
    {
        dbContext.Animals.Add(animal);
        await dbContext.SaveChangesAsync(ct);
    }

    public async Task DeleteAnimal(int id, CancellationToken ct)
    {
        var animal = await dbContext.Animals.FirstOrDefaultAsync(x => x.Id == id, ct);
        if (animal == null)
        {
            return;
        }
        dbContext.Animals.Remove(animal);
        await dbContext.SaveChangesAsync(ct);
    }

    public async Task<bool> CheckIfNameIsUniqueAsync(string name, CancellationToken ct)
    {
        return !await dbContext.Animals.AnyAsync(x => x.Name == name, ct);
    }
}
