using CargoTracker.DataManager.Domain.Entities;

namespace CargoTracker.DataManager.Domain.Abstractions;

public interface ICargoRepository
{
    Task<CargoEntity?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<IReadOnlyList<CargoEntity>> GetAllAsync(CancellationToken ct = default);
    Task<CargoEntity> AddAsync(CargoEntity cargo, CancellationToken ct = default);
    Task UpdateAsync(CargoEntity cargo, CancellationToken ct = default);
    Task DeleteAsync(Guid id, CancellationToken ct = default);
}
