using System;
namespace project_four_TestDouble.Core
{
  public interface IDbGateway
  {
      EmployeeStats GetEmployeeStats(int userId);
  }
}

