using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestPlayground
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void BasicRooterTest()
        {
            //instance to test
            Rooter rooter = new Rooter();

            //initialize test variable
            double expectedResult = 2.0;

            double input = expectedResult * expectedResult;

            //run method under test
            double actualResult = rooter.SquareRoot(input);

            // Verify the result:  
            Assert.AreEqual(expectedResult, actualResult,
                delta: expectedResult / 100);
        }

        [TestMethod]
        public void RooterValueRange()
        {
            //instance to test
            Rooter rooter = new Rooter();

            //range of values
            for (double expectedResult = 1e-8; expectedResult < 1e+8; expectedResult = expectedResult * 3.2)
            {
                RooterOneValue(rooter, expectedResult);
            }
        }

        private void RooterOneValue(Rooter rooter, double expectedResult)
        {
            double input = expectedResult * expectedResult;
            double actualResult = rooter.SquareRoot(input);
            Assert.AreEqual(expectedResult, actualResult, delta: expectedResult / 1000);
        }

        [TestMethod]
        public void RooterTestNegativeInputx()
        {
            Rooter rooter = new Rooter();

            try
            {
                rooter.SquareRoot(-10);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return;
            }
            Assert.Fail();
        }
    }
}
