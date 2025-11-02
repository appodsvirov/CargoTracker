using CargoTracker.Web.Domain.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        return services;
    }
}
