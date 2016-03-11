using System;

namespace ChelseaApps.VendingMachine.Shared.Exceptions
{
    public class ProductOutOfStockException : Exception
    {
        public ProductOutOfStockException(string message) : base(message)
        {
        }
    }
}