using System;
namespace projectFive.DeviceTestDouble.Core
{
  public interface IProtocol
  {
      event EventHandler<DeviceSearchingEventArgs> SearchingFinished;
      bool Connect(string port);
      Device SearchForDevice();
  }
}

