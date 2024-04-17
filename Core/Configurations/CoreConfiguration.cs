#pragma warning disable CS1591
using Core.Models;
using Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Configurations;

public static class CoreConfiguration
{
    public static void RegisterCoreServices(this IServiceCollection services)
    {
        // TODO: configure MediatR pipeline
        var mediatrConfiguration = new MediatRServiceConfiguration();
        mediatrConfiguration.RegisterServicesFromAssemblyContaining(typeof(CoreConfiguration));

        services.AddMediatR(mediatrConfiguration);

        services.AddScoped<IValidator<CreateAnimalCommand>, CreateAnimalCommandValidator>();
    }
}
