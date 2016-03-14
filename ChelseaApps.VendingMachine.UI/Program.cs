using System;
using System.Collections.Generic;
using System.Linq;
using ChelseaApps.VendingMachine.Shared.DataModels;
using ChelseaApps.VendingMachine.Shared.Exceptions;

namespace ChelseaApps.VendingMachine.UI
{
    class Program
    {
        //TODO implement IOC
        private static readonly VendingMachine _machine = new VendingMachine();
        
        static void Main(string[] args)
        {
            
            var productList = _machine.GetProducts().ToList();
            

            do
            {
                DisplayProducts(productList);
                Console.WriteLine("Please select a product:");
                var productNumber = GetUserInput();

                try
                {
                    _machine.SelectUserProductChoice(productNumber);
                }
                catch (ProductNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
                catch (ProductOutOfStockException e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                Console.WriteLine("Please insert coins:");
                do
                {
                    decimal coin;
                    decimal.TryParse(GetCoin(), out coin);

                    try
                    {
                        _machine.AcceptUserCoin(coin);
                    }
	                catch (InvalidCoinException e)
	                {
	                    Console.WriteLine(e.Message);
                        continue;
	                }

                    var remainingAmount = _machine.GetRemainingAmoutToBePaid();
                    if (remainingAmount > 0)
                    {
                        Console.WriteLine(string.Format("£{0} remaining:", remainingAmount));
                        continue;
                    }

                    Console.WriteLine("Vending product . . .");

                    if (_machine.AnyChangeToGive)
                    {
                        var change = _machine.GetChange();
                        Console.WriteLine("Thank you, please take your change:");

                        foreach (var changeCoin in change)
                        {
                            Console.WriteLine(string.Format("£{0}", changeCoin));
                        }
                    }

                    break;

                } while (!_machine.UserHasPaidFullAmount);
            } while (true);
            
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

        
    }
}
