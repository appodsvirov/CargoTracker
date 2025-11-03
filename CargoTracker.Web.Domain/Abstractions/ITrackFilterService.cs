using CargoTracker.Web.Domain.Models;

namespace CargoTracker.Web.Domain.Abstractions;

public interface ITrackFilterService
{
    IReadOnlyList<Track> Filter(IEnumerable<Track> items, string? query, TrackFilterOptions options);
}
