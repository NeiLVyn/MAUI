using System.Text.Json.Serialization;

namespace NeilvynApp.Models.Dto
{
    public class CurrentAreaDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
