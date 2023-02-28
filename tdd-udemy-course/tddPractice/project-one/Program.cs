namespace project_one
{
   class Program
   {
      static void Main(string[] args)
      {
         string empty = NaiveCanonicalizer.GetCanonicalForm("");
         Console.WriteLine(empty=="");
         empty = NaiveCanonicalizer.GetCanonicalForm(" ");
         Console.WriteLine(empty=="");
         empty = NaiveCanonicalizer.GetCanonicalForm("      ");
         Console.WriteLine(empty=="");

         Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm(" I am      so    Hood DJ Khaled   "));
         Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm("Hood    I     am   so   DJ Khaled    "));

         Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm("I am so hood DJ Khaled"));
         Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm("Hood I am so DJ Khaled"));
         Console.WriteLine(NaiveCanonicalizer.GetCanonicalForm("DJ Khaled Hood I am so"));
         Console.Read();
      }
   }
}