using Radzen;
using Blazorise;
using Blazorise.Tailwind;
using Blazorise.Icons.FontAwesome;
using Microsoft.EntityFrameworkCore;
using PlantMonitoringSystem.BlazorWeb.Data;
using PlantMonitoringSystem.BlazorWeb.Components;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
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
if(app.Environment.IsDevelopment() is false)
{
    app.UseMigrationsEndPoint();
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.MapControllers();
app.Run();