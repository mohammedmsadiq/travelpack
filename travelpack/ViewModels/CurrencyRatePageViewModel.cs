using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Prism.Navigation;
using Prism.Services;
using travelpack.Constants;
using travelpack.Helpers;
using travelpack.Interfaces;

namespace travelpack.ViewModels
{
    public class CurrencyRatePageViewModel : ViewModelBase
    {
        protected readonly ICurrencyService CurrencyService;

        private List<string> data;
        private string selectedCode;
        private string pickerTitle;

        public List<string> Data
        {
            get { return data; }
            set
            {
                if (data != value)
                {
                    data = value;
                    OnPropertyChanged();
                }
            }
        }

        public CurrencyRatePageViewModel(INavigationService navigationService, IPageDialogService dialogService, ICurrencyService currencyService) : base(navigationService, dialogService)
        {
            this.CurrencyService = currencyService;


            this.LoadPicker();
            this.ExecuteAsyncTask(async () =>
            {
                // var r = await this.CurrencyService.GetLatest("GBP");
            });
        }

        public string SelectedCode
        {
            get { return selectedCode; }
            set
            {
                this.SetProperty(ref this.selectedCode, value, this.SelectedCodeChanged);
            }
        }

        private async void SelectedCodeChanged()
        {
            Settings.CurrencyCode = selectedCode;
            //var r = await this.CurrencyService.GetLatest(selectedCode);
        }

        public string PickerTitle
        {
            get
            {
                return pickerTitle = CurrencyConstants.PickerTitle;
            }
        }



        private async void LoadPicker()
        {
            Data = new List<string>();
            Data.Add("USD");
            Data.Add("EUR");
            Data.Add("GBP");
            Data.Add("INR");
            Data.Add("AUD");
            Data.Add("CAD");
            Data.Add("SGD");
            Data.Add("CHF");
            Data.Add("MYR");
            Data.Add("JPY");
            Data.Add("CNY");
            Data.Add("NZD");
            Data.Add("THB");
            Data.Add("HUF");
            Data.Add("AED");
            Data.Add("HKD");
            Data.Add("MXN");
            Data.Add("ZAR");
            Data.Add("PHP");
            Data.Add("SEK");
            Data.Add("IDR");
            Data.Add("SAR");
            Data.Add("BRL");
            Data.Add("TRY");
            Data.Add("KES");
            Data.Add("KRW");
            Data.Add("EGP");
            Data.Add("IQD");
            Data.Add("NOK");
            Data.Add("KWD");
            Data.Add("RUB");
            Data.Add("DKK");
            Data.Add("PKR");
            Data.Add("ILS");
            Data.Add("PLN");
            Data.Add("QAR");
            Data.Add("XAU");
            Data.Add("OMR");
            Data.Add("COP");
            Data.Add("CLP");
            Data.Add("TWD");
            Data.Add("ARS");
            Data.Add("CZK");
            Data.Add("VND");
            Data.Add("MAD");
            Data.Add("JOD");
            Data.Add("BHD");
            Data.Add("XOF");
            Data.Add("LKR");
            Data.Add("UAH");
            Data.Add("NGN");
            Data.Add("TND");
            Data.Add("UGX");
            Data.Add("RON");
            Data.Add("BDT");
            Data.Add("PEN");
            Data.Add("GEL");
            Data.Add("XAF");
            Data.Add("FJD");
            Data.Add("VEF");
            Data.Add("VES");
            Data.Add("BYN");
            Data.Add("HRK");
            Data.Add("UZS");
            Data.Add("BGN");
            Data.Add("DZD");
            Data.Add("IRR");
            Data.Add("DOP");
            Data.Add("ISK");
            Data.Add("XAG");
            Data.Add("CRC");
            Data.Add("SYP");
            Data.Add("LYD");
            Data.Add("JMD");
            Data.Add("MUR");
            Data.Add("GHS");
            Data.Add("AOA");
            Data.Add("UYU");
            Data.Add("AFN");
            Data.Add("LBP");
            Data.Add("XPF");
            Data.Add("TTD");
            Data.Add("TZS");
            Data.Add("ALL");
            Data.Add("XCD");
            Data.Add("GTQ");
            Data.Add("NPR");
            Data.Add("BOB");
            Data.Add("ZWD");
            Data.Add("BBD");
            Data.Add("CUC");
            Data.Add("LAK");
            Data.Add("BND");
            Data.Add("BWP");
            Data.Add("HNL");
            Data.Add("PYG");
            Data.Add("ETB");
            Data.Add("NAD");
            Data.Add("PGK");
            Data.Add("SDG");
            Data.Add("MOP");
            Data.Add("NIO");
            Data.Add("BMD");
            Data.Add("KZT");
            Data.Add("PAB");
            Data.Add("BAM");
            Data.Add("GYD");
            Data.Add("YER");
            Data.Add("MGA");
            Data.Add("KYD");
            Data.Add("MZN");
            Data.Add("RSD");
            Data.Add("SCR");
            Data.Add("AMD");
            Data.Add("SBD");
            Data.Add("AZN");
            Data.Add("SLL");
            Data.Add("TOP");
            Data.Add("BZD");
            Data.Add("MWK");
            Data.Add("GMD");
            Data.Add("BIF");
            Data.Add("SOS");
            Data.Add("HTG");
            Data.Add("GNF");
            Data.Add("MVR");
            Data.Add("MNT");
            Data.Add("CDF");
            Data.Add("STN");
            Data.Add("TJS");
            Data.Add("KPW");
            Data.Add("MMK");
            Data.Add("LSL");
            Data.Add("LRD");
            Data.Add("KGS");
            Data.Add("GIP");
            Data.Add("XPT");
            Data.Add("MDL");
            Data.Add("CUP");
            Data.Add("KHR");
            Data.Add("MKD");
            Data.Add("VUV");
            Data.Add("MRU");
            Data.Add("ANG");
            Data.Add("SZL");
            Data.Add("CVE");
            Data.Add("SRD");
            Data.Add("XPD");
            Data.Add("SVC");
            Data.Add("BSD");
            Data.Add("XDR");
            Data.Add("RWF");
            Data.Add("AWG");
            Data.Add("DJF");
            Data.Add("BTN");
            Data.Add("KMF");
            Data.Add("WST");
            Data.Add("SPL");
            Data.Add("ERN");
            Data.Add("FKP");
            Data.Add("SHP");
            Data.Add("JEP");
            Data.Add("TMT");
            Data.Add("TVD");
            Data.Add("IMP");
            Data.Add("GGP");
            Data.Add("ZMW");
        }
    }
}