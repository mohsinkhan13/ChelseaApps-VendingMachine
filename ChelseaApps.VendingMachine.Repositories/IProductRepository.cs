using System.Collections.Generic;
using ChelseaApps.VendingMachine.Shared.DataModels;

namespace ChelseaApps.VendingMachine.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(string productNumber);
        void DecrementProductQuantity(string productNumber, int decrementBy);
    }
}
