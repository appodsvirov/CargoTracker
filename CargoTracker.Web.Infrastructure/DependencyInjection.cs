using AutoMapper;
using CargoTracker.Web.Domain.Abstractions;
using CargoTracker.Web.Domain.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CargoTracker.Web.Domain.Services;

namespace CargoTracker.Web.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddWebInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var baseUrl = configuration["DataManager:BaseUrl"] ??
                      Environment.GetEnvironmentVariable("DATAMANAGER_BASEURL") ??
                      "http://localhost:9080"; 

        services.AddHttpClient<IDataManagerApiClient, DataManagerApiClient>(client =>
        {
            client.BaseAddress = new Uri(baseUrl);
        });

        // AutoMapper for Web (DTO <-> Model mapping used by ApiClient)
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile(new WebMappingProfile());
        });

        // Domain services
        services.AddSingleton<ICargoFilterService, CargoFilterService>();
        services.AddSingleton<ITrackFilterService, TrackFilterService>();

        return services;
    }
}
