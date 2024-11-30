using AddressStandartization.Api.Settings;
using Dadata;
using Microsoft.Extensions.Options;

namespace AddressStandartization.Api.Configuration;

public static class CleanClientConfiguration
{
    public static IServiceCollection AddCleanClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DaDataApiSettings>(configuration.GetSection("DaDataApiSettings"));
        
        services.AddHttpClient<ICleanClientAsync, CleanClientAsync>((client, sp) =>
        {
            var settings = sp.GetRequiredService<IOptions<DaDataApiSettings>>().Value;

            return new CleanClientAsync(token: settings.Key, secret: settings.Secret, client: client);
        });
        return services;
    }
}