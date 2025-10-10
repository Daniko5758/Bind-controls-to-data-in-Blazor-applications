using MyBlazorHybridApp.Shared.Services;
using MyBlazorHybridApp.Web.Components;
using MyBlazorHybridApp.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSingleton<IFormFactor, FormFactor>();

// ==== KODE YANG DIPERBAIKI ====
// Hapus pendaftaran HttpClient yang lama dan ganti dengan yang ini
builder.Services.AddHttpClient("BackendApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7226");
});
builder.Services.AddScoped<OrderState>(); // Ganti menjadi Scoped untuk Blazor Server
// =============================    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(MyBlazorHybridApp.Shared._Imports).Assembly,
        typeof(MyBlazorHybridApp.Web.Client._Imports).Assembly);

app.Run();