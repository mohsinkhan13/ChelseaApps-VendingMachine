using ChelseaApps.VendingMachine.Shared.Validations;
using NUnit.Framework;

namespace ChelseaApps.VendingMachine.Shared.UnitTests.Validations
{
    [TestFixture]
    public class CoinValidatorFixture
    {
        [Test]
        public void ValidateReturnsTrueFor5P()
        {
            var validator = new CoinValidator();

            var result = validator.Contains(0.05m);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateReturnsTrueFor10P()
        {
            var validator = new CoinValidator();

            var result = validator.Contains(0.10m);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateReturnsTrueFor20P()
        {
            var validator = new CoinValidator();

            var result = validator.Contains(0.20m);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateReturnsTrueFor50P()
        {
            var validator = new CoinValidator();

            var result = validator.Contains(0.50m);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateReturnsTrueFor1Pound()
        {
            var validator = new CoinValidator();

            var result = validator.Contains(1.00m);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateReturnsTrueFor2Pounds()
        {
            var validator = new CoinValidator();

            var result = validator.Contains(2.00m);

            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateReturnsTrueFor2PoundsNonDecimal()
        {
            var validator = new CoinValidator();

            var result = validator.Contains(2);

            Assert.IsTrue(result);
        }
    }
}
