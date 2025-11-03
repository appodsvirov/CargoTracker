using CargoTracker.Web.Domain.Models;

namespace CargoTracker.Web.Domain.Abstractions;

public interface ICargoFilterService
{
    IReadOnlyList<Cargo> Filter(IEnumerable<Cargo> items, string? query, CargoFilterOptions options);
}
