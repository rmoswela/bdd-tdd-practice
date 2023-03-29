using project_four_TestDouble.Core;
using System;
namespace project_four_TestDouble.Tests
{
   //simplified version of real dependency which mostly has a subset of the real functionality
   //not the whole of it
   public class DbGatewayFake : IDbGateway
  {
      private Dictionary<int, EmployeeStats> _fakeDatabase = new Dictionary<int, EmployeeStats>()
      {
         {1, new EmployeeStats() {PayHourly = true, WorkingHours = 5, HourSalary = 10} },
         {2, new EmployeeStats() {PayHourly = false, MonthSalary = 500} },
         {3, new EmployeeStats() {PayHourly = true, WorkingHours = 8, HourSalary = 100} }
      };

      public EmployeeStats GetEmployeeStats(int employeeId)
      {
         return _fakeDatabase[employeeId];
      }
  }
}

