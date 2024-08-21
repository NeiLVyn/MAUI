using Google.Protobuf.WellKnownTypes;
using NeilvynApp.Core.EnumExtensions;
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
                if (string.IsNullOrEmpty(_temperature))
                {
                    return "";
                }

                if (double.TryParse(_temperature, out double kelvin))
                {
                    double celsius = kelvin - 273.15;
                    return $"{celsius.ToString("F1")}°";
                }

                return "";
            }
            set
            {
                _temperature = value;
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

        [JsonPropertyName("weather")]
        public List<OneCallCurrentWeatherDto> Weather { get; set; }
    }
}
