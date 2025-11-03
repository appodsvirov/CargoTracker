namespace CargoTracker.DataManager.Domain.Entities;

public class TrackEntity
{
    public Guid Id { get; set; }
    public Guid CargoId { get; set; }
    public DateTimeOffset Timestamp { get; set; } // ???? ? ?????
    public string Location { get; set; } = string.Empty; // ??????????????
}
