using NeilvynApp.Core.EnumExtensions;

namespace NeilvynApp.Enums
{
    public enum MoonPhase
    {
        [Description("New Moon")]
        NewMoon = 0,                // 0.0 and 1.0: New Moon

        [Description("Waxing Crescent")]
        WaxingCrescent,             // 0.0 < value < 0.25

        [Description("First Quarter")]
        FirstQuarter,               // 0.25: First Quarter

        [Description("Waxing Gibbous")]
        WaxingGibbous,              // 0.25 < value < 0.5

        [Description("Full Moon")]
        FullMoon,                   // 0.5: Full Moon

        [Description("Waning Gibbous")]
        WaningGibbous,              // 0.5 < value < 0.75

        [Description("Last Quarter")]
        LastQuarter,                // 0.75: Last Quarter

        [Description("Waning Crescent")]
        WaningCrescent              // 0.75 < value < 1.0
    }
}
