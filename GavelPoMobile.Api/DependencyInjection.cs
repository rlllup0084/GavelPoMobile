using GavelPoMobile.Api.Common.Errors;
using GavelPoMobile.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GavelPoMobile.Api;
public static class DependencyInjection {
    public static IServiceCollection AddPresentation(this IServiceCollection services) {
        services.AddControllers();

        services.AddSingleton<ProblemDetailsFactory, GavelPoMobileProblemDetailsFactory>();

        services.AddMappings();

        return services;
    }
}