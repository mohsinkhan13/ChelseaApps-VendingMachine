using System.Linq;
using NUnit.Framework;

namespace ChelseaApps.VendingMachine.Repositories.UnitTests
{
    [TestFixture]
    public class StaticProductRepositoryFixture
    {
        [Test]
        public void GetAllReturnsNineProducts()
        {
            const int expectedProductcount = 9;
            var repository = new StaticProductRepository();

            var productList = repository.GetAll();

            Assert.AreEqual(expectedProductcount, productList.Count());
        }

        [Test]
        public void GetReturnsProductWithIdOne()
        {
            const string expectedProductId = "1";
            var repository = new StaticProductRepository();

            var product = repository.Get(expectedProductId);

            Assert.IsNotNull(product);
            Assert.AreEqual(expectedProductId, product.ProductNumber);
        }
    }
}
