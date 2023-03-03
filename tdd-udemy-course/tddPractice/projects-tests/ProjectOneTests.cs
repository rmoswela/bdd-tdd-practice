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

/**
 * If divisible by 3  -> return "Fizz"
 * If divisible by 5  -> return "Buzz"
 * If divisible by 3 and 5 -> return "FizzBuzz"
 * Otherwise  -> return ""
 */
[TestFixture]
public class FizzBuzzTests
{
   [Test]
   [TestCase("Fizz", 3)]
   [TestCase("Buzz", 5)]
   [TestCase("Fizz", 6)]
   [TestCase("Buzz", 10)]
   [TestCase("", 11)]
   [TestCase("FizzBuzz", 15)]
   [TestCase("FizzBuzz", 30)]
   [TestCase("", 8)]
   public void TestFizzBuzz(string expectedPhrase, int value)
   {
      //Arrange
      FizzBuzz fb = new FizzBuzz();

      //Act
      string actual = fb.GenerateFizzBuzz(value);

      //Assert
      Assert.That(actual, Is.EqualTo(expectedPhrase));
   }
}
