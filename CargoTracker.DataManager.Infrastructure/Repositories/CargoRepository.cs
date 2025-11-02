using CargoTracker.DataManager.Domain.Abstractions;
using CargoTracker.DataManager.Domain.Entities;
using CargoTracker.DataManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CargoTracker.DataManager.Infrastructure.Repositories;

public class CargoRepository(CargoTrackerDbContext db) : ICargoRepository
{
    public async Task<Cargo?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await db.Cargos.Include(c => c.Track).FirstOrDefaultAsync(c => c.Id == id, ct);

    public async Task<IReadOnlyList<Cargo>> GetAllAsync(CancellationToken ct = default)
        => await db.Cargos.Include(c => c.Track).OrderBy(c => c.DepartureAt).ToListAsync(ct);

    public async Task<Cargo> AddAsync(Cargo cargo, CancellationToken ct = default)
    {
        if (cargo.Id == Guid.Empty) cargo.Id = Guid.NewGuid();
        db.Cargos.Add(cargo);
        await db.SaveChangesAsync(ct);
        return cargo;
    }

    public async Task UpdateAsync(Cargo cargo, CancellationToken ct = default)
    {
        db.Cargos.Update(cargo);
        await db.SaveChangesAsync(ct);
    }

    public async Task DeleteAsync(Guid id, CancellationToken ct = default)
    {
        var entity = await db.Cargos.FirstOrDefaultAsync(c => c.Id == id, ct);
        if (entity is null) return;
        db.Cargos.Remove(entity);
        await db.SaveChangesAsync(ct);
    }
}
