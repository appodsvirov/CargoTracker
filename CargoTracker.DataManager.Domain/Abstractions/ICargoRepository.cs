using CargoTracker.DataManager.Domain.Entities;

namespace CargoTracker.DataManager.Domain.Abstractions;

public interface ICargoRepository
{
    Task<Cargo?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<Cargo>> GetAllAsync(CancellationToken ct = default);
    Task<Cargo> AddAsync(Cargo cargo, CancellationToken ct = default);
    Task UpdateAsync(Cargo cargo, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
