using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        byte[] networkID = ipInfo.CalculateNetworkId();

        // Assert
        Assert.AreEqual(new byte[] { 192, 168, 1, 0 }, networkID);
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
}
