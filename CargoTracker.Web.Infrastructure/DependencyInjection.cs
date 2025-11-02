using CargoTracker.Web.Domain.Abstractions;
using CargoTracker.Web.Infrastructure.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CargoTracker.Web.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddWebInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var baseUrl = config["DataManager:BaseUrl"] ?? "http://localhost:8080";

        services.AddHttpClient<IApiClient, ApiClient>(client =>
        {
            client.BaseAddress = new Uri(baseUrl);
        });

        return services;
    }
}
