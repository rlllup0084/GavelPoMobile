using GavelPoMobile.Application.Common.Interfaces.Authentication;
using GavelPoMobile.Application.Common.Interfaces.Persistence;
using GavelPoMobile.Application.Common.Interfaces.Services;
using GavelPoMobile.Infrastructure.Authentication;
using GavelPoMobile.Infrastructure.Pesistence;
using GavelPoMobile.Infrastructure.Pesistence.Repositories;
using GavelPoMobile.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GavelPoMobile.Infrastructure;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration) {
        services.AddAuth(configuration)
            .AddPersistence(configuration);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        return services;
    }

    public static IServiceCollection AddPersistence(
        this IServiceCollection services, IConfiguration configuration) {

        services.AddDbContext<GavelPoMobileDbContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();

        return services;
    }

    public static IServiceCollection AddAuth(
    this IServiceCollection services,
    ConfigurationManager configuration) {
        var JwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, JwtSettings);

        services.AddSingleton(Options.Create(JwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                options => options.TokenValidationParameters =
                    new TokenValidationParameters {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = JwtSettings.Issuer,
                        ValidAudience = JwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.Secret)),
                    });

        return services;
    }
}
