using System.Text.Json.Serialization;

namespace ApiTesting.Expectations
{
    public class HttpResponse
    {
        [JsonPropertyName("budy")]
        public string Budy { get; set; }
    }
}
