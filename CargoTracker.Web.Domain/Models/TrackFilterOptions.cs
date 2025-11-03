namespace CargoTracker.Web.Domain.Models;

[Flags]
public enum TrackFilterOptions
{
    None = 0,
    Id = 1 << 0,
    Timestamp = 1 << 1,
    Location = 1 << 2,
    All = Id | Timestamp | Location
}
