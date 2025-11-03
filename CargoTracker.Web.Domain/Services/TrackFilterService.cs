using System.Globalization;
using CargoTracker.Web.Domain.Abstractions;
using CargoTracker.Web.Domain.Models;

namespace CargoTracker.Web.Domain.Services;

public sealed class TrackFilterService : ITrackFilterService
{
    public IReadOnlyList<Track> Filter(IEnumerable<Track> items, string? query, TrackFilterOptions options)
    {
        if (string.IsNullOrWhiteSpace(query))
            return items.ToList();

        var q = query.Trim();
        return items.Where(t => Matches(t, q, options)).ToList();
    }

    private static bool Matches(Track t, string q, TrackFilterOptions options)
    {
        var comp = StringComparison.OrdinalIgnoreCase;
        if (options.HasFlag(TrackFilterOptions.Id) && t.Id.ToString().IndexOf(q, comp) >= 0) return true;
        if (options.HasFlag(TrackFilterOptions.Location) && (t.Location?.IndexOf(q, comp) ?? -1) >= 0) return true;
        if (options.HasFlag(TrackFilterOptions.Timestamp))
        {
            var s = t.Timestamp.ToString("u", CultureInfo.InvariantCulture);
            if (s.IndexOf(q, comp) >= 0) return true;
        }
        return false;
    }
}
