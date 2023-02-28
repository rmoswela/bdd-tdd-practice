using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polymorphism;

namespace PolymorphismTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateWeeklySalaryForEmployeeTest_70wage_55hours_Returns2800dollars()
        {
            //Arrange
            int weeklyHours = 55;
            int wage = 70;
            int salary = 40 * wage;

            Employee e = new Employee();

            string expectedResponse = string.Format("\nThis ANGRY EMPLOYEE worked {0} hrs. " +
                              "Paid for 40 hrs at $ {1}" +
                              "/hr = ${2} \n", weeklyHours, wage, salary);

            //Act
            string response = e.CalculateWeeklySalary(weeklyHours, wage);

            //Assert
            Assert.AreEqual(expectedResponse, response);
        }

        [TestMethod]
        public void CalculateWeeklySalaryForContractorTest_70wage_55hours_Returns3850dollars()
        {
            //Arrange
            int weeklyHours = 55;
            int wage = 70;
            int salary = weeklyHours * wage;

            Employee c = new Contractor();

            string expectedResponse = string.Format("\nThis HAPPY CONTRACTOR worked {0} hrs. " +
                              "Paid for {0} hrs at $ {1}" +
                              "/hr = ${2} ", weeklyHours, wage, salary);

            //Act
            string response = c.CalculateWeeklySalary(weeklyHours, wage);

            //Assert
            Assert.AreEqual(expectedResponse, response);
        }

        [TestMethod]
        public void CalculateWeeklySalaryForEmployeeTest_70wage_55hours_DoesNotReturnCorrectString()
        {
            //Arrange
            int weeklyHours = 55;
            int wage = 70;
            int salary = 40 * wage;

            Employee e = new Employee();

            string expectedResponse = string.Format("\nfor employee: This ANGRY EMPLOYEE worked {0} hrs. " +
                              "Paid for 40 hrs at $ {1}" +
                              "/hr = ${2} \n", weeklyHours, wage, salary);

            //Act
            string response = e.CalculateWeeklySalary(weeklyHours, wage);

            //Assert
            Assert.AreNotEqual(expectedResponse, response);
        }

        [TestMethod]
        public void CalculateWeeklySalaryForContractorTest_70wage_55hours_DoesNotReturnCorrectString()
        {
            //Arrange
            int weeklyHours = 55;
            int wage = 70;
            int salary = weeklyHours * wage;

            Contractor c = new Contractor();
            string expectedResponse = string.Format("\nfor contractor: This HAPPY CONTRACTOR worked {0} hrs. " +
                              "Paid for {0} hrs at $ {1}" +
                              "/hr = ${2} ", weeklyHours, wage, salary);

            //Act
            string response = c.CalculateWeeklySalary(weeklyHours, wage);

            //Assert
            Assert.AreNotEqual(expectedResponse, response);
        }

    }
}
