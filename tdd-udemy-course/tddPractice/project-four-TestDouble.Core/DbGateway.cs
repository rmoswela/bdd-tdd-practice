using System;
namespace project_four_TestDouble.Core
{
  public class DbGateway : IDbGateway
  {
      //Call Database to get employee stats
      public EmployeeStats GetEmployeeStats(int employeeId)
      {
         return new EmployeeStats();
      }
   }
}

