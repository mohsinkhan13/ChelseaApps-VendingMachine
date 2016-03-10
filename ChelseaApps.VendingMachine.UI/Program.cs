using System;
using System.Collections.Generic;
using System.Linq;
using ChelseaApps.VendingMachine.Repositories;
using ChelseaApps.VendingMachine.Shared.DataModels;

namespace ChelseaApps.VendingMachine.UI
{
    class Program
    {
        //TODO use IOC
        private static readonly IProductRepository _repository = new StaticProductRepository();
        
        static void Main(string[] args)
        {

            var productList = GetProductList().ToList();

            do
            {
                DisplayProducts(productList);
                Console.WriteLine("Please select a product:");
                var productNumber = GetUserInput();
                Console.WriteLine("Please insert coins:");
                var coins = GetCoins();
            } while (true);
            
        }

        private static string GetUserInput()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var input = Console.ReadLine();
            Console.ResetColor();
            return input;
        }

        private static string GetCoins()
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
