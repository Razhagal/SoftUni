using SIS.WebServer;
using SIS.WebServer.Routing;

namespace SIS.Demo
{
    public class Launcher
    {
        static void Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            serverRoutingTable.Add(HTTP.Enums.HttpRequestMethod.Get, "/", request => new HomeController().Index(request));

            Server server = new Server(8000, serverRoutingTable);
            server.Run();
        }
    }
}
