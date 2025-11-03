using System.Net.Http.Json;
using AutoMapper;
using CargoTracker.Web.Domain.Abstractions;
using CargoTracker.Web.Domain.Models;
using CargoTracker.Dtos;

namespace CargoTracker.Web.Infrastructure;

public sealed class DataManagerApiClient(HttpClient http, IMapper mapper) : IDataManagerApiClient
{
    private readonly HttpClient _http = http;
    private readonly IMapper _mapper = mapper;

    // Cargos
    public async Task<IReadOnlyList<Cargo>> GetCargosAsync(CancellationToken ct = default)
    {
        var dtos = await _http.GetFromJsonAsync<IReadOnlyList<CargoDto>>("/api/cargos", ct) ?? Array.Empty<CargoDto>();
        return _mapper.Map<IReadOnlyList<Cargo>>(dtos);
    }

    public async Task<Cargo?> GetCargoAsync(Guid id, CancellationToken ct = default)
    {
        var dto = await _http.GetFromJsonAsync<CargoDto>($"/api/cargos/{id}", ct);
        return dto is null ? null : _mapper.Map<Cargo>(dto);
    }

    public async Task<Cargo> CreateCargoAsync(Cargo cargo, CancellationToken ct = default)
    {
        var dto = _mapper.Map<CargoDto>(cargo);
        var resp = await _http.PostAsJsonAsync("/api/cargos", dto, ct);
        resp.EnsureSuccessStatusCode();
        var createdDto = await resp.Content.ReadFromJsonAsync<CargoDto>(cancellationToken: ct);
        return createdDto is null ? throw new InvalidOperationException("Empty response when creating cargo") : _mapper.Map<Cargo>(createdDto);
    }

    public async Task UpdateCargoAsync(Guid id, Cargo cargo, CancellationToken ct = default)
    {
        var dto = _mapper.Map<CargoDto>(cargo);
        var resp = await _http.PutAsJsonAsync($"/api/cargos/{id}", dto, ct);
        resp.EnsureSuccessStatusCode();
    }

    public async Task DeleteCargoAsync(Guid id, CancellationToken ct = default)
    {
        var resp = await _http.DeleteAsync($"/api/cargos/{id}", ct);
        resp.EnsureSuccessStatusCode();
    }

    // Tracks
    public async Task<IReadOnlyList<Track>> GetTracksAsync(CancellationToken ct = default)
    {
        var dtos = await _http.GetFromJsonAsync<IReadOnlyList<TrackDto>>("/api/tracks", ct) ?? Array.Empty<TrackDto>();
        return _mapper.Map<IReadOnlyList<Track>>(dtos);
    }

    public async Task<Track?> GetTrackAsync(Guid id, CancellationToken ct = default)
    {
        var dto = await _http.GetFromJsonAsync<TrackDto>($"/api/tracks/{id}", ct);
        return dto is null ? null : _mapper.Map<Track>(dto);
    }

    public async Task<Track> CreateTrackAsync(Track track, CancellationToken ct = default)
    {
        var dto = _mapper.Map<TrackDto>(track);
        var resp = await _http.PostAsJsonAsync("/api/tracks", dto, ct);
        resp.EnsureSuccessStatusCode();
        var createdDto = await resp.Content.ReadFromJsonAsync<TrackDto>(cancellationToken: ct);
        return createdDto is null ? throw new InvalidOperationException("Empty response when creating track") : _mapper.Map<Track>(createdDto);
    }

    public async Task UpdateTrackAsync(Guid id, Track track, CancellationToken ct = default)
    {
        var dto = _mapper.Map<TrackDto>(track);
        var resp = await _http.PutAsJsonAsync($"/api/tracks/{id}", dto, ct);
        resp.EnsureSuccessStatusCode();
    }

    public async Task DeleteTrackAsync(Guid id, CancellationToken ct = default)
    {
        var resp = await _http.DeleteAsync($"/api/tracks/{id}", ct);
        resp.EnsureSuccessStatusCode();
    }
}
