using CommunityToolkit.Maui.Maps;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using NeilvynApp.Core;

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

            builder.UseMauiCommunityToolkitMaps(Constants.GoogleMap_Key);

            return builder.Build();
        }
    }
}
