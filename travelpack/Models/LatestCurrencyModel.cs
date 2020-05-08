using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace travelpack.Models
{
    public class LatestCurrencyModel
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("response")]
        public Response Response { get; set; }
    }

    public partial class Meta
    {
        [JsonProperty("code")]
        public long Code { get; set; }

        [JsonProperty("disclaimer")]
        public string Disclaimer { get; set; }
    }

    public partial class Response
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, double> Rates { get; set; }
    }
}