using System;

namespace Calculator
{
    public class SalaryCalculator
    {
        //refactored so it can be visible to other methods
        const int HoursInYear = 2080;

        public decimal GetAnnualSalary(decimal hourlyWage) => hourlyWage * HoursInYear;

        public decimal GetHourlySalary(decimal annualSalary) => annualSalary / HoursInYear;
    }
}
