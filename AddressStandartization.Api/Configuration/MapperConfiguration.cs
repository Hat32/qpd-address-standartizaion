namespace AddressStandartization.Api.Configuration;

public static class MapperConfiguration
{
    public static IServiceCollection AddAppAutoMapper(this IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName is not null);
        services.AddAutoMapper(assemblies);
        return services;
    }
}