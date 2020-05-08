using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;

namespace travelpack.Helpers
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static bool IsLoadedFirstTime
        {
            get => AppSettings.GetValueOrDefault(nameof(IsLoadedFirstTime), true);
            set => AppSettings.AddOrUpdateValue(nameof(IsLoadedFirstTime), value);
        }

        public static string CurrencyCode
        {
            get => AppSettings.GetValueOrDefault(nameof(IsLoadedFirstTime), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(IsLoadedFirstTime), value);
        }
    }
}