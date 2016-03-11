using System.Collections.Generic;
using System.Linq;
using ChelseaApps.VendingMachine.Shared.DataModels;

namespace ChelseaApps.VendingMachine.Repositories
{
    public class StaticProductRepository : IProductRepository
    {
        private readonly IEnumerable<Product> _products;

        public StaticProductRepository()
        {
            _products = InitialiseProductsList();
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product Get(string productNumber)
        {
            return _products.FirstOrDefault(x => x.ProductNumber == productNumber);
        }

        public void DecrementProductQuantity(string productNumber, int decrementBy)
        {
            var product = _products.FirstOrDefault(x => x.ProductNumber == productNumber);
            if(product!= null)
                product.Stock -= decrementBy;
        }


        private IEnumerable<Product> InitialiseProductsList()
        {
            return new List<Product>
            {
                new Product {ProductNumber = "1", Stock = 0, Price =  0.80m, ProductTitle = "Coca Cola 330ml"},
                new Product {ProductNumber = "2", Stock = 10, Price = 0.80m, ProductTitle = "Coke Zero 330ml"},
                new Product {ProductNumber = "3", Stock = 10, Price = 0.80m, ProductTitle = "Fanta 330ml"},
                new Product {ProductNumber = "4", Stock = 10, Price = 0.80m, ProductTitle = "Sprite 330ml"},
                new Product {ProductNumber = "5", Stock = 10, Price = 1.20m, ProductTitle = "Coca Cola 500ml"},
                new Product {ProductNumber = "6", Stock = 10, Price = 1.20m, ProductTitle = "Coke Zero 500ml"},
                new Product {ProductNumber = "7", Stock = 10, Price = 1.20m, ProductTitle = "Fanta 500ml"},
                new Product {ProductNumber = "8", Stock = 10, Price = 1.20m, ProductTitle = "Sprite 500ml"},
                new Product {ProductNumber = "9", Stock = 10, Price = 1.00m, ProductTitle = "Water 500ml"}
            };
        }
    }
}