namespace project_two_Sticks.Core;

public class Game
{
   private readonly ICanGenerateNumbers _generator;
   public int NumberOfSticks { get; }
   public Player Turn { get; }

   public Game(int numberOfSticks, Player turn):this(numberOfSticks, turn, new NumbersGenerator())
   { }

   public Game(int numberOfSticks, Player turn, ICanGenerateNumbers generateNumbers)
   {
      if (generateNumbers == null)
         throw new ArgumentNullException(nameof(generateNumbers));

      if (numberOfSticks < 10)
      {
         throw new ArgumentException($"Number of sticks has to be >=10. You passed: {numberOfSticks}");
      }
      _generator = generateNumbers;
      NumberOfSticks = numberOfSticks;
      Turn = turn;
   }

   /// <summary>
   /// Copy of constructor
   /// </summary>
   /// <param name="turn"></param>
   /// <param name="numberOfSticks"></param>
   private Game(Player turn, int numberOfSticks, ICanGenerateNumbers generateNumbers, EventHandler<Move> machineMoved)
   {
      NumberOfSticks = numberOfSticks;
      Turn = turn;
      _generator = generateNumbers;
      MachineMoved = machineMoved;
   }

   public Game HumanMakesMove(int sticksTaken)
   {
      if (Turn == Player.Machine)
      {
         throw new InvalidOperationException("Its the machine's turn to make a move!");
      }

      if (sticksTaken < MinToTake || sticksTaken > MaxToTake)
      {
         throw new ArgumentException($"You should take one to three sticks. You took: {sticksTaken}");
      }

      if (sticksTaken > NumberOfSticks)
      {
         throw new ArgumentException($"You took more sticks than ones remaining in the game!");
      }

      return new Game(Revert(Turn), NumberOfSticks - sticksTaken, _generator, MachineMoved);
   }

   public Game MachineMakesMove()
   {
      int stickTaken = _generator.Next(MinToTake, MaxToTake);
      int stickRemains = NumberOfSticks - stickTaken;
      MachineMoved?.Invoke(this, new Move(stickTaken, stickRemains));

      return new Game(Revert(Turn), stickRemains, _generator, MachineMoved);
   }

   public bool IsGameOver()
   {
      return NumberOfSticks <= 0;
   }

   private Player Revert(Player p)
   {
      return p == Player.Machine ? Player.Human : Player.Machine;
   }


   public const int MinToTake = 1;
   public const int MaxToTake = 3;
   public event EventHandler<Move> MachineMoved;
}


