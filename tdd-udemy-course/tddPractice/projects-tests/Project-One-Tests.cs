namespace projects_tests;
using project_one;

[TestFixture]
public class CalculatorTests
{
   [Test]
   public void AddNumbers_ValidValues_ReturnsCorrectResult()
   {
      var cal = new Calculator();
      int result = cal.AddNumber(2, 3);

      Assert.That(result, Is.EqualTo(5));
   }
}
