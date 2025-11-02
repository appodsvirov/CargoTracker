using CargoTracker.DataManager.Domain.Abstractions;
using CargoTracker.DataManager.Domain.Entities;
using CargoTracker.DataManager.Infrastructure;
using CargoTracker.DataManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Config
var connectionString = builder.Configuration.GetConnectionString("Postgres")
    ?? Environment.GetEnvironmentVariable("ConnectionStrings__Default")
    ?? "Host=localhost;Port=5432;Database=cargotracker;Username=postgres;Password=postgres";

// Services
builder.Services.AddInfrastructure(connectionString);

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CargoTrackerDbContext>();
    await db.Database.EnsureCreatedAsync();
}

// Minimal API endpoints for CRUD
app.MapGet("/api/cargos", async (ICargoRepository repo, CancellationToken ct) =>
{
    var items = await repo.GetAllAsync(ct);
    return Results.Ok(items);
});

app.MapGet("/api/cargos/{id:guid}", async (Guid id, ICargoRepository repo, CancellationToken ct) =>
{
    var item = await repo.GetByIdAsync(id, ct);
    return item is not null ? Results.Ok(item) : Results.NotFound();
});

app.MapPost("/api/cargos", async (Cargo cargo, ICargoRepository repo, CancellationToken ct) =>
{
    var created = await repo.AddAsync(cargo, ct);
    return Results.Created($"/api/cargos/{created.Id}", created);
});

app.MapPut("/api/cargos/{id:guid}", async (Guid id, Cargo cargo, ICargoRepository repo, CancellationToken ct) =>
{
    if (id != cargo.Id) return Results.BadRequest("Mismatched id");
    await repo.UpdateAsync(cargo, ct);
    return Results.NoContent();
});

app.MapDelete("/api/cargos/{id:guid}", async (Guid id, ICargoRepository repo, CancellationToken ct) =>
{
    await repo.DeleteAsync(id, ct);
    return Results.NoContent();
});

app.MapGet("/api/tracks", async (ITrackRepository repo, CancellationToken ct) => Results.Ok(await repo.GetAllAsync(ct)));
app.MapGet("/api/tracks/{id:guid}", async (Guid id, ITrackRepository repo, CancellationToken ct) =>
{
    var item = await repo.GetByIdAsync(id, ct);
    return item is not null ? Results.Ok(item) : Results.NotFound();
});
app.MapPost("/api/tracks", async (Track track, ITrackRepository repo, CancellationToken ct) =>
{
    var created = await repo.AddAsync(track, ct);
    return Results.Created($"/api/tracks/{created.Id}", created);
});
app.MapPut("/api/tracks/{id:guid}", async (Guid id, Track track, ITrackRepository repo, CancellationToken ct) =>
{
    if (id != track.Id) return Results.BadRequest("Mismatched id");
    await repo.UpdateAsync(track, ct);
    return Results.NoContent();
});
app.MapDelete("/api/tracks/{id:guid}", async (Guid id, ITrackRepository repo, CancellationToken ct) =>
{
    await repo.DeleteAsync(id, ct);
    return Results.NoContent();
});

app.MapGet("/", () => "CargoTracker DataManager is running");

app.Run();
