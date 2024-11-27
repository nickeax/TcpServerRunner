using System.Net;

namespace Entities.Models;
public class TcpConfiguration
{
    public TcpConfiguration()
    {
    }

    public TcpConfiguration(IPHostEntry ipHostInfo, IPAddress ipAddress, IPEndPoint localEndPoint, int port)
    {
        IpHostInfo = ipHostInfo;
        IpAddress = ipAddress;
        LocalEndPoint = localEndPoint;
        Port = port;
    }

    public IPHostEntry IpHostInfo { get; set; }
    public IPAddress IpAddress { get; set; }
    public IPEndPoint LocalEndPoint { get; set; }
    public int Port { get; set; }
}
