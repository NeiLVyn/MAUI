using Microsoft.Extensions.Logging;
using NeilvynApp.Core;
using NeilvynApp.Core.Location;
using NeilvynApp.Core.Services;
using NeilvynApp.ViewModels;
using SkiaSharp.Views.Maui.Controls.Hosting;
using System.ComponentModel;

namespace NeilvynApp
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            // nugets
            builder.UseSkiaSharp();
            
            // core
            builder.Services.AddSingleton<INotifyPropertyChanged, PropertyChangeNotifier>();

            // services
            builder.Services.AddSingleton<ILocationService, LocationService>();
            builder.Services.AddSingleton<IApiService, ApiService>();

            // pages
            builder.Services.AddSingleton<IContentViewReloader, TideAndWeatherViewModel>();

            return builder.Build();
        }
    }
}
