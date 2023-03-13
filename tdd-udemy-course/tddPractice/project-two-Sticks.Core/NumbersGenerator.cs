namespace project_two_Sticks.Core
{
   public class NumbersGenerator : ICanGenerateNumbers
   {
      private readonly Random _random = new Random();
      public int Next(int min, int max)
      {
         return _random.Next(min, max);
      }
   }
}

