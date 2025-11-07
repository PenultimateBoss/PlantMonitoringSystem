using Radzen;
using Blazorise;
using Blazorise.Tailwind;
using Blazorise.Icons.FontAwesome;
using Microsoft.EntityFrameworkCore;
using PlantMonitoringSystem.BlazorWeb.Data;
using PlantMonitoringSystem.BlazorWeb.Components;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddBlazorise().AddTailwindProviders().AddFontAwesomeIcons();
builder.Services.AddRadzenComponents();
builder.Services.AddControllers();
string connection_string = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string 'DefaultConnection' not found");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connection_string);
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddLogging();

WebApplication app = builder.Build();
app.MapDefaultEndpoints();
if(app.Environment.IsDevelopment() is false)
{
    app.UseMigrationsEndPoint();
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
else
{
    using var scope = app.Services.CreateScope();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.Migrate();
        logger.LogInformation("Database migrations applied.");
    }
    catch(Exception ex)
    {
        logger.LogError(ex, "An error occurred while migrating the database.");
        throw;
    }
}
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.MapControllers();
app.Run();