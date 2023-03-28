using project_four_TestDouble.Core;
using System;
namespace project_four_TestDouble.Tests
{
   //Spies record information about method calls made
   //useful for verifying method was called or called with correct parameters
   public class DbGatewaySpy : IDbGateway
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
   }
}

