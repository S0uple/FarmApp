using Data.Interfaces;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Configurations;

public static class DataConfiguration
{
    public static void RegisterDataServices(this IServiceCollection services)
    {
        services.AddScoped<IAnimalRepository, AnimalRepository>();

        services.AddDbContext<FarmDbContext>(options => options.UseInMemoryDatabase("FarmDb"));
    }
}
