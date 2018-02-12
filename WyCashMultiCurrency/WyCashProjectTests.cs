using Microsoft.VisualStudio.TestTools.UnitTesting;
using WyCash;

namespace WyCashMultiCurrency
{
    [TestClass]
    public class WyCashProjectTests
    {
        /*
         *  add amounts in two different currencies and convert the result given a set of exchange rates
         *  
         *  multiply an amount (price per share) by a number (number of shares) and receive an amount
         *   
         *  To do: 
         *  $5 + 10 CHF = $10 if CHF:USD is 2:1 
         *  $5 * 2 = $10 
         */
        [TestMethod]
        public void testDollarMultiplication()
        {
            //Arrange
            Money d = Money.dollar(5);

            //Act

            //Assert
            Assert.ReferenceEquals(Money.dollar(10), d.times(2));
            Assert.ReferenceEquals(Money.dollar(15), d.times(3));
        }

        [TestMethod]
        public void testEquality()
        {
            Assert.IsTrue(Money.dollar(5).equals(Money.dollar(5)));
            Assert.IsFalse(Money.dollar(5).equals(Money.dollar(6)));
            Assert.IsTrue(Money.francs(5).equals(Money.francs(5)));
            Assert.IsFalse(Money.francs(5).equals(Money.francs(6)));
            Assert.IsFalse(Money.francs(5).equals(Money.dollar(5)));

        }

        [TestMethod]
        public void testFrancsMultiplication()
        {
            //Arrange
            Money fra = Money.francs(5);

            //Act

            //Assert
            Assert.ReferenceEquals(Money.francs(10), fra.times(2));
            Assert.ReferenceEquals(Money.francs(15), fra.times(3));
        }

        [TestMethod]
        public void testCurrency()
        {
            Assert.AreEqual("USD", Money.dollar(1).currency());
            Assert.AreEqual("CHF", Money.francs(1).currency());
        }
    }
}
