using project_four_TestDouble.Core;

namespace project_four_TestDouble.Tests;

[TestFixture]
public class CustomerTests
{
   [Test]
   public void CalculateWage_HourlyPayed_ReturnsCorrectWage()
   {
      //Arrange
      const int anyEmployeeId = 1;
      DbGatewayStub gateway = new DbGatewayStub();
      gateway.SetEmployeeStats(new EmployeeStats() { PayHourly = true, HourSalary = 100, WorkingHours = 10 });
      var cust = new Customer(gateway, new LoggerDummy());
      const decimal expectedWage = 100 * 10;

      //Act
      var actual = cust.CalculateWage(anyEmployeeId);

      //Assert
      Assert.That(actual, Is.EqualTo(expectedWage).Within(0.1));
   }
}
