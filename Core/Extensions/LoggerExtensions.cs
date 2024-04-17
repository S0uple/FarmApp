using Microsoft.Extensions.Logging;

namespace Core.Extensions;

internal static class LoggerExtensions
{
    public static void LogAnimalCreated(this ILogger logger, string name)
    {
        logger.LogInformation($"Animal with name \"{name}\" was created");
    }

    public static void LogAnimalDeleted(this ILogger logger, int id)
    {
        logger.LogInformation($"Animal with id \"{id}\" was deleted");
    }
}
