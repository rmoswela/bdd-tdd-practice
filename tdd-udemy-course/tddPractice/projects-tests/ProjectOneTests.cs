namespace projects_tests;
using project_one;

[TestFixture]
public class CalculatorTests
{
   [Test]
   public void AddNumbers_ValidValues_ReturnsCorrectResult()
   {
      var cal = new Calculator();
      int result = cal.AddNumber(2, 3);

      Assert.That(result, Is.EqualTo(5));
   }
}

/**
 * Sequence of fibonacci numbers
 * 1, 1, 2, 3, 5, 8, 13, 21, 34, 45
 * or
 * 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 45
 * */
[TestFixture]
public class FibonacciTests
{
   [TestCase(0, 0)]
   [TestCase(1, 1)]
   [TestCase(1, 2)]
   [TestCase(2, 3)]
   [TestCase(3, 4)]
   [TestCase(5, 5)]
   [TestCase(8, 6)]
   [Test]
   public void TestFibonacci(int expected, int index)
   {
      //Arrange
      Fibonacci fibo = new Fibonacci();

      //Act
      var actual = fibo.GetFibonacci(index);

      //Assert
      Assert.That(expected, Is.EqualTo(actual));
   }
}
