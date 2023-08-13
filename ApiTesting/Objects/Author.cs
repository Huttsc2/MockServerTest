using Newtonsoft.Json;

namespace ApiTesting.Objects
{
    public class Author
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("dob")]
        public Date DateOfBirth { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
