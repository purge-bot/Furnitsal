using System.Net;
using System.Net.Sockets;

namespace TCPInteraction
{
    public static class Server
    {
        public static TcpListener serverSocket;

        public static void ServerStart(int port)
        {
            serverSocket = new TcpListener(IPAddress.Any, port);
            serverSocket.Start();
        }

        public static void ClientConnecting(out TcpClient clientSocket)
        {
                clientSocket = serverSocket.AcceptTcpClient();
        }

        public static void ServerStop()
        {
            serverSocket.Stop();
            serverSocket = null;
        }
    }
}
