using System;
namespace projectFive.DeviceTestDouble.Core
{
  public interface IProtocol
  {
      Action<object, DeviceSearchingEventArgs> SearchFinished { get; set; }
      bool Connect(string port);
      Device SearchForDevice();
  }
}

