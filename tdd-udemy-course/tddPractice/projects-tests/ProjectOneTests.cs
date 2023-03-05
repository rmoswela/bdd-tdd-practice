namespace projects_tests;
using project_one;
using System.Diagnostics;

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

/**
 * Function that takes in roman numerals and returns a regular number
 * Roman Symbols and their meaning
 * I = 1, V= 5, X = 10, L = 50, C = 100, D = 500 M = 1000
 * Subtractive notation: IV = 4, IX = 9
 */
[TestFixture]
public class RomanNumeralsTranslationTests
{
   [Test]
   [TestCase("I", 1)]
   [TestCase("V", 5)]
   [TestCase("II", 2)]
   [TestCase("IV", 4)]
   [TestCase("X", 10)]
   [TestCase("IX", 9)]
   [TestCase("XIX", 19)]
   [TestCase("L", 50)]
   [TestCase("C", 100)]
   [TestCase("D", 500)]
   [TestCase("M", 1000)]

   public void TestRomanNumeralsTranslation(string romanNumeral, int expectedValue)
   {
      //Arrange
      RomanNumeralTranslation roman = new RomanNumeralTranslation();

      //Act
      int value = roman.GetNormalNumber(romanNumeral);

      //Assert
      Assert.That(value, Is.EqualTo(expectedValue));
   }

}

/**
 * Tdd testing with multi threads and concurrent access
 * 
 * 
 */
[TestFixture]
public class UpdateableSpinTests
{
   [Test]
   public void Wait_NoPulse_ReturnFalse()
   {
      //Arrange
      UpdateableSpin spin = new UpdateableSpin();

      //Act
      bool wasPulsed = spin.Wait(TimeSpan.FromMilliseconds(10));

      //Assert
      Assert.IsFalse(wasPulsed);
   }

   [Test]
   public void Wait_Pulse_ReturnTrue()
   {
      //Arrange
      UpdateableSpin spin = new UpdateableSpin();

      //Act
      Task.Factory.StartNew(() =>
      {
         Thread.Sleep(100);
         spin.Set();
      });
      bool wasPulsed = spin.Wait(TimeSpan.FromSeconds(10));

      //Assert
      Assert.IsTrue(wasPulsed);
   }

   [Test]
   public void Wait50MilliSec_CallIsActuallyWaiting50MilliSec()
   {
      //Arrange
      var spin = new UpdateableSpin();
      Stopwatch watcher = new Stopwatch();

      //Act
      watcher.Start();
      spin.Wait(TimeSpan.FromMilliseconds(50));
      watcher.Stop();

      TimeSpan actual = TimeSpan.FromMilliseconds(watcher.ElapsedMilliseconds);
      TimeSpan leftEpsilon = TimeSpan.FromMilliseconds(50 - (50 * 0.1));
      TimeSpan rightEpsilon = TimeSpan.FromMilliseconds(50 + (50 * 0.1));

      //Assert
      Assert.IsTrue(actual > leftEpsilon && actual < rightEpsilon);
   }

   [Test]
   public void Wait50MilliSec_UpdateAfter30Millisec_TotalWaitingIsApprox800Millisec()
   {
      //Arrange
      var spin = new UpdateableSpin();
      var watcher = new Stopwatch();
      const int timeout = 500;
      const int spanBeforeUpdate = 300;

      //Act
      watcher.Start();

      Task.Factory.StartNew(() =>
      {
         Thread.Sleep(spanBeforeUpdate);
         spin.UpdateTimeout();
      });

      spin.Wait(TimeSpan.FromMilliseconds(timeout));

      watcher.Stop();

      TimeSpan actual = TimeSpan.FromMilliseconds(watcher.ElapsedMilliseconds);
      const int expected = timeout + spanBeforeUpdate;

      TimeSpan left = TimeSpan.FromMilliseconds(expected - (expected * 0.1));
      TimeSpan right = TimeSpan.FromMilliseconds(expected + (expected * 0.1));

      //Assert
      Assert.IsTrue(actual > left && actual < right);
   }
}

