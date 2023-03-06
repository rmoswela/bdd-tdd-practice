using System;
namespace project_one
{
   /**
    * This is a test class used to demostrate why we need to write test
    */
   public class NaiveCanonicalizer
   {
      public static string GetCanonicalForm(string searchTerm)
      {
         if (searchTerm == null)
            throw new ArgumentException("searchTerm");

         return searchTerm
            .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.ToUpper())
            .OrderBy(x=>x)
            .Aggregate("",(x, y) => x + " " + y)
            .Trim();
      }
   }

   public class Calculator
   {
      public int AddNumber(int x, int y)
      {
         return x + y;
      }
   }

   public class Fibonacci
   {
      public int GetFibonacci(int index)
      {
         if (index == 0)
         {
            return 0;
         }
         if (index == 1)
         {
            return 1;
         }
         return GetFibonacci(index - 1) + GetFibonacci(index - 2);
      }
   }

   public class FizzBuzz
   {
      public string GenerateFizzBuzz(int value)
      {
         if (value % 3 == 0 && value % 5 == 0)
            return "FizzBuzz";
         if (value % 3 == 0)
            return "Fizz";
         if (value % 5 == 0)
            return "Buzz";
         return "";
      }
   }

   public class RomanNumeralTranslation
   {
      private Dictionary<char, int> romanNumMap = new Dictionary<char, int>()
      {
         {'I',1 },
         {'V',5 },
         {'X',10 },
         {'L',50 },
         {'C',100 },
         {'D',500 },
         {'M',1000 },
      };

      public int GetNormalNumber(string romanNumeral)
      {
         int result = 0;
         for(int loop = 0; loop < romanNumeral.Length; loop++)
         {
            if (loop + 1 < romanNumeral.Length && isSubtractive(romanNumeral[loop], romanNumeral[loop + 1]))
            {
               result -= romanNumMap[romanNumeral[loop]];
            }
            else
            {
               result += romanNumMap[romanNumeral[loop]];
            }
         }
         return result;
      }

      private bool isSubtractive(char x, char y)
      {
         return romanNumMap[x] < romanNumMap[y];
      }
   }

   public class UpdateableSpin
   {
      private readonly object lockObj = new object();
      private bool shouldWait = true;
      private long executionStartingTime;

      public bool Wait(TimeSpan timeOut, int spinDuration = 0)
      {
         UpdateTimeout();
         while (true)
         {
            lock (lockObj)
            {
               if (!shouldWait)
                  return true;
               if (DateTime.UtcNow.Ticks - executionStartingTime > timeOut.Ticks)
                  return false;
            }
            Thread.Sleep(spinDuration);
         }
      }

      public void Set()
      {
         lock (lockObj)
         {
            shouldWait = false;
         }
      }

      public void UpdateTimeout()
      {
         lock (lockObj)
         {
            executionStartingTime = DateTime.UtcNow.Ticks;
         }
      }
   }

   enum State
   {
      Cross,
      Zero,
      Unset
   }

   public class Game
   {
      private readonly State[] _board = new State[9];
      public int MovesCounter { get; private set; }

      public Game()
      {
         for (int index = 0; index < _board.Length; index++)
         {
            _board[index] = State.Unset;
         }
      }

      public void MakeMove(int index)
      {
         if (index < 1 || index > 9)
            throw new ArgumentOutOfRangeException();

         if (GetState(index) != State.Unset)
            throw new InvalidOperationException();

         _board[index - 1] = MovesCounter % 2 == 0 ? State.Cross : State.Zero;

         MovesCounter++;
      }

      private State GetState(int index)
      {
         return _board[index - 1];
      }
   }
}

