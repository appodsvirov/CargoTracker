using AutoMapper;
using CargoTracker.DataManager.Domain.Abstractions;
using CargoTracker.DataManager.Domain.Entities;
using CargoTracker.DataManager.Domain.Models;
using CargoTracker.DataManager.Infrastructure;
using CargoTracker.DataManager.Infrastructure.Persistence;
using CargoTracker.Dtos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Config
var connectionString = builder.Configuration.GetConnectionString("Postgres")
    ?? Environment.GetEnvironmentVariable("ConnectionStrings__Default")
    ?? "Host=localhost;Port=5432;Database=cargotracker;Username=postgres;Password=postgres";

// Services
builder.Services.AddInfrastructure(connectionString);

// Configure AutoMapper manually
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new CargoTracker.DataManager.Domain.Mapping.MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CargoTrackerDbContext>();
    await db.Database.EnsureCreatedAsync();
}

// Minimal API endpoints for CRUD
app.MapGet("/api/cargos", async (ICargoRepository repo, IMapper mapper, CancellationToken ct) =>
{
    var entities = await repo.GetAllAsync(ct);
    var models = mapper.Map<IReadOnlyList<Cargo>>(entities);
    var dtos = mapper.Map<IReadOnlyList<CargoDto>>(models);
    return Results.Ok(dtos);
});

app.MapGet("/api/cargos/{id:guid}", async (Guid id, ICargoRepository repo, IMapper mapper, CancellationToken ct) =>
{
    var entity = await repo.GetByIdAsync(id, ct);
    if (entity is null) return Results.NotFound();
    var model = mapper.Map<Cargo>(entity);
    var dto = mapper.Map<CargoDto>(model);
    return Results.Ok(dto);
});

app.MapPost("/api/cargos", async (CargoDto dto, ICargoRepository repo, IMapper mapper, CancellationToken ct) =>
{
    var model = mapper.Map<Cargo>(dto);
    var entity = mapper.Map<CargoEntity>(model);
    var created = await repo.AddAsync(entity, ct);
    var createdModel = mapper.Map<Cargo>(created);
    var createdDto = mapper.Map<CargoDto>(createdModel);
    return Results.Created($"/api/cargos/{createdDto.Id}", createdDto);
});

app.MapPut("/api/cargos/{id:guid}", async (Guid id, CargoDto dto, ICargoRepository repo, IMapper mapper, CancellationToken ct) =>
{
    if (id != dto.Id) return Results.BadRequest("Mismatched id");
    var model = mapper.Map<Cargo>(dto);
    var entity = mapper.Map<CargoEntity>(model);
    await repo.UpdateAsync(entity, ct);
    return Results.NoContent();
});

app.MapDelete("/api/cargos/{id:guid}", async (Guid id, ICargoRepository repo, CancellationToken ct) =>
{
    await repo.DeleteAsync(id, ct);
    return Results.NoContent();
});

app.MapGet("/api/tracks", async (ITrackRepository repo, IMapper mapper, CancellationToken ct) =>
{
    var entities = await repo.GetAllAsync(ct);
    var models = mapper.Map<IReadOnlyList<Track>>(entities);
    var dtos = mapper.Map<IReadOnlyList<TrackDto>>(models);
    return Results.Ok(dtos);
});

app.MapGet("/api/tracks/{id:guid}", async (Guid id, ITrackRepository repo, IMapper mapper, CancellationToken ct) =>
{
    var entity = await repo.GetByIdAsync(id, ct);
    if (entity is null) return Results.NotFound();
    var model = mapper.Map<Track>(entity);
    var dto = mapper.Map<TrackDto>(model);
    return Results.Ok(dto);
});

app.MapPost("/api/tracks", async (TrackDto dto, ITrackRepository repo, IMapper mapper, CancellationToken ct) =>
{
    var model = mapper.Map<Track>(dto);
    var entity = mapper.Map<TrackEntity>(model);
    var created = await repo.AddAsync(entity, ct);
    var createdModel = mapper.Map<Track>(created);
    var createdDto = mapper.Map<TrackDto>(createdModel);
    return Results.Created($"/api/tracks/{createdDto.Id}", createdDto);
});

app.MapPut("/api/tracks/{id:guid}", async (Guid id, TrackDto dto, ITrackRepository repo, IMapper mapper, CancellationToken ct) =>
{
    if (id != dto.Id) return Results.BadRequest("Mismatched id");
    var model = mapper.Map<Track>(dto);
    var entity = mapper.Map<TrackEntity>(model);
    await repo.UpdateAsync(entity, ct);
    return Results.NoContent();
});

app.MapDelete("/api/tracks/{id:guid}", async (Guid id, ITrackRepository repo, CancellationToken ct) =>
{
    await repo.DeleteAsync(id, ct);
    return Results.NoContent();
});

app.MapGet("/", () => "CargoTracker DataManager is running");

app.Run();
