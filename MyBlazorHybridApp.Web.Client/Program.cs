using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBlazorHybridApp.Shared.Services;
using MyBlazorHybridApp.Web.Client.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the MyBlazorHybridApp.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddScoped<OrderState>();
builder.Services.AddHttpClient("BackendApi", client =>
{
    // Pastikan ini adalah alamat HTTPS dari proyek backend API Anda
    client.BaseAddress = new Uri("https://localhost:7226");
});

await builder.Build().RunAsync();

