using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppConsumeApi.Model
{
    public class Campaign : Entity
    {
        [JsonProperty(PropertyName = "campaignId")]
        public override int Id { get; set; }
    }
}
