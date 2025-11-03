using System.Net.Http.Json;
using CargoTracker.Web.Domain.Abstractions;
using CargoTracker.Dtos;

namespace CargoTracker.Web.Infrastructure;

public sealed class DataManagerApiClient(HttpClient http) : IDataManagerApiClient
{
    private readonly HttpClient _http = http;

    // Cargos
    public async Task<IReadOnlyList<CargoDto>> GetCargosAsync(CancellationToken ct = default)
        => await _http.GetFromJsonAsync<IReadOnlyList<CargoDto>>("/api/cargos", ct)
           ?? Array.Empty<CargoDto>();

    public async Task<CargoDto?> GetCargoAsync(Guid id, CancellationToken ct = default)
        => await _http.GetFromJsonAsync<CargoDto>($"/api/cargos/{id}", ct);

    public async Task<CargoDto> CreateCargoAsync(CargoDto cargo, CancellationToken ct = default)
    {
        var resp = await _http.PostAsJsonAsync("/api/cargos", cargo, ct);
        resp.EnsureSuccessStatusCode();
        var created = await resp.Content.ReadFromJsonAsync<CargoDto>(cancellationToken: ct);
        return created ?? throw new InvalidOperationException("Empty response when creating cargo");
    }

    public async Task UpdateCargoAsync(Guid id, CargoDto cargo, CancellationToken ct = default)
    {
        var resp = await _http.PutAsJsonAsync($"/api/cargos/{id}", cargo, ct);
        resp.EnsureSuccessStatusCode();
    }

    public async Task DeleteCargoAsync(Guid id, CancellationToken ct = default)
    {
        var resp = await _http.DeleteAsync($"/api/cargos/{id}", ct);
        resp.EnsureSuccessStatusCode();
    }

    // Tracks
    public async Task<IReadOnlyList<TrackDto>> GetTracksAsync(CancellationToken ct = default)
        => await _http.GetFromJsonAsync<IReadOnlyList<TrackDto>>("/api/tracks", ct)
           ?? Array.Empty<TrackDto>();

    public async Task<TrackDto?> GetTrackAsync(Guid id, CancellationToken ct = default)
        => await _http.GetFromJsonAsync<TrackDto>($"/api/tracks/{id}", ct);

    public async Task<TrackDto> CreateTrackAsync(TrackDto track, CancellationToken ct = default)
    {
        var resp = await _http.PostAsJsonAsync("/api/tracks", track, ct);
        resp.EnsureSuccessStatusCode();
        var created = await resp.Content.ReadFromJsonAsync<TrackDto>(cancellationToken: ct);
        return created ?? throw new InvalidOperationException("Empty response when creating track");
    }

    public async Task UpdateTrackAsync(Guid id, TrackDto track, CancellationToken ct = default)
    {
        var resp = await _http.PutAsJsonAsync($"/api/tracks/{id}", track, ct);
        resp.EnsureSuccessStatusCode();
    }

    public async Task DeleteTrackAsync(Guid id, CancellationToken ct = default)
    {
        var resp = await _http.DeleteAsync($"/api/tracks/{id}", ct);
        resp.EnsureSuccessStatusCode();
    }
}
