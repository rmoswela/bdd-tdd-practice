namespace project_four_TestDouble.Core;
public class Customer
{
   private readonly IDbGateway _gateway;
   private readonly ILogger _logger;

   public Customer(IDbGateway gateway, ILogger logger)
   {
      _gateway = gateway;
      _logger = logger;
   }

   public decimal CalculateWage(int employeeId)
   {
      //EmployeeStats exceptionEmployee = null;
      //try
      //{
      //   exceptionEmployee = _gateway.GetEmployeeStats(employeeId);
      //}
      //catch (Exception ex)
      //{
      //   return 0;
      //}

      EmployeeStats employeeStats = _gateway.GetEmployeeStats(employeeId);

      //if (!_gateway.Connected)
      //{
      //   return 0;
      //}

      decimal wage;
      if (employeeStats.PayHourly)
      {
         wage = employeeStats.WorkingHours * employeeStats.HourSalary;
      }
      else
      {
         wage = employeeStats.MonthSalary;
      }
      _logger.Info($"Customer ID= {employeeId}, Wage: {wage}");

      return wage;
   }
}