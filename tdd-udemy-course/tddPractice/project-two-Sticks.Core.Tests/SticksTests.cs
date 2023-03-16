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

   [Test]
   [TestCase(1, false)]
   [TestCase(2, true)]
   public void IsGameOver_WhenSticksAreFinished_ReturnsCorrectResults(int takewhenTwosticksInGame, bool isOver)
   {
      var game = GameRemainingWith2StickAndItsHumanTurn();

      game = game.HumanMakesMove(takewhenTwosticksInGame);
      bool result = game.IsGameOver();

      Assert.That(result, Is.EqualTo(isOver));
   }

   [Test]
   public void HumanMakesMove_TakeMoreSticksThanInTheGame_ThrowsArgumentException()
   {
      var game = GameRemainingWith2StickAndItsHumanTurn();
      Assert.Throws<ArgumentException>(() => game.HumanMakesMove(Game.MaxToTake));
   }

   [Test]
   public void MachineMakesMove_WhenItsTheHumanTurn_ThrowInvalidOperationException()
   {
      var game = new Game(10, Player.Human);

      Assert.Throws<InvalidOperationException>(() => game.MachineMakesMove());
   }

   [Test]
   public void HumanMakesMove_TakesTheLast2Sticks_HumanLoses()
   {
      var winner = Player.Human;

      var game = GameRemainingWith2StickAndItsHumanTurn();
      game.GameOver += (sender, player) => winner = player;

      game = game.HumanMakesMove(2);

      Assert.That(game.IsGameOver, Is.EqualTo(true));
      Assert.That(winner, Is.EqualTo(Player.Machine));
   }

   private static Game GameRemainingWith2StickAndItsHumanTurn()
   {
      var gen = new PredictableGenerator();
      gen.SetNumber(Game.MinToTake);

      var game = new Game(10, Player.Human, gen);
      game = game.HumanMakesMove(Game.MaxToTake); //7
      game = game.MachineMakesMove(); //6
      game = game.HumanMakesMove(Game.MaxToTake); //3
      game = game.MachineMakesMove(); //2

      return game;
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

