using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace travelpack.Models
{
    public class ResponseModel
    {
        private string stringDateTime;

        [JsonProperty("timestamp")]
        public double Timestamp { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("value")]
        public double ConvertedValue { get; set; }


        public double RoundedValue
        {
            get
            {
                return Math.Round(ConvertedValue, 2);
            }
        }

        public string StringDateTime
        {
            get
            {
                DateTime unixStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                long unixTimeStampInTicks = (long)(Timestamp * TimeSpan.TicksPerSecond);
                DateTime r = new DateTime(unixStart.Ticks + unixTimeStampInTicks, DateTimeKind.Utc);
                var localDateTime = r.ToLocalTime();
                stringDateTime = localDateTime.ToString("dd/MM/yy H:mm:ss");
                return stringDateTime;
            }
            set { }
        }
    }
}