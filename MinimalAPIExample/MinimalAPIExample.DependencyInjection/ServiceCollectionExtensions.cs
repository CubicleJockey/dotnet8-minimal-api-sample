using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MinimalAPIExample.Domain.Services;
using MinimalAPIExample.Services;

namespace MinimalAPIExample.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddMinimalApiExampleDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == default) { throw new ArgumentNullException(nameof(services)); }
        if (configuration == default) { throw new ArgumentNullException(nameof(configuration)); }
        
        ConfigureServices(services);
    }

    #region Helper Methods
        

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IGameService>(_ => new GameService(true));
    }
    #endregion Helper Methods
}