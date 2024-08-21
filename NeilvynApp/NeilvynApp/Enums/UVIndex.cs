using NeilvynApp.Core.EnumExtensions;

namespace NeilvynApp.Enums
{
    public enum UVIndex
    {
        [Description("Low")]
        Low,                                    // value < 3

        [Description("Moderate")]
        Moderate,                               // value < 3 && value < 6

        [Description("High")]
        High,                                   // value >= 6 && value < 8

        [Description("Very High")]
        VeryHigh,                               // value >= 8 && value < 11

        [Description("Extreme")]
        Extreme                                 // value >= 11
    }
}
