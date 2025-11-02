using CargoTracker.DataManager.Domain.Entities;

namespace CargoTracker.DataManager.Domain.Abstractions;

public interface ITrackRepository
{
    Task<Track?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Track>> GetAllAsync(CancellationToken ct = default);
    Task<Track> AddAsync(Track track, CancellationToken ct = default);
    Task UpdateAsync(Track track, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
