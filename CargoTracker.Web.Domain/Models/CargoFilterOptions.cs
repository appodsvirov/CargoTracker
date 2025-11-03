namespace CargoTracker.Web.Domain.Models;

[Flags]
public enum CargoFilterOptions
{
    None = 0,
    Name = 1 << 0,
    From = 1 << 1,
    To = 1 << 2,
    DepartureAt = 1 << 3,
    EstimatedArrivalAt = 1 << 4,
    TrackId = 1 << 5,
    All = Name | From | To | DepartureAt | EstimatedArrivalAt | TrackId
}
