using NeilvynApp.Core.Helpers;
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

        private string _icon;
        [JsonPropertyName("icon")]
        public string Icon 
        {
            get
            {
                if (!string.IsNullOrEmpty(_icon))
                {
                    return _icon.ResolveIconResource();
                }

                return "";
            }
            set
            {
                _icon = value;
            }
        }
    }
}
