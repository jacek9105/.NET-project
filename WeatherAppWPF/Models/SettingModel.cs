using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class SettingModel
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("continent")]
        public string Continent { get; set; }
    }
}
