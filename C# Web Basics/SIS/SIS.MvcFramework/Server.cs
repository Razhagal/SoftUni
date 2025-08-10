using SIS.HTTP.Common;
using SIS.HTTP.Sessions;
using SIS.MvcFramework.Routing;

using System.Net;
using System.Net.Sockets;

namespace SIS.MvcFramework
{
    public class Server
    {
        private const string LocalhostIpAddress = "127.0.0.1";

        private readonly int port;
        private readonly TcpListener listener;
        private readonly IServerRoutingTable serverRoutingTable;
        private readonly IHttpSessionStorage httpSessionStorage;

        private bool isRunning;

        public Server(int port, IServerRoutingTable serverRoutingTable, IHttpSessionStorage httpSessionStorage)
        {
            CoreValidator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));
            CoreValidator.ThrowIfNull(httpSessionStorage, nameof(httpSessionStorage));

            this.port = port;
            this.serverRoutingTable = serverRoutingTable;
            this.httpSessionStorage = httpSessionStorage;

            this.listener = new TcpListener(IPAddress.Parse(LocalhostIpAddress), port);
        }

        public void Run()
        {
            this.listener.Start();
            this.isRunning = true;

            Console.WriteLine($"Server started at http://{LocalhostIpAddress}:{this.port}");

            while (this.isRunning)
            {
                Console.WriteLine("Waiting for client...");

                var client = this.listener.AcceptSocket();
                Task.Run(() => this.ListenAsync(client));
            }
        }

        public async Task ListenAsync(Socket client)
        {
            ConnectionHandler connectionHandler = new ConnectionHandler(client, this.serverRoutingTable, this.httpSessionStorage);
            await connectionHandler.ProcessRequestAsync();
        }
    }
}
