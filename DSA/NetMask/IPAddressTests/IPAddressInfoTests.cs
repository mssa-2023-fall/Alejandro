using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IPAddressTests
{
    [TestClass]
    public class IPAddressInfoTests
    {
        [TestMethod]
        public void TestIPAddressInfoCreation()
        {
            // Arrange
            string ipAddressWithMask = "192.168.1.100/24";

            // Act
            IPAddressInfo ipInfo = new IPAddressInfo(ipAddressWithMask);

            // Assert
            Assert.IsNotNull(ipInfo);
            CollectionAssert.AreEqual(new byte[] { 192, 168, 1, 100 }, ipInfo.IPAddress);
            CollectionAssert.AreEqual(new byte[] { 255, 255, 255, 0 }, ipInfo.SubnetMask);
        }

        [TestMethod]
        public void TestGetSubnetAddress()
        {
            // Arrange
            string ipAddressWithMask = "192.168.1.100/24";
            IPAddressInfo ipInfo = new IPAddressInfo(ipAddressWithMask);

            // Act
            string subnetAddress = ipInfo.GetSubnetAddress();

            // Assert
            Assert.AreEqual("192.168.1.0", subnetAddress);
        }

        [TestMethod]
        public void TestIsSameNetwork()
        {
            // Arrange
            string ipAddressWithMask1 = "192.168.1.100/24";
            string ipAddressWithMask2 = "192.168.1.50/24";
            string ipAddressWithMask3 = "10.0.0.100/24";

            IPAddressInfo ipInfo1 = new IPAddressInfo(ipAddressWithMask1);
            IPAddressInfo ipInfo2 = new IPAddressInfo(ipAddressWithMask2);
            IPAddressInfo ipInfo3 = new IPAddressInfo(ipAddressWithMask3);

            // Act & Assert
            Assert.IsTrue(ipInfo1.IsSameNetwork(ipInfo2));
            Assert.IsFalse(ipInfo1.IsSameNetwork(ipInfo3));
        }

        [TestMethod]
        public void TestGetNetworkID()
        {
            // Arrange
            string ipAddressWithMask = "192.168.1.100/24";
            IPAddressInfo ipInfo = new IPAddressInfo(ipAddressWithMask);

            // Act
            string networkID = ipInfo.GetNetworkID();

            // Assert
            Assert.AreEqual("192.168.1.0", networkID);
        }

        [TestMethod]
        public void TestGetNetworkRange()
        {
            // Arrange
            string ipAddressWithMask = "192.168.1.100/24";
            IPAddressInfo ipInfo = new IPAddressInfo(ipAddressWithMask);

            // Act
            string networkRange = ipInfo.GetNetworkRange();

            // Assert
            Assert.AreEqual("192.168.1.0 - 192.168.1.255", networkRange);
        }

        [TestMethod]
        public void TestIsSameNetwork_SameIPAddresses()
        {
            // Arrange
            string ipAddressWithMask1 = "192.168.1.100/24";
            string ipAddressWithMask2 = "192.168.1.100/24";

            IPAddressInfo ipInfo1 = new IPAddressInfo(ipAddressWithMask1);
            IPAddressInfo ipInfo2 = new IPAddressInfo(ipAddressWithMask2);

            // Act & Assert
            Assert.IsTrue(ipInfo1.IsSameNetwork(ipInfo2));
        }
        [TestMethod]
        public void TestGetBroadcastAddress()
        {
            // Arrange
            string ipAddressWithMask = "192.168.1.100/24";
            IPAddressInfo ipInfo = new IPAddressInfo(ipAddressWithMask);

            // Act
            string broadcastAddress = ipInfo.GetBroadcastAddress();

            // Assert
            Assert.AreEqual("192.168.1.255", broadcastAddress);
        }
        [TestMethod]
        public void TestCalculateSubnetMask()
        {
            string ipAddressWithMask = "192.168.1.100/24";

            // Act
            IPAddressInfo ipInfo = new IPAddressInfo(ipAddressWithMask);
            // Arrange
            int maskLength = 24; // /24 subnet
            byte[] expectedSubnetMask = new byte[] { 255, 255, 255, 0 };

            // Act
            byte[] calculatedSubnetMask = ipInfo.CalculateSubnetMask(maskLength);

            // Assert
            CollectionAssert.AreEqual(expectedSubnetMask, calculatedSubnetMask);
        }
        [TestMethod]
        public void TestCalculateNetworkID()
        {
            string ipAddressWithMask = "192.168.1.100/24";

            // Act
            IPAddressInfo ipInfo = new IPAddressInfo(ipAddressWithMask);
            // Arrange
            byte[] ipAddressBytes = new byte[] { 192, 168, 1, 100 };
            byte[] subnetMaskBytes = new byte[] { 255, 255, 255, 0 };
            byte[] expectedNetworkIDBytes = new byte[] { 192, 168, 1, 0 };

            // Act
            byte[] calculatedNetworkIDBytes = ipInfo.CalculateNetworkId();

            // Assert
            CollectionAssert.AreEqual(expectedNetworkIDBytes, calculatedNetworkIDBytes);
        }

        [TestMethod]
        public void TestCalculateBroadcastAddress()
        {
            string ipAddressWithMask = "192.168.1.100/24";

            // Act
            IPAddressInfo ipInfo = new IPAddressInfo(ipAddressWithMask);
            // Arrange
            byte[] ipAddressBytes = new byte[] { 192, 168, 1, 100 };
            byte[] subnetMaskBytes = new byte[] { 255, 255, 255, 0 };
            byte[] expectedBroadcastAddressBytes = new byte[] { 192, 168, 1, 255 };

            // Act
            byte[] calculatedBroadcastAddressBytes = ipInfo.CalculateBroadcastAddress();

            // Assert
            CollectionAssert.AreEqual(expectedBroadcastAddressBytes, calculatedBroadcastAddressBytes);
        }

        [TestMethod]
        public void TestParseSubnetAddress()
        {
            // Arrange
            string ipAddressWithMask = "192.168.1.100/24";
            IPAddressInfo ipInfo = new IPAddressInfo(ipAddressWithMask);

            // Act
            string subnetAddress = ipInfo.SubnetAddress;

            // Assert
            Assert.AreEqual("11000000.10101000.00000001.00000000", subnetAddress);
        }

    }

}