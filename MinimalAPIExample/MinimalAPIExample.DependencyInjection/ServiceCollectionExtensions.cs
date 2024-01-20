using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalAPIExample.Domain.Services;
using MinimalAPIExample.Services;

namespace MinimalAPIExample.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMinimalAPIExampleDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureServices(services);
    }

    #region Helper Methods
        

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IGameService>(_ => new GameService(true));
    }
    #endregion Helper Methods
}