using NetworkInitialiser;
using System.Net;

namespace ServerModule;
public class Server
{
    NetworkConfig _networkConfig;

    public Server()
    {
        _networkConfig = new NetworkConfig(10_000);
        _networkConfig.InitLocalHostServer().Wait();
        
        Console.WriteLine($"SERVER CONFIGURED: {_networkConfig.Port}, {_networkConfig.IpAddress}, {_networkConfig.IpHostInfo}");
    }      

    
}
