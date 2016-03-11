using System.Collections.Generic;
using ChelseaApps.VendingMachine.Shared.Validations;
using NUnit.Framework;

namespace ChelseaApps.VendingMachine.Shared.UnitTests.Validations
{
    [TestFixture]
    public class CoinValidatorFixture
    {
        private ICurrencyValidator _validator; 
        [SetUp]
        public void SetUp()
        {
            var acceptedCoins = new List<decimal>
            {
                0.05m,
                0.10m,
                0.20m,
                0.50m,
                1.00m,
                2.00m
            };

            _validator = new CoinValidator(acceptedCoins);

        }
        [Test]
        public void ValidateReturnsTrueFor5P()
        {
            var result = _validator.Contains(0.05m);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateReturnsTrueFor10P()
        {

            var result = _validator.Contains(0.10m);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateReturnsTrueFor20P()
        {

            var result = _validator.Contains(0.20m);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateReturnsTrueFor50P()
        {

            var result = _validator.Contains(0.50m);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateReturnsTrueFor1Pound()
        {

            var result = _validator.Contains(1.00m);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateReturnsTrueFor2Pounds()
        {

            var result = _validator.Contains(2.00m);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateReturnsTrueFor2PoundsNonDecimal()
        {

            var result = _validator.Contains(2);

            Assert.IsTrue(result);
        }
    }
}
