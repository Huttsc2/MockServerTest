using Newtonsoft.Json;

namespace ApiTesting.Objects
{
    public class Reviewer
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("registration_date")]
        public Date RegistrationDate { get; set; }
    }
}
