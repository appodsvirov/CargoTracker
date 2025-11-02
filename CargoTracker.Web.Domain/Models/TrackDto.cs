namespace CargoTracker.Web.Domain.Models;

public sealed class TrackDto
{
    public Guid Id { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public string Location { get; set; } = string.Empty;
}
