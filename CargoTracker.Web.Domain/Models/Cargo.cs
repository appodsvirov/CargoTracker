namespace CargoTracker.Web.Domain.Models;

public sealed class Cargo
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string From { get; set; } = string.Empty;
    public string To { get; set; } = string.Empty;
    public DateTimeOffset DepartureAt { get; set; }
    public DateTimeOffset EstimatedArrivalAt { get; set; }
}
