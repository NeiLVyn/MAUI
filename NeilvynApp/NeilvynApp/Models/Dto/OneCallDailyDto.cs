using NeilvynApp.Core.EnumExtensions;
using NeilvynApp.Core.Helpers;
using NeilvynApp.Enums;
using System.Text.Json.Serialization;

namespace NeilvynApp.Models.Dto
{
    public class OneCallDailyDto
    {
        private string? _dt;
        [JsonPropertyName("dt")]
        public string dt
        {
            get
            {
                if (!string.IsNullOrEmpty(_dt))
                {
                    return _dt.ToLocalDateTime().ToString("ddd - MM/dd");
                }

                return DateTime.Now.ToString("ddd - MM/dd");
            }
            set
            {
                _dt = value;
            }
        }

        public DateTime DateItem
        {
            get
            {
                if (!string.IsNullOrEmpty(_dt))
                {
                    return _dt.ToLocalDateTime();
                }

                return DateTime.Now;
            }
        }

        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }

        [JsonPropertyName("moonrise")]
        public string Moonrise { get; set; }

        [JsonPropertyName("moonset")]
        public string Moonset { get; set; }

        private string? _moon_phase;
        [JsonPropertyName("moon_phase")]
        public string Moon_Phase
        {
            get
            {
                if (!string.IsNullOrEmpty(_moon_phase))
                {
                    double val = Convert.ToDouble(_moon_phase);

                    if (val == 0 || val == 1)
                        return $"{MoonPhase.NewMoon.GetDescription()}";
                    else if (val > 0 && val < 0.25)
                        return $"{MoonPhase.WaxingCrescent.GetDescription()}";
                    else if (val == 0.25 )
                        return $"{MoonPhase.FirstQuarter.GetDescription()}";
                    else if (val > 0.25 && val < 0.5)
                        return $"{MoonPhase.WaxingGibbous.GetDescription()}";
                    else if (val == 0.5)
                        return $"{MoonPhase.FullMoon.GetDescription()}";
                    else if (val > 0.5 && val < 0.75)
                        return $"{MoonPhase.WaningGibbous.GetDescription()}";
                    else if (val == 0.75)
                        return $"{MoonPhase.LastQuarter.GetDescription()}";
                    else if (val > 0.75 && val < 1)
                        return $"{MoonPhase.WaningCrescent.GetDescription()}";
                    else return "";
                }

                return "";
            }
            set
            {
                _moon_phase = value;
            }
        }

        [JsonPropertyName("weather")]
        public List<OneCallCurrentWeatherDto> Weather { get; set; }

        private OneCallCurrentWeatherDto? _dailyWeatherFirstItem;
        public OneCallCurrentWeatherDto? DailyWeatherFirstItem
        {
            get
            {
                _dailyWeatherFirstItem = Weather.FirstOrDefault() ?? null;
                return _dailyWeatherFirstItem;
            }
            set
            {
                _dailyWeatherFirstItem = value;
            }
        }
    }
}
