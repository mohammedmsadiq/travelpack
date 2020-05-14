using System;
using System.Collections.Generic;
using travelpack.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace travelpack.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewBase : ContentPage, IPage
    {
        public ViewBase()
        {
            InitializeComponent();
        }
    }
}
