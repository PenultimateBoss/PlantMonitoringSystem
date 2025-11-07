var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.PlantMonitoringSystem_BlazorWeb>("blazor-web").WithExternalHttpEndpoints();

builder.Build().Run();