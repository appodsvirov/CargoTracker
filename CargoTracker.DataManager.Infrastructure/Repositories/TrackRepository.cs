using CargoTracker.DataManager.Domain.Abstractions;
using CargoTracker.DataManager.Domain.Entities;
using CargoTracker.DataManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CargoTracker.DataManager.Infrastructure.Repositories;

public class TrackRepository(CargoTrackerDbContext db) : ITrackRepository
{
    public async Task<Track?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await db.Tracks.FirstOrDefaultAsync(t => t.Id == id, ct);

    public async Task<IReadOnlyList<Track>> GetAllAsync(CancellationToken ct = default)
        => await db.Tracks.OrderByDescending(t => t.Timestamp).ToListAsync(ct);

    public async Task<Track> AddAsync(Track track, CancellationToken ct = default)
    {
        if (track.Id == Guid.Empty) track.Id = Guid.NewGuid();
        db.Tracks.Add(track);
        await db.SaveChangesAsync(ct);
        return track;
    }

    public async Task UpdateAsync(Track track, CancellationToken ct = default)
    {
        db.Tracks.Update(track);
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await db.Tracks.FirstOrDefaultAsync(t => t.Id == id, ct);
        if (entity is null) return;
        db.Tracks.Remove(entity);
        await db.SaveChangesAsync(ct);
    }
}
