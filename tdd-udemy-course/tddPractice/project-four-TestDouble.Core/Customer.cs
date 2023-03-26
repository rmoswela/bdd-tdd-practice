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
      EmployeeStats employeeStats = _gateway.GetEmployeeStats(employeeId);

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