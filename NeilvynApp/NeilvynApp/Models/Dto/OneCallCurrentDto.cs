using Google.Protobuf.WellKnownTypes;
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
        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }

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

        [JsonPropertyName("uvi")]
        public string uvi { get; set; }

        [JsonPropertyName("weather")]
        public List<OneCallCurrentWeatherDto> Weather { get; set; }
    }
}
