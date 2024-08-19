using System;
using System.Text.Json.Serialization;

namespace NeilvynApp.Models.Dto
{
    public class OneCallDto
    {
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("current")]
        public OneCallCurrentDto Current { get; set; }
    }
}
