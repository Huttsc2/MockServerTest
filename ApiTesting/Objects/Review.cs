using Newtonsoft.Json;

namespace ApiTesting.Objects
{
    public class Review
    {
        [JsonProperty("reviewer")]
        public Reviewer Reviewer { get; set; }

        [JsonProperty("date")]
        public Date Date { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("comment")]
        public string? Comment { get; set; }
    }
}
