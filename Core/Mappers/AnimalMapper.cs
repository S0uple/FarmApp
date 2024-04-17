using Core.Models;
using Data.Models;

namespace Core.Mappers;

internal static class AnimalMapper
{
    public static Animal MapFromCreateCommand(CreateAnimalCommand createAnimalCommand)
    {
        return new Animal
        {
            Name = createAnimalCommand.Name
        };
    }

    public static AnimalModel MapToModel(Animal animal)
    {
        return new AnimalModel
        {
            Id = animal.Id,
            Name = animal.Name
        };
    }
}
