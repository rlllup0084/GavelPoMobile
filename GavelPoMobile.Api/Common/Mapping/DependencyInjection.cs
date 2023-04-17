using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace GavelPoMobile.Api.Common.Mapping; 
public static class DependencyInjection {
    public static IServiceCollection AddMappings(this IServiceCollection services) {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.TryAddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}
