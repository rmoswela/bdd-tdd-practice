namespace projectFive.DeviceTestDouble.Core;

/// <summary>
/// 
/// </summary>
public class Device
{
   private readonly IProtocol _protocol;
   private readonly TaskCompletionSource<string> _deviceSearchingTask;

   public Device(IProtocol protocol)
   {
      _protocol = protocol;
      _deviceSearchingTask = new TaskCompletionSource<string>();
   }

   public string PortName { get; private set; }

   /// <summary>
   /// 
   /// </summary>
   /// <returns></returns>
   public Task<string> Find()
   {
      _protocol.SearchFinished += Protocol_SearchingFinished;

      Task.Factory.StartNew(() => { _protocol.SearchForDevice(); });

      return _deviceSearchingTask.Task;
   }

   /// <summary>
   /// Method to retry connecting a device using a protocol a maximum of 3 times
   /// </summary>
   /// <param name="port"></param>
   /// <returns></returns>
   public bool Connect(string port)
   {
      int retryMaxNum = 3;

      for (int retry = 0; retry < retryMaxNum; retry++)
      {
         if (_protocol.Connect(port))
         {
            return true;
         }
      }

      return false;
   }

   private void Protocol_SearchingFinished(object sender, DeviceSearchingEventArgs e)
   {
      _deviceSearchingTask.SetResult(e.Portname);
   }
}


public class DeviceSearchingEventArgs
{
   public DeviceSearchingEventArgs(string portName)
   {
      Portname = portName;
   }

   public string Portname { get; }
}