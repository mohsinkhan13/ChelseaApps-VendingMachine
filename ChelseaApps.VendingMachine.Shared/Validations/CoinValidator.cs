using System.Collections.Generic;

namespace ChelseaApps.VendingMachine.Shared.Validations
{
    public class CoinValidator : ICurrencyValidator
    {
        private readonly List<decimal> _acceptedCoins;

        public CoinValidator(List<decimal> acceptedCoins)
        {
            _acceptedCoins = acceptedCoins;
        }

        public bool Contains(decimal value)
        {
            return _acceptedCoins.Contains(value);
        }
    }
}