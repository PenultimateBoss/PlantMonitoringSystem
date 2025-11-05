using Microsoft.EntityFrameworkCore;

namespace PlantMonitoringSystem.BlazorWeb.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Plant> Plants { get; set; }
    public DbSet<SensorRecord> SensorRecords { get; set; }
}