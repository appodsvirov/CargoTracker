namespace CargoTracker.DataManager.Domain.Entities;

public class TrackEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset Timestamp { get; set; } // дата и время
    public string Location { get; set; } = string.Empty; // местоположение

    // Reverse navigation (optional): list of cargos using this track
    public ICollection<CargoEntity> Cargos { get; set; } = new List<CargoEntity>();
}
