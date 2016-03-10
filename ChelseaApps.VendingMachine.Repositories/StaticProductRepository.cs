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

        private IEnumerable<Product> InitialiseProductsList()
        {
            return new List<Product>
            {
                new Product {ProductNumber = "1", Stock = 10, Price = 1.50m, ProductTitle = "A"},
                new Product {ProductNumber = "2", Stock = 10, Price = 1.00m, ProductTitle = "B"},
                new Product {ProductNumber = "3", Stock = 10, Price = 1.70m, ProductTitle = "C"},
                new Product {ProductNumber = "4", Stock = 10, Price = 2.00m, ProductTitle = "D"},
                new Product {ProductNumber = "5", Stock = 10, Price = 0.50m, ProductTitle = "E"},
                new Product {ProductNumber = "6", Stock = 10, Price = 0.20m, ProductTitle = "F"},
                new Product {ProductNumber = "7", Stock = 10, Price = 1.60m, ProductTitle = "G"},
                new Product {ProductNumber = "8", Stock = 10, Price = 3.50m, ProductTitle = "H"},
                new Product {ProductNumber = "9", Stock = 10, Price = 0.40m, ProductTitle = "I"}
            };
        }
    }
}