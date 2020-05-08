using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using travelpack.Constants;
using travelpack.Interfaces;
using travelpack.Models;
using Unity.Injection;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace travelpack.Services
{
    public class CurrencyService : ICurrencyService
    {
        public LatestCurrencyModel Items { get; set; }

        public async Task<LatestCurrencyModel> GetLatest(string currencyType)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var url = CurrencyConstants.LatestURL();
                    var param = string.Format(url + "?api_key=" + CurrencyConstants.ApiKey + "&base=" + currencyType);
                    var response = await client.GetAsync(param.ToString());
                    
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        Items = JsonConvert.DeserializeObject<LatestCurrencyModel>(result);
                    }
                    else
                    {
                        var exception = new Exception($"Api Error: {response.RequestMessage}");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Items;
        }
    }
}