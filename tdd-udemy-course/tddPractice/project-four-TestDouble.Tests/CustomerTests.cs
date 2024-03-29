﻿using NSubstitute;
using NSubstitute.ExceptionExtensions;
using project_four_TestDouble.Core;

namespace project_four_TestDouble.Tests;

[TestFixture]
public class CustomerTestsWithMockingFramework
{
   [Test]
   public void CalculateWage_HourlyPayed_ReturnsCorrectWage()
   {
      //Arrange
      const decimal expectedWage = 100 * 10;
      var gateway = Substitute.For<IDbGateway>();

      var employeeStats = new EmployeeStats() { PayHourly = true, HourSalary = 100, WorkingHours = 10 };
      gateway.GetEmployeeStats(Arg.Any<int>()).ReturnsForAnyArgs(employeeStats);
      gateway.Connected.Returns(true);

      var cust = new Customer(gateway, Substitute.For<ILogger>());

      //Act
      var actual = cust.CalculateWage(Arg.Any<int>());

      //Assert
      Assert.That(actual, Is.EqualTo(expectedWage).Within(0.1));
   }

   [Test]
   public void CalculateWage_ThrowsException_Return0()
   {
      //Arrage
      var gateway = Substitute.For<IDbGateway>();
      gateway.GetEmployeeStats(Arg.Any<int>()).Throws(new InvalidOperationException());
      var cust = new Customer(gateway, Substitute.For<ILogger>());

      //Act
      decimal actual = cust.CalculateWage(Arg.Any<int>());

      //Assert
      Assert.That(actual, Is.EqualTo(0));
   }
}

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

   [Test]
   public void CalculateWage_CheckIfTheGetEmployeeStatsMethodIsCalled_ReturnCorrectEmployeeIdSetInTheMethod()
   {
      //Arrange
      const int employeeId = 1;
      var gateway = new DbGatewaySpy();
      gateway.SetEmployeeStats(new EmployeeStats() { PayHourly = true, HourSalary = 100, WorkingHours = 10 });
      var cust = new Customer(gateway, new LoggerDummy());

      //Act
      cust.CalculateWage(employeeId);

      //Assert
      Assert.That(gateway.EmployeeId, Is.EqualTo(employeeId));
   }

   [Test]
   public void CalculateWage_PassesCorrectEmployeeId()
   {
      //Arrange
      const int employeeId = 1;
      var gateway = new DbGatewayMock();
      gateway.SetEmployeeStats(new EmployeeStats());
      var cust = new Customer(gateway, new LoggerDummy());

      //Act
      cust.CalculateWage(employeeId);

      //Assert
      Assert.IsTrue(gateway.VerifyCalledWithProperId(employeeId));
   }

   [Test]
   public void CalculateWage_MonthlyPayed_ReturnsCorrectWageFromFakeDB()
   {
      //Arrange
      const int employeeId = 2;
      var gateway = new DbGatewayFake();

      var cust = new Customer(gateway, new LoggerDummy());
      const decimal expectedWage = 500;

      //Act
      var actual = cust.CalculateWage(employeeId);

      //Assert
      Assert.That(actual, Is.EqualTo(expectedWage));
   }
}
