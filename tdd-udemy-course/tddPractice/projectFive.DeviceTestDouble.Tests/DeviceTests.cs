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
}
