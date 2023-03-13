namespace project_two_Sticks.Core.Tests;

[TestFixture]
public class SticksTests
{
   [Test]
   public void Constructor_LessThan10Sticks_ThrowsArgumentException()
   {
      Assert.Throws<ArgumentException>(() => new Game(9, Player.Machine));
   }

   [Test]
   public void Constructor_ValidParams_GameReturnCorrectState()
   {
      int sticks = 10;
      var player = Player.Machine;

      var game = new Game(sticks, player);

      Assert.That(game.NumberOfSticks, Is.EqualTo(sticks));
      Assert.That(game.Turn, Is.EqualTo(player));
   }

   [Test]
   [TestCase(0)]
   [TestCase(10)]
   public void HumanPicksUp_InvalidNumberOfSticks_ThrowsArgumentException(int sticksTaken)
   {
      var game = new Game(10, Player.Human);
      Assert.Throws<ArgumentException>(() => game.HumanMakesMove(sticksTaken));
   }

   [Test]
   [TestCase(1, 9)]
   [TestCase(3, 7)]
   [TestCase(2, 8)]
   public void HumanPicksUp_ValidNumberOfSticks_GameRemainsInCorrectState(int sticksTaken, int stickRemaining)
   {
      var game = new Game(10, Player.Human);
      game = game.HumanMakesMove(sticksTaken);

      Assert.That(game.NumberOfSticks, Is.EqualTo(stickRemaining));
      Assert.That(game.Turn, Is.EqualTo(Player.Machine));
   }
}

