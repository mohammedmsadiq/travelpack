using System;
using System.Runtime.CompilerServices;
using Prism;
using Prism.Ioc;
using travelpack.Interfaces;
using travelpack.Services;
using travelpack.ViewModels;
using travelpack.Views;
using Xamarin.Forms;

namespace travelpack
{
    public partial class App
    {
        /*
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor.
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "Expander_Experimental" });

            await NavigationService.NavigateAsync("NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<ViewBase, ViewModelBase>();
            containerRegistry.RegisterForNavigation<CurrencyRatePage, CurrencyRatePageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();

            containerRegistry.RegisterSingleton<ICurrencyService, CurrencyService>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
