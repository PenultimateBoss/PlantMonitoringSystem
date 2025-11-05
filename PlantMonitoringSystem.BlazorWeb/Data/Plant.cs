using System.ComponentModel.DataAnnotations;

namespace PlantMonitoringSystem.BlazorWeb.Data;

public class Plant
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; } = "Plant";
    public int UpdatePeriod { get; set; } = 1;
    public DateTime LastUpdated { get; set; } = DateTime.Now;
    public ICollection<SensorRecord> Records { get; set; } = [];

    public Guid UserId { get; set; }
    public User? User { get; set; }
}