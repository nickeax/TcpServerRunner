using Entities.Models;
using System.Net;

namespace NetworkInitialiser;
public class NetworkConfig
{
    TcpConfiguration _tcpConfiguration;
    public NetworkConfig()
    {
        _tcpConfiguration = new TcpConfiguration();
    }
    // Constructor with only PORT number
    public NetworkConfig(int port)
    {
        _tcpConfiguration.Port = port;
    }
    // Constructor with PORT number and HostName
    public NetworkConfig(int port, string hostName)
    {
        Port = port;
        InitServer(hostName).Wait();
    }

    public NetworkConfig(IPHostEntry ipHostInfo, IPAddress ipAddress, IPEndPoint localEndPoint, int port)
    {
        _tcpConfiguration.IpHostInfo = ipHostInfo;
        _tcpConfiguration.IpAddress = ipAddress;
        _tcpConfiguration.LocalEndPoint = localEndPoint;
        _tcpConfiguration.Port = port;
    }
    public IPHostEntry IpHostInfo
    {
        get => _tcpConfiguration.IpHostInfo;
    }
    public IPAddress IpAddress
    {
        get => _tcpConfiguration.IpAddress;
    }
    public IPEndPoint LocalEndPoint { get => _tcpConfiguration.LocalEndPoint; }

    public int Port { get; set; }

    /// <summary>
    /// Initialize the server with local machine IP address
    /// </summary>
    /// <returns></returns>
    public async Task InitLocalHostServer()
    {
        string hostName = Dns.GetHostName();
        _tcpConfiguration.IpHostInfo = await Dns.GetHostEntryAsync(hostName);
        _tcpConfiguration.IpAddress = IpHostInfo.AddressList[0];
        _tcpConfiguration.LocalEndPoint = new IPEndPoint(IpAddress, Port);
    }

    /// <summary>
    /// Initialize the server with the given IP address
    /// </summary>
    /// <returns></returns>
    public async Task InitServer(string hostName)
    {
        IpHostInfo = await Dns.GetHostEntryAsync(hostName);
        IpAddress = IpHostInfo.AddressList[0];
        LocalEndPoint = new IPEndPoint(IpAddress, Port);
    }
}
