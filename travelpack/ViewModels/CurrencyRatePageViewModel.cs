using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using travelpack.Interfaces;
using travelpack.Models;

namespace travelpack.ViewModels
{
    public class CurrencyRatePageViewModel : ViewModelBase
    {
        protected readonly ICurrencyService CurrencyService;
        private string fromSelectedPicker;
        private string toSelectedPicker;
        private double amount;

        private ObservableCollection<ConvertCurrencyModel> convertedData;
        public ObservableCollection<ConvertCurrencyModel> ConvertedData
        {
            get { return convertedData; }
            set
            {
                if (convertedData != value)
                {
                    convertedData = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SwapCommand { get; }
        public ICommand ConvertCommand { get; set; }

        private ObservableCollection<string> data;
        private double convertedAmount;
        private double convertedValue;
        private string convertedFrom;
        private string convertedTo;
        private string convertedTimestamp;
        private string convertedDate;

        public ObservableCollection<string> Data
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

            this.SwapCommand = new DelegateCommand(async () =>
            {
                await this.SwapCurrencyAction();

            })
                .ObservesCanExecute(() => this.SwapCanExcute)
                 .ObservesProperty(() => this.Amount);
            this.ConvertCommand = new DelegateCommand(async () =>
            {
                await this.ConvertAction();
            })
                .ObservesCanExecute(() => this.CanExcute)
                .ObservesProperty(() => this.Amount)
                .ObservesProperty(() => this.ToSelectedPicker)
                .ObservesProperty(() => this.FromSelectedPicker);
        }        

        private async Task SwapCurrencyAction()
        {
            var temp = FromSelectedPicker;
            this.FromSelectedPicker = ToSelectedPicker;
            this.ToSelectedPicker = temp;
            this.ConvertAction();
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async Task ConvertAction()
        {
            var convertedResult = await this.CurrencyService.GetCurrency(FromSelectedPicker, ToSelectedPicker, Amount);
            this.ConvertedValue = convertedResult.Response.RoundedValue;
            this.ConvertedTimestamp = "Updated: " + convertedResult.Response.StringDateTime;
            OnPropertyChanged(nameof(IsValueVisible));
        }

        public double ConvertedValue
        {
            get => convertedValue;
            set => SetProperty(ref convertedValue, value);
        }

        public string From
        {
            get => convertedFrom;
            set => SetProperty(ref convertedFrom, value);
        }

        public bool IsValueVisible
        {
            get
            {
                if (ConvertedValue == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public string ConvertedTo
        {
            get => convertedTo;
            set => SetProperty(ref convertedTo, value);
        }

        public double ConvertedAmount
        {
            get => convertedAmount;
            set => SetProperty(ref convertedAmount, value);
        }

        public string ConvertedTimestamp
        {
            get { return convertedTimestamp; }
            set
            {
                this.SetProperty(ref this.convertedTimestamp, value);
                OnPropertyChanged();
            }
        }



        public string ConvertedDate
        {
            get => convertedDate;
            set => SetProperty(ref convertedDate, value);
        }

        public string FromSelectedPicker
        {
            get => fromSelectedPicker;
            set => SetProperty(ref fromSelectedPicker, value);
        }

        public string ToSelectedPicker
        {
            get => toSelectedPicker;
            set => SetProperty(ref toSelectedPicker, value);
        }

        public double Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }


        public bool SwapCanExcute
        {
            get
            {
                bool result = Amount > 0;
                return result;
            }
        }

        public bool CanExcute
        {
            get
            {
                bool result = !string.IsNullOrEmpty(ToSelectedPicker) && !string.IsNullOrEmpty(FromSelectedPicker) && Amount > 0;
                return result;
            }
        }

        private async void LoadPicker()
        {
            Data = new ObservableCollection<string>();
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