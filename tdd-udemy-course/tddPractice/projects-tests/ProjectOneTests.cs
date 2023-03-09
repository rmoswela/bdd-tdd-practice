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
 * Tdd testing of multi threads and concurrent access
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

/**
 * -- Plan -- 
 * Count moves
 * Rule the state of squares
 * Setting crosses and noughts
 * determine the state of the game and whose the winner
 * 
 */
[TestFixture]
public class TicTacToeTests
{
   [Test]
   public void CreateGame_With_ZeroMoves()
   {
      Game game = new Game();
      Assert.That(game.MovesCounter, Is.EqualTo(0));
   }

   [TestCase(1, State.Unset)]
   [TestCase(4, State.Unset)]
   [TestCase(7, State.Unset)]
   [TestCase(9, State.Unset)]
   public void CheckInitialState_IsSetCorrectly(int index, State state)
   {
      var game = new Game();
      Assert.That(state, Is.EqualTo(game.GetState(index)));
   }

   [Test]
   public void MakeMove_CounterShifts()
   {
      var game = new Game();
      game.MakeMove(1);

      Assert.That(game.MovesCounter, Is.EqualTo(1));
   }

   [TestCase(0)]
   [TestCase(10)]
   public void MakeInvalidMove_ThrowsException(int index)
   {
      Assert.Throws<ArgumentOutOfRangeException>(() => {
         var game = new Game();
         game.MakeMove(index);
      });
   }

   [Test]
   [TestCase(3)]
   [TestCase(7)]
   public void MoveOnSameSquare_ThrowsException(int index)
   {
      Assert.Throws<InvalidOperationException>(() => {
         var game = new Game();
         game.MakeMove(index);
         game.MakeMove(index);
      });
   }

   [Test]
   public void MakingMoves_SetStateCorrectly()
   {
      var game = new Game();

      game.MakeMove(1);
      game.MakeMove(6);
      game.MakeMove(2);
      game.MakeMove(5);
      game.MakeMove(3);

      Assert.That(game.GetState(1), Is.EqualTo(State.Cross));
      Assert.That(game.GetState(6), Is.EqualTo(State.Zero));
      Assert.That(game.GetState(2), Is.EqualTo(State.Cross));
      Assert.That(game.GetState(5), Is.EqualTo(State.Zero));
      Assert.That(game.GetState(3), Is.EqualTo(State.Cross));
   }

   [Test]
   public void GetWinner_ZeroesWinVertically_ReturnsZeroes()
   {
      var game = new Game();

      //2, 5, 8 zeroes win

      MakeMoves(game, 1, 2, 3, 5, 7, 8);

      Assert.That(game.GetWinner(), Is.EqualTo(Winner.Zeroes));
   }

   [Test]
   public void GetWinner_CrossesWinDiagonally_ReturnsCrosses()
   {
      var game = new Game();

      //1, 5, 9 crosses win

      MakeMoves(game, 1, 4, 5, 2, 9);

      Assert.That(game.GetWinner(), Is.EqualTo(Winner.Crosses));
   }

   [Test]
   public void GetWinner_GameIsUnfinished_ReturnsGameIsUnfinished()
   {
      var game = new Game();

      MakeMoves(game, 1, 2, 4);

      Assert.That(game.GetWinner(), Is.EqualTo(Winner.GameIsUnfinished));
   }

   private void MakeMoves(Game game, params int[] indexes)
   {
      foreach (var index in indexes)
      {
         game.MakeMove(index);
      }
   }
}
