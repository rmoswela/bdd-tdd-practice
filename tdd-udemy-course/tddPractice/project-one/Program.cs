using System.Text;

namespace project_one
{
   class Program
   {
      private static Game game = new Game();

      static void Main(string[] args)
      {

         //string empty = NaiveCanonicalizer.GetCanonicalForm("");
         //Console.WriteLine(empty=="");
         //empty = NaiveCanonicalizer.GetCanonicalForm(" ");
         //Console.WriteLine(empty=="");
         //empty = NaiveCanonicalizer.GetCanonicalForm("      ");
         //Console.WriteLine(empty=="");

         //Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm(" I am      so    Hood DJ Khaled   "));
         //Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm("Hood    I     am   so   DJ Khaled    "));

         //Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm("I am so hood DJ Khaled"));
         //Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm("Hood I am so DJ Khaled"));
         //Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm("DJ Khaled Hood I am so"));
         //Console.Read();

         Console.WriteLine(GetPrintableState());

         while (game.GetWinner() == Winner.GameIsUnfinished)
         {
            int index = int.Parse(Console.ReadLine());
            game.MakeMove(index);

            Console.WriteLine();
            Console.WriteLine(GetPrintableState());
         }

         Console.WriteLine($"Result: {game.GetWinner()}");
         Console.ReadLine();
      }

      private static string GetPrintableState()
      {
         var sb = new StringBuilder();

         for (int loop = 1; loop <= 7; loop += 3)
         {
            sb.AppendLine("      |      |      ")
               .AppendLine(
               $"    {GetPrintableChar(loop)}      |     {GetPrintableChar(loop + 1)}     |      {GetPrintableChar(loop + 2)}    ")
               .AppendLine("______|______|______|");
         }

         return sb.ToString();
      }

      private static string GetPrintableChar(int index)
      {
         State state = game.GetState(index);
         if (state == State.Unset)
            return index.ToString();
         return state == State.Cross ? "X" : "O";
      }
   }
}