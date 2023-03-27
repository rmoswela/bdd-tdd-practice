using project_four_TestDouble.Core;
using System;
namespace project_four_TestDouble.Tests
{
   //Dummies test double generally are added to methods
   //which we want to do nothing or return null for ref types or zero for values
   //basically no logic
  public class LoggerDummy : ILogger
  {
      public void Info(string message)
      {
         //Do nothing
      }
  }
}

