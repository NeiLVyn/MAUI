namespace NeilvynApp.Enums
{
    public enum MoonPhase
    {
        NewMoon = 0,                // 0.0 and 1.0: New Moon
        WaxingCrescent,             // 0.0 < value < 0.25
        FirstQuarter,               // 0.25: First Quarter
        WaxingGibbous,              // 0.25 < value < 0.5
        FullMoon,                   // 0.5: Full Moon
        WaningGibbous,              // 0.5 < value < 0.75
        LastQuarter,                // 0.75: Last Quarter
        WaningCrescent              // 0.75 < value < 1.0
    }
}
