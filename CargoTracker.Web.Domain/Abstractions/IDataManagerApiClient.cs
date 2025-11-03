namespace CargoTracker.Web.Domain.Abstractions;

using CargoTracker.Dtos;

public interface IDataManagerApiClient
{
    // Cargos
    Task<IReadOnlyList<CargoDto>> GetCargosAsync(CancellationToken ct = default);
    Task<CargoDto?> GetCargoAsync(Guid id, CancellationToken ct = default);
    Task<CargoDto> CreateCargoAsync(CargoDto cargo, CancellationToken ct = default);
    Task UpdateCargoAsync(Guid id, CargoDto cargo, CancellationToken ct = default);
    Task DeleteCargoAsync(Guid id, CancellationToken ct = default);

    // Tracks
    Task<IReadOnlyList<TrackDto>> GetTracksAsync(CancellationToken ct = default);
    Task<TrackDto?> GetTrackAsync(Guid id, CancellationToken ct = default);
    Task<TrackDto> CreateTrackAsync(TrackDto track, CancellationToken ct = default);
    Task UpdateTrackAsync(Guid id, TrackDto track, CancellationToken ct = default);
    Task DeleteTrackAsync(Guid id, CancellationToken ct = default);
}
