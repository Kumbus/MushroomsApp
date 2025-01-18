using System.Text.Json.Serialization;

namespace Domain.Helpers
{
    namespace Domain.Entities
    {
        public class GoogleUser
        {
            [JsonPropertyName("email")]
            public string Email { get; set; }
            [JsonPropertyName("given_name")]
            public string GivenName { get; set; }
            [JsonPropertyName("family_name")]
            public string FamilyName { get; set; }
            [JsonPropertyName("picture")]
            public string Picture { get; set; }
        }
    }

}
