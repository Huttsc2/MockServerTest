using Newtonsoft.Json;

namespace ApiTesting.Objects
{
    public class Date
    {
        [JsonProperty("day")]
        public int? Day { get; set; }

        [JsonProperty("month")]
        public string? Month { get; set; }

        [JsonProperty("year")]
        public int Year { get; set; }
    }
}
