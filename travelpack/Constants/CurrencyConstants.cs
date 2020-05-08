using System;

using Xamarin.Forms;

namespace travelpack.Constants
{
    public class CurrencyConstants
    {
        public static string PickerTitle = "Select Base Currency";

        public static string CurrencyBaseURL = "https://api.currencyscoop.com/v1";

        public static string ApiKey = "3d8233db085b8963e372618f602c455a";
               
        public static string LatestURL()
        {
            return $"{CurrencyBaseURL}/latest";
        }

        public static string HistoricalURL()
        {
            return $"{CurrencyBaseURL}/historical";
        }

        public static string TimeseriesURL()
        {
            return $"{CurrencyBaseURL}/timeseries";
        }

        public static string CurrenciesURL()
        {
            return $"{CurrencyBaseURL}/currencies";
        }

        public static string ConvertURL()
        {
            return $"{CurrencyBaseURL}/convert";
        }
    }
}