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


}

