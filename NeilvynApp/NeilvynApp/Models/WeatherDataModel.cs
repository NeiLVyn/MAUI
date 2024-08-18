using NeilvynApp.Enums;

namespace NeilvynApp.Models
{
    class WeatherDataModel
    {
        public WeatherCondition NarrativeWeatherCondition { get; set; }
        public double Temperature { get; set; }
        public double WindSpeed { get; set; }
        public double Pressure { get; set; }
        public string WindDirection { get; set; }
    }
}
