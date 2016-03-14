using System;
using System.Collections.Generic;
using System.Linq;
using ChelseaApps.VendingMachine.Repositories;
using ChelseaApps.VendingMachine.Shared.DataModels;
using ChelseaApps.VendingMachine.Shared.Exceptions;
using ChelseaApps.VendingMachine.Shared.Validations;

namespace ChelseaApps.VendingMachine.UI
{
    //TODO Implement IOC
    //TODO refactor
    //TODO add unit tests
    public class VendingMachine
    {
        private readonly IProductRepository _repository;
        private readonly ICurrencyValidator _validator;
        private Product _product;
        private readonly List<decimal> _acceptedCoins;
        private readonly List<decimal> _userCoins;

        public VendingMachine()
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

            _userCoins = new List<decimal>();

            //TODO implement IOC
            _repository = new StaticProductRepository();
            _validator = new CoinValidator(_acceptedCoins);
        }

       

        public bool AnyChangeToGive
        {
            get { return _userCoins.Sum() - _product.Price > 0; }
        }

        public bool UserHasPaidFullAmount
        {
            get { return _userCoins.Sum() >= _product.Price; }
        }


        public IEnumerable<Product> GetProducts()
        {
            var productList = _repository.GetAll();
            return productList;
        }

        public void SelectUserProductChoice(string productNumber)
        {
            _product = _repository.Get(productNumber);
            if (_product == null)
                throw new ProductNotFoundException("Product not found");
            if(_product.Stock <= 0)
                throw new ProductOutOfStockException("This product is out of stock");
        }

        public void AcceptUserCoin(decimal coin)
        {
            if(!_validator.Contains(coin))
                //TODO make message more dynamic based on accepted coins list
                throw new InvalidCoinException("This machine only accepts 10p,20p,50p,£1,£2");
            _userCoins.Add(coin);
        }

        public decimal GetRemainingAmoutToBePaid()
        {
            return _product.Price - _userCoins.Sum();
        }

        public IEnumerable<decimal> GetChange()
        {
            var coinsForChange = new List<decimal>();

            var change = _userCoins.Sum() - _product.Price;

            foreach (var coin in _acceptedCoins.OrderByDescending(arg => arg))
            {
                while (change >= coin)
                {
                    var remainder = change % coin;
                    change = remainder;
                    coinsForChange.Add(coin);
                }
                if (change == 0) break;
            }

            CompleteTransaction();

            return coinsForChange;

        }

        private void CompleteTransaction()
        {
            _repository.DecrementProductQuantity(_product.ProductNumber, 1);
            _product = null;
            _userCoins.Clear();
        }
    }

   
}