namespace CargoTracker.DataManager.Domain.Models;

public class Cargo
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public DateTimeOffset DepartureAt { get; set; }
    public DateTimeOffset EstimatedArrivalAt { get; set; }
    public Guid? TrackId { get; set; }
}
