using System.Globalization;
using CargoTracker.Web.Domain.Abstractions;
using CargoTracker.Web.Domain.Models;

namespace CargoTracker.Web.Domain.Services;

public sealed class CargoFilterService : ICargoFilterService
{
    public IReadOnlyList<Cargo> Filter(IEnumerable<Cargo> items, string? query, CargoFilterOptions options)
    {
        if (string.IsNullOrWhiteSpace(query))
            return items.ToList();

        var q = query.Trim();
        var list = new List<Cargo>();
        foreach (var c in items)
        {
            if (Matches(c, q, options))
                list.Add(c);
        }
        return list;
    }

    private static bool Matches(Cargo c, string q, CargoFilterOptions options)
    {
        var comp = StringComparison.OrdinalIgnoreCase;

        bool Match(string s) => s?.IndexOf(q, comp) >= 0;

        if (options.HasFlag(CargoFilterOptions.Name) && Match(c.Name)) return true;
        if (options.HasFlag(CargoFilterOptions.From) && Match(c.From)) return true;
        if (options.HasFlag(CargoFilterOptions.To) && Match(c.To)) return true;

        if (options.HasFlag(CargoFilterOptions.DepartureAt))
        {
            var s = c.DepartureAt.ToString("u", CultureInfo.InvariantCulture);
            if (s.IndexOf(q, comp) >= 0) return true;
        }
        if (options.HasFlag(CargoFilterOptions.EstimatedArrivalAt))
        {
            var s = c.EstimatedArrivalAt.ToString("u", CultureInfo.InvariantCulture);
            if (s.IndexOf(q, comp) >= 0) return true;
        }
        return false;
    }
}
