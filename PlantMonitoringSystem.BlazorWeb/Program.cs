using Radzen;
using Blazorise;
using Blazorise.Tailwind;
using Blazorise.Icons.FontAwesome;
using PlantMonitoringSystem.BlazorWeb.Components;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddBlazorise().AddTailwindProviders().AddFontAwesomeIcons();
builder.Services.AddRadzenComponents();

WebApplication app = builder.Build();
if(app.Environment.IsDevelopment() is false)
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();
app.Run();