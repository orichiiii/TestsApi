using Newtonsoft.Json;

namespace ApiTests.Models
{
    public class ChangePasswordResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
