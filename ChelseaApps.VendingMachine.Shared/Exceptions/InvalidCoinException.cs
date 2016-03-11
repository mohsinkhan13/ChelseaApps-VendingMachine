using System;

namespace ChelseaApps.VendingMachine.Shared.Exceptions
{
    public class InvalidCoinException : Exception
    {
        public InvalidCoinException(string message)
            : base(message)
        {
        }
    }
}