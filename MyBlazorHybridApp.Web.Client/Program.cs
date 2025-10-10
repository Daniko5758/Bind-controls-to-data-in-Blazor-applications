using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyBlazorHybridApp.Shared.Services;
using MyBlazorHybridApp.Web.Client.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the MyBlazorHybridApp.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
builder.Services.AddScoped<OrderState>();

await builder.Build().RunAsync();
