namespace CargoTracker.Web.Domain.Abstractions;

using CargoTracker.Web.Domain.Models;

public interface IDataManagerApiClient
{
    // Cargos
    Task<IReadOnlyList<Cargo>> GetCargosAsync(CancellationToken ct = default);
    Task<Cargo?> GetCargoAsync(Guid id, CancellationToken ct = default);
    Task<Cargo> CreateCargoAsync(Cargo cargo, CancellationToken ct = default);
    Task UpdateCargoAsync(Guid id, Cargo cargo, CancellationToken ct = default);
    Task DeleteCargoAsync(Guid id, CancellationToken ct = default);

    // Tracks
    Task<IReadOnlyList<Track>> GetTracksAsync(CancellationToken ct = default);
    Task<Track?> GetTrackAsync(Guid id, CancellationToken ct = default);
    Task<Track> CreateTrackAsync(Track track, CancellationToken ct = default);
    Task UpdateTrackAsync(Guid id, Track track, CancellationToken ct = default);
    Task DeleteTrackAsync(Guid id, CancellationToken ct = default);
}
