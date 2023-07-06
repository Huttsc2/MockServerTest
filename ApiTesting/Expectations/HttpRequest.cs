using System.Text.Json.Serialization;

namespace ApiTesting.Expectations
{
    public class HttpRequest
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }
    }
}
