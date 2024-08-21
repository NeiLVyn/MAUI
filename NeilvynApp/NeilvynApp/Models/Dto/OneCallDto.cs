using NeilvynApp.Core.Helpers;
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

        [JsonPropertyName("daily")]
        public List<OneCallDailyDto> Daily { get; set; }

        public OneCallCurrentAstronomyDto CurrentAstronomy
        {
            get
            {
                if (Daily != null)
                {
                    var forcastToday = Daily.FirstOrDefault(x => x.DateItem.Date == DateTime.Now.Date);

                    if (forcastToday != null)
                    {
                        return new OneCallCurrentAstronomyDto
                        {
                            Moonrise = forcastToday.Moonrise,
                            Moonset = forcastToday.Moonset,
                            Moon_Phase = forcastToday.Moon_Phase
                        };
                    }
                }

                return default(OneCallCurrentAstronomyDto);
            }
        }
    }
}
