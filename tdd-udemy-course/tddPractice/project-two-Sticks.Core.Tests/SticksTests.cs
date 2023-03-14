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

   [Test]
   public void HumanMakesMove_WhenItsTheComputerTurn_ThrowInvalidOperationException()
   {
      var game = new Game(10, Player.Machine);

      Assert.Throws<InvalidOperationException>(() => game.HumanMakesMove(1));
   }

   [Test]
   [TestCase(1, 9)]
   [TestCase(3, 7)]
   [TestCase(2, 8)]
   public void MachinePicksUp_ValidNumberOfSticks_GameRemainsInCorrectState(int sticksTaken, int stickRemaining)
   {
      var gen = new PredictableGenerator();
      gen.SetNumber(sticksTaken);
      int taken = 0;

      var game = new Game(10, Player.Machine, gen);
      game.MachineMoved += (s, args) => taken = args.SticksTaken;
      game = game.MachineMakesMove();

      Assert.That(game.NumberOfSticks, Is.EqualTo(stickRemaining));
      Assert.That(sticksTaken, Is.EqualTo(taken));
      Assert.That(game.Turn, Is.EqualTo(Player.Human));
   }

   [Test]
   public void Constructor_WithNullGenerator_ThrowsArgumentNullException()
   {
      Assert.Throws<ArgumentNullException>(() => new Game(10, Player.Machine, null));
   }
}

public class PredictableGenerator : ICanGenerateNumbers
{
   private int _number;

   public int Next(int min, int max)
   {
      return _number;
   }

   public void SetNumber(int num)
   {
      _number = num;
   }
}

