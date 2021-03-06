﻿using System;
using System.Threading.Tasks;
using travelpack.Models;
using Xamarin.Forms;

namespace travelpack.Interfaces
{
    public interface ICurrencyService 
    {
        Task<LatestCurrencyModel> GetLatest(string currencyType);
    }
}

