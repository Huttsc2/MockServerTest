using System.Text.Json.Serialization;

namespace ApiTesting.Expectations
{
    public class ExpectationBody
    {
        [JsonPropertyName("httpRequest")]
        public HttpRequest HttpRequest { get; set; }

        [JsonPropertyName("httpResponce")]
        public HttpResponse HttpResponse { get; set; }
    }
}
