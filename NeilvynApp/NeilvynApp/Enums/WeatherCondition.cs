using NeilvynApp.Core.EnumExtensions;

namespace NeilvynApp.Enums
{
    public enum WeatherCondition
    {
        [Description("The sky is clear, with no significant clouds.")]
        Clear,

        [Description("Cloudy conditions with varying degrees of cloud cover.")]
        Cloudy,

        [Description("The sky is completely covered with clouds.")]
        Overcast,

        [Description("The sun is shining brightly with no clouds.")]
        Sunny,

        [Description("Light to moderate rain is occurring intermittently.")]
        Showers,

        [Description("Continuous or steady rain.")]
        Rain,

        [Description("Thunderstorms with lightning and possibly heavy rain.")]
        Thunderstorms,

        [Description("Snowfall occurring.")]
        Snow,

        [Description("Light, intermittent snowfall.")]
        Flurries,

        [Description("Mixed precipitation of rain and snow.")]
        Sleet,

        [Description("Rain that freezes on contact with surfaces.")]
        FreezingRain,

        [Description("Strong winds without significant precipitation.")]
        Windy,

        [Description("Reduced visibility due to foggy conditions.")]
        Fog,

        [Description("Reduced visibility due to fine particles or dust in the air.")]
        Haze,

        [Description("Light rain with very small droplets.")]
        Drizzle,

        [Description("Strong winds carrying dust or sand, reducing visibility.")]
        DustStorm
    }

}
