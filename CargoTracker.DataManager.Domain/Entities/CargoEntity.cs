namespace CargoTracker.DataManager.Domain.Entities;

public class CargoEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty; // наименование
    public string From { get; set; } = string.Empty; // откуда
    public string To { get; set; } = string.Empty;   // куда
    public DateTimeOffset DepartureAt { get; set; } // дата и время отправления
    public DateTimeOffset EstimatedArrivalAt { get; set; } // предполагаемая дата прибытия
}
