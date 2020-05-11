using Newtonsoft.Json;

namespace travelpack.Models
{
    public class ConvertCurrencyModel 
    {
        [JsonProperty("meta")]
        public MetaModel Meta { get; set; }

        [JsonProperty("response")]
        public ResponseModel Response { get; set; }
    } 
}