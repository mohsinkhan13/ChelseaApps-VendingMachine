using System;
using System.Collections.Generic;
using System.Linq;
using ChelseaApps.VendingMachine.Repositories;
using ChelseaApps.VendingMachine.Shared.DataModels;
using ChelseaApps.VendingMachine.Shared.Exceptions;
using ChelseaApps.VendingMachine.Shared.Validations;

namespace ChelseaApps.VendingMachine.UI
{
    class Program
    {
        //TODO use IOC
        private static readonly IProductRepository _repository = new StaticProductRepository();
        private static readonly ICurrencyValidator _validator = new CoinValidator();
        
        static void Main(string[] args)
        {

            var productList = GetProductList().ToList();
            Product product = null;
            var userCoins = new List<decimal>();

            do
            {
                DisplayProducts(productList);
                Console.WriteLine("Please select a product:");
                var productNumber = GetUserInput();

                try
                {
                    product = GetUserselectedProduct(productNumber);
                }
                catch (ProductNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                Console.WriteLine("Please insert coins:");
                do
                {
                    decimal coin;
                    decimal.TryParse(GetCoin(), out coin);

                    if (!_validator.Contains(coin))
                    {
                        Console.WriteLine("This machine only accepts 10p,20p,50p,£1,£2");
                        continue;
                    }
                    userCoins.Add(coin);
                    var sum = userCoins.Sum();
                    if (sum < product.Price)
                    {
                        Console.WriteLine(string.Format("£{0} remaining:", product.Price - sum));
                        continue;
                    }

                    if (sum > product.Price)
                    {
                        //DispenseChange(product.Price, sum);
                    }

                    break;

                } while (true);
            } while (true);
            
        }

        private static List<decimal> DispenseChange(decimal price, decimal sum)
        {
            var returnedChange = new List<decimal>();
            var toReturn = sum - price;
            while (toReturn != 0)
            {
                if (_validator.Contains(toReturn))
                {
                    returnedChange.Add(toReturn);
                    toReturn = 0;
                }


            }

        }

        private static Product GetUserselectedProduct(string productNumber)
        {
            var product = _repository.Get(productNumber);
            if (product == null)
                throw new ProductNotFoundException("Product not found");

            return product;
        }

        private static string GetUserInput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }

        private static string GetCoin()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("£");
            var input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }

        private static void DisplayProducts(IEnumerable<Product> productList)
        {
            Console.WriteLine(string.Format("Number \t Stock \t Price \t Product"));

            foreach (var product in productList)
            {
                Console.WriteLine(string.Format("#{0} \t {1} \t {2} \t {3}", product.ProductNumber, product.Stock, product.Price,
                    product.ProductTitle));
            }
        }

        private static IEnumerable<Product> GetProductList()
        {
            var productList = _repository.GetAll();
            return productList;
        }
    }
}
