using System.ComponentModel.DataAnnotations;

namespace PlantMonitoringSystem.BlazorWeb.Data;

public class SensorRecord
{
    [Key] public Guid Id { get; set; }
    public byte Light { get; set; }
    public byte Moisture { get; set; }
    public byte Temperature { get; set; }
    public byte Humidity { get; set; }
    public int UpdateTime { get; set; }
}