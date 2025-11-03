using CargoTracker.DataManager.Domain.Entities;

namespace CargoTracker.DataManager.Domain.Abstractions;

public interface ITrackRepository
{
    Task<TrackEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<TrackEntity>> GetAllAsync(CancellationToken ct = default);
    Task<TrackEntity> AddAsync(TrackEntity track, CancellationToken ct = default);
    Task UpdateAsync(TrackEntity track, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
