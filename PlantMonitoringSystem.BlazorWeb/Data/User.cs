using System.ComponentModel.DataAnnotations;

namespace PlantMonitoringSystem.BlazorWeb.Data;

public class User
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; } = "User";

    public ICollection<Plant> Plants { get; set; } = [];
}