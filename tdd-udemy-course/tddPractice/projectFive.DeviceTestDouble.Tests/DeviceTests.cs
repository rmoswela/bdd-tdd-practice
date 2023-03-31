using NSubstitute;
using projectFive.DeviceTestDouble.Core;

namespace projectFive.DeviceTestDouble.Tests;

[TestFixture]
public class DeviceTests
{
   [Test]
   public void Connect_OnFailure_RetryThreeTimes()
   {
      // Arrange
      var protocolProvider = Substitute.For<IProtocol>();
      var device = new Device(protocolProvider);
      protocolProvider.Connect(Arg.Any<string>()).Returns(false);

      //protocolProvider.Connect(Arg.Is("COM1")).Returns(true);
      //protocolProvider.Connect(Arg.Is<string>(x => x.StartsWith("COM1"))).Returns(true);

      // Act
      device.Connect(string.Empty);

      // Assert
      protocolProvider.Received(3).Connect(Arg.Any<string>());
   }

   [Test]
   public void Find_DeviceOnCOM1Port_ReturnsCOM1()
   {
      // Arrange
      var protocolProvider = Substitute.For<IProtocol>();
      var device = new Device(protocolProvider);
      const string portName = "COM1";

      // Act
      var task = device.Find();
      protocolProvider.SearchingFinished += Raise.Event<EventHandler<DeviceSearchingEventArgs>>
         (protocolProvider, new DeviceSearchingEventArgs(portName));

      // Assert
      Assert.That(task.Result, Is.EqualTo(portName));
   }
}
