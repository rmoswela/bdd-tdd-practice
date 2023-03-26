using System;
namespace project_four_TestDouble.Core
{
  internal class Logger : ILogger
  {
      public void Info(string message)
      {
         File.WriteAllText(@"/var/folders/sd/7wcc2d0s2j560w3s287cnycc0000gn/T/log.txt", message);
      }
  }
}

