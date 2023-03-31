﻿using System;
namespace projectFive.DeviceTestDouble.Core
{
   public class Protocol : IProtocol
   {
      public bool Connect(string port)
      {
         return true;
      }

      public Device SearchForDevice()
      {
         return new Device(new Protocol());
      }

      public Action<object, DeviceSearchingEventArgs> SearchFinished { get; set; }
   }
}

