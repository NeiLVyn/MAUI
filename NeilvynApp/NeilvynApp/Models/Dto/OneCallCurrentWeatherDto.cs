using System.Text.Json.Serialization;

namespace NeilvynApp.Models
{
    public class OneCallCurrentWeatherDto
    {
        [JsonPropertyName("id")]
        public string WeatherId { get; set; }

        [JsonPropertyName("main")]
        public string Main { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }
    }
}
