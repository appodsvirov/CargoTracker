namespace CargoTracker.Dtos;

public sealed class TrackDto
{
    public Guid Id { get; set; }
    public Guid CargoId { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    public string Location { get; set; } = string.Empty;
}
