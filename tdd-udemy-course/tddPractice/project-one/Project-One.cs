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
}

