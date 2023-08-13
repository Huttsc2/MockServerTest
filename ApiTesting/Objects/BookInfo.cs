using Newtonsoft.Json;

namespace ApiTesting.Objects
{
    public class BookInfo
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("author")]
        public Author Author { get; set; }

        [JsonProperty("publishedDate")]
        public Date PublishedDate { get; set; }

        [JsonProperty("genres")]
        public List<string>? Genres { get; set; }

        [JsonProperty("reviews")]
        public List<Review>? Reviews { get; set; }
    }
}
