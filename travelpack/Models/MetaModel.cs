using Newtonsoft.Json;

namespace travelpack.Models
{
    public class MetaModel
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("disclaimer")]
        public string Disclaimer { get; set; }
    }
}