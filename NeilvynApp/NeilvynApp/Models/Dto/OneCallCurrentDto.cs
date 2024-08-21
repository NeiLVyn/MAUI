using Google.Protobuf.WellKnownTypes;
using NeilvynApp.Core.EnumExtensions;
using NeilvynApp.Core.Helpers;
using NeilvynApp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NeilvynApp.Models.Dto
{
    public class OneCallCurrentDto
    {
        [JsonPropertyName("sunrise")]
        public string Sunrise { get; set; }

        [JsonPropertyName("sunset")]
        public string Sunset { get; set; }

        private string _temperature;
        [JsonPropertyName("temp")]
        public string Temp
        {
            get
            {
                if (double.TryParse(_temperature, out double celsius))
                {
                    //double celsius = kelvin - 273.15;
                    return $"{celsius.ToString("F1")}°";
                }

                return "";
            }
            set
            {
                _temperature = value;
            }
        }

        private string _wind_speed;
        [JsonPropertyName("wind_speed")]
        public string Wind_Speed
        {
            get
            {
                if (double.TryParse(_wind_speed, out double wind_mph))
                {
                    double wind_kph = wind_mph * 3.6;
                    return $"Speed: {wind_kph.ToString("F2")} km/h";
                }

                return "";
            }
            set
            {
                _wind_speed = value;
            }
        }

        private string _wind_deg;
        [JsonPropertyName("wind_deg")]
        public string Wind_Deg
        {
            get
            {
                if (double.TryParse(_wind_deg, out double wind_angle))
                {
                    int angle = Convert.ToInt32(wind_angle);
                    Directions direction = wind_angle.ToDirection();
                    return $"Direction: {angle}° {direction}";
                }

                return "";
            }
            set
            {
                _wind_deg = value;
            }
        }

        private string _uvi;
        [JsonPropertyName("uvi")]
        public string uvi 
        {
            get
            {
                if (!string.IsNullOrEmpty(_uvi))
                {
                    double val = Convert.ToDouble(_uvi);
                    string index = "Heat Index: ";

                    if (val < 3)
                        return  $"{index}{UVIndex.Low.GetDescription()}";
                    else if (val >= 3 && val < 6)
                        return $"{index}{UVIndex.Moderate.GetDescription()}";
                    else if (val >= 6 && val < 8)
                        return $"{index}{UVIndex.High.GetDescription()}";
                    else if (val >= 8 && val < 11)
                        return $"{index}{UVIndex.VeryHigh.GetDescription()}";
                    else if (val >= 11)
                        return $"{index}{UVIndex.Extreme.GetDescription()}";
                    else return "";
                }
                
                return "";
            }
            set
            {
                _uvi = value;
            }
        }

        private string _humidity;
        [JsonPropertyName("humidity")]
        public string Humidity
        {
            get
            {
                if (!string.IsNullOrEmpty(_humidity))
                {
                    return $"{_humidity}%";
                }

                return "";
            }
            set
            {
                _humidity = value;
            }
        }

        [JsonPropertyName("weather")]
        public List<OneCallCurrentWeatherDto> Weather { get; set; }
    }
}
