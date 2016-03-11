using System.Collections.Generic;

namespace ChelseaApps.VendingMachine.Shared.Validations
{
    public class CoinValidator : ICurrencyValidator
    {
        private readonly List<decimal> _acceptedCoins;



        public CoinValidator()
        {
            _acceptedCoins = new List<decimal>
            {
                0.05m,
                0.10m,
                0.20m,
                0.50m,
                1.00m,
                2.00m
            };
        }
        public bool Contains(decimal value)
        {
            return _acceptedCoins.Contains(value);
        }
    }
}