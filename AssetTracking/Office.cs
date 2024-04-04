using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetTracking
{
    public class Office(string name, string currency, float exchangeRate)
    {
        public string Country { set; get; } = name;
        public float ExchangeRateFromDollar { set; get; } = exchangeRate;
        public string Currency { set; get; } = currency;

        public void Deconstruct(out string country, out string currency, out float exchangeRate)
        {
            country = Country;
            currency = Currency;
            exchangeRate = ExchangeRateFromDollar;
        }
    }


}