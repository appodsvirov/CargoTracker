namespace CargoTracker.DataManager.Domain.Entities;

public class Cargo
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty; // Наименование
    public string From { get; set; } = string.Empty; // Откуда
    public string To { get; set; } = string.Empty;   // Куда
    public DateTimeOffset DepartureAt { get; set; } // дата и время отправления
    public DateTimeOffset EstimatedArrivalAt { get; set; } // расчетная дата прибытия

    // FK to Track
    public Guid? TrackId { get; set; }
    public Track? Track { get; set; }
}
