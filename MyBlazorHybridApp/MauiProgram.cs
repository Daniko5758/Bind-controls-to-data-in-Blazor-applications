using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MyBlazorHybridApp.Services;
using MyBlazorHybridApp.Shared.Services;

namespace MyBlazorHybridApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            string backendUrl;

#if ANDROID
        backendUrl = "https://10.0.2.2:7226"; // untuk Android Emulator
#else
            backendUrl = "https://localhost:7226"; // untuk Windows machine
#endif

            builder.Services.AddSingleton<IFormFactor, FormFactor>();
            builder.Services.AddScoped<OrderState>();
            builder.Services.AddHttpClient("BackendApi", client =>
            {
                client.BaseAddress = new Uri(backendUrl);
            });

            // Blazor WebView (WAJIB)
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif


            return builder.Build();
        }
    }
}
