using System;
using System.Net.Http.Headers;
using AddressStandartization.Api.Settings;
using AddressStandartization.Services;
using AddressStandartization.Services.Services.Interfaces;
using AddressStandartization.Settings;
using Microsoft.Extensions.Options;

namespace AddressStandartization.Api.Configuration;

public static class CustomCleanClientConfiguration
{
    public static IServiceCollection AddCustomCleanClient(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<IOptions<DaDataApiSettings>>(config.GetSection("DaDataApiSettings"));

        services.AddHttpClient<ICustomCleanClient, CustomCleanClient>((client) =>
        {
            var settings = SettingsLoader.Load<DaDataApiSettings>("DaDataApiSettings");
            
            client.BaseAddress = new Uri("https://cleaner.dadata.ru/api/v1/");
            client.DefaultRequestHeaders.Add("X-Secret", settings.Secret);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", settings.Key);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });

        return services;
    }
}