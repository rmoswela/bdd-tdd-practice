namespace project_two_Sticks.Core;

public class Game
{
   public int NumberOfSticks { get; }
   public Player Turn { get; }

   public Game(int numberOfSticks, Player turn)
   {
      NumberOfSticks = numberOfSticks;
      Turn = turn;

      if (numberOfSticks < 10)
      {
         throw new ArgumentException($"Number of sticks has to be >=10. You passed: {numberOfSticks}");
      }
   }

   /// <summary>
   /// Copy of constructor
   /// </summary>
   /// <param name="turn"></param>
   /// <param name="numberOfSticks"></param>
   private Game(Player turn, int numberOfSticks)
   {
      NumberOfSticks = numberOfSticks;
      Turn = turn;
   }

   public Game HumanMakesMove(int sticksTaken)
   {
      if (sticksTaken < MinToTake || sticksTaken > MaxToTake)
      {
         throw new ArgumentException($"You should take one to three sticks. You took: {sticksTaken}");
      }

      return new Game(Revert(Turn), NumberOfSticks - sticksTaken);
   }

   private Player Revert(Player p)
   {
      return p == Player.Machine ? Player.Human : Player.Machine;
   }


   public const int MinToTake = 1;
   public const int MaxToTake = 3;
}

