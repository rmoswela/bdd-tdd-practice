using project_four_TestDouble.Core;
using System;
namespace project_four_TestDouble.Tests
{
   //Stubs provide pre determined responses for method calls
   //And will always return the same results regardless of input or how is called
   //It also cannot fail itself
   public class DbGatewayStub : IDbGateway
   {
      private EmployeeStats _employeeStats;

      public EmployeeStats GetEmployeeStats(int userId)
      {
         return _employeeStats;
      }

      public void SetEmployeeStats(EmployeeStats es)
      {
         _employeeStats = es;
      }

      public bool Connected { get; }
  }
}

