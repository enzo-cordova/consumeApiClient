using Newtonsoft.Json;

namespace ConsoleAppConsumeApi.Model
{
    public class Campaign : Entity
    {
        [JsonProperty(PropertyName = "campaignId")]
        public override int Id { get; set; }
    }
}
