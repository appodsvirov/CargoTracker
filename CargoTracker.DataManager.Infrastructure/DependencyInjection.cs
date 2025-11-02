    using CargoTracker.DataManager.Infrastructure.Persistence;
using CargoTracker.DataManager.Infrastructure.Repositories;
using CargoTracker.DataManager.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CargoTracker.DataManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<CargoTrackerDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<ICargoRepository, CargoRepository>();
        services.AddScoped<ITrackRepository, TrackRepository>();

        return services;
    }
}
