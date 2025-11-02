namespace CargoTracker.DataManager.Domain.Entities;

public class Track
{
    public Guid Id { get; set; }
    public DateTimeOffset Timestamp { get; set; } // Дата и время
    public string Location { get; set; } = string.Empty; // текущее место

    // Reverse navigation (optional): list of cargos using this track
    public ICollection<Cargo> Cargos { get; set; } = new List<Cargo>();
}
