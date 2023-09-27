using System;

public class IPAddressInfo
{
    private byte[] ipAddress;
    private byte[] subnetMask;
    private byte[] broadcast;
    private byte[] networkId;

    public IPAddressInfo(string ipAddressWithMask)
    {
        string[] parts = ipAddressWithMask.Split('/');
        if (parts.Length != 2 || !System.Net.IPAddress.TryParse(parts[0], out var address))
        {
            throw new ArgumentException("Invalid IP address with mask format.");
        }

        ipAddress = address.GetAddressBytes();

        if (!int.TryParse(parts[1], out int maskLength) || maskLength < 0 || maskLength > 32)
        {
            throw new ArgumentException("Invalid subnet mask length.");
        }

        subnetMask = CalculateSubnetMask(maskLength);
        networkId = CalculateNetworkId();
        broadcast = CalculateBroadcastAddress();
        ParseSubnetAddress();
    }

    public byte[] IPAddress => ipAddress;
    public byte[] SubnetMask => subnetMask;
    public byte[] Broadcast => broadcast;
    public byte[] NetworkID => networkId;
    public string SubnetAddress { get; private set; }

    public string GetSubnetAddress()
    {
        byte[] subnetAddress = new byte[4];
        for (int i = 0; i < 4; i++)
        {
            subnetAddress[i] = (byte)(ipAddress[i] & subnetMask[i]);
        }

        return $"{subnetAddress[0]}.{subnetAddress[1]}.{subnetAddress[2]}.{subnetAddress[3]}";
    }

    public string GetNetworkRange()
    {
        byte[] subnetAddress = IPAddress;
        byte[] broadcastAddress = Broadcast;

        return $"{GetSubnetAddress()} - {broadcastAddress[0]}.{broadcastAddress[1]}.{broadcastAddress[2]}.{broadcastAddress[3]}";
    }

    public bool IsSameNetwork(IPAddressInfo other)
    {
        byte[] thisNetworkID = NetworkID;
        byte[] otherNetworkID = other.NetworkID;

        for (int i = 0; i < 4; i++)
        {
            if (thisNetworkID[i] != otherNetworkID[i])
            {
                return false;
            }
        }

        return true;
    }

    public byte[] CalculateSubnetMask(int maskLength)
    {
        int fullBytes = maskLength / 8;
        int remainderBits = maskLength % 8;

        byte[] mask = new byte[4];
        for (int i = 0; i < fullBytes; i++)
        {
            mask[i] = 0xFF;
        }

        if (remainderBits > 0)
        {
            mask[fullBytes] = (byte)(0xFF << (8 - remainderBits));
        }

        return mask;
    }
    public string GetNetworkID()
    {
        byte[] networkIDBytes = new byte[4];
        for (int i = 0; i < 4; i++)
        {
            networkIDBytes[i] = (byte)(ipAddress[i] & subnetMask[i]);
        }

        return $"{networkIDBytes[0]}.{networkIDBytes[1]}.{networkIDBytes[2]}.{networkIDBytes[3]}";
    }

    public byte[] CalculateNetworkId()
    {
        byte[] networkId = new byte[4];
        for (int i = 0; i < 4; i++)
        {
            networkId[i] = (byte)(ipAddress[i] & subnetMask[i]);
        }

        return networkId;
    }

    public byte[] CalculateBroadcastAddress()
    {
        byte[] broadcastAddress = new byte[4];
        for (int i = 0; i < 4; i++)
        {
            broadcastAddress[i] = (byte)(ipAddress[i] | ~subnetMask[i]);
        }

        return broadcastAddress;
    }
    public string GetBroadcastAddress()
    {
        byte[] broadcastAddressBytes = new byte[4];
        for (int i = 0; i < 4; i++)
        {
            broadcastAddressBytes[i] = (byte)(ipAddress[i] | ~subnetMask[i]);
        }

        return $"{broadcastAddressBytes[0]}.{broadcastAddressBytes[1]}.{broadcastAddressBytes[2]}.{broadcastAddressBytes[3]}";
    }
    

    private void ParseSubnetAddress()
    {
        byte[] subnetAddressBytes = new byte[4];
        for (int i = 0; i < 4; i++)
        {
            subnetAddressBytes[i] = (byte)(ipAddress[i] & subnetMask[i]);
        }

        SubnetAddress = $"{Convert.ToString(subnetAddressBytes[0], 2).PadLeft(8, '0')}.{Convert.ToString(subnetAddressBytes[1], 2).PadLeft(8, '0')}.{Convert.ToString(subnetAddressBytes[2], 2).PadLeft(8, '0')}.{Convert.ToString(subnetAddressBytes[3], 2).PadLeft(8, '0')}";
    }
}

