using System.Runtime.CompilerServices;
using AddressStandartization.Api.Settings;

namespace AddressStandartization.Api.Configuration;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddAppSwagger(this IServiceCollection services, SwaggerSettings swaggerSettings)
    {
        if (!swaggerSettings.Enabled)
            return services;


        services.AddSwaggerGen();

        return services;
    }
    
    public static void UseAppSwagger(this WebApplication app)
    {
        var swaggerSettings = app.Services.GetService<SwaggerSettings>();

        if (!swaggerSettings?.Enabled ?? false)
            return;

        app.UseSwagger();
        app.UseSwaggerUI();
        

    }
}