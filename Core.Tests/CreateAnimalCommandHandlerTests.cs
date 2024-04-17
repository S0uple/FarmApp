using Core.Handlers;
using Core.Models;
using Data.Interfaces;
using Data.Models;
using FluentValidation;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Core.Tests
{
    public class CreateAnimalCommandHandlerTests
    {
        [Fact]
        public async Task GivenValidModel_WhenCreateAnimal_ThenCreated()
        {
            // Arrange
            var logger = Substitute.For<ILogger<CreateAnimalCommandHandler>>();
            var validator = Substitute.For<IValidator<CreateAnimalCommand>>();
            var animalRepository = Substitute.For<IAnimalRepository>();

            var handler = new CreateAnimalCommandHandler(logger, validator, animalRepository);

            var animalName = "TestAnimal";
            var createAnimalCommand = new CreateAnimalCommand { Name = animalName };

            // Act
            await handler.Handle(createAnimalCommand, CancellationToken.None);

            // Assert
            await animalRepository.Received(1).CreateAnimal(Arg.Is<Animal>(x => x.Name == animalName), Arg.Any<CancellationToken>());
        }
    }
}