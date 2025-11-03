namespace CargoTracker.Web.Domain.Models;

public sealed class Track
{
    public Guid Id { get; set; }
    public Guid CargoId { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public string Location { get; set; } = string.Empty;
}
