using project_four_TestDouble.Core;
using System;
namespace project_four_TestDouble.Tests
{
   //simulate behaviour of dependency with pre determined responses to method calls
   //along with expected arguments and in expected sequence
   //none of the expectation met iit throws exception before test completes
  public class DbGatewayMock : IDbGateway
   {
      private EmployeeStats _employeeStats;
      public int EmployeeId { get; private set; }

      public EmployeeStats GetEmployeeStats(int employeeId)
      {
         EmployeeId = employeeId;
         return _employeeStats;
      }

      public void SetEmployeeStats(EmployeeStats es)
      {
         _employeeStats = es;
      }

      public bool VerifyCalledWithProperId(int employeeId)
      {
         return EmployeeId == employeeId;
      }
   }
}

