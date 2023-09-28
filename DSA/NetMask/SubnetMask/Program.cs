


Console.WriteLine("Enter IP address with mask: e.g. 123.123.123.123/23");
string ipAddressWithMask = Console.ReadLine();
IPAddressInfo ipInfo = new IPAddressInfo(ipAddressWithMask);

Console.WriteLine($"Subnet Address: {ipInfo.GetSubnetAddress()}");
Console.WriteLine($"Network ID: {string.Join(".", ipInfo.NetworkID)}");
Console.WriteLine($"Network Range: {ipInfo.GetNetworkRange()}");
string subnetAddress = ipInfo.SubnetAddress;
Console.WriteLine($"Subnet Address: {subnetAddress}"); // Output: Subnet Address: 11000000.10101000.00000001.00000000
        
        




Console.WriteLine("Enter IP address to check for the same network: 123.123.123.123/23");
string otherIpAddressWithMask = Console.ReadLine(); 
IPAddressInfo otherIpInfo = new IPAddressInfo(otherIpAddressWithMask);

Console.WriteLine($"Is Same Network as {otherIpAddressWithMask}: {ipInfo.IsSameNetwork(otherIpInfo)}");
 
