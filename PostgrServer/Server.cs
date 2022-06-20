using Npgsql;
using System.Net;
using System.Net.Sockets;

namespace PostgrServer
{
    static class Server
    {
        public static NpgsqlConnection DataBaseConnection;
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

        public static void DBConnect(string login, string password)
        {
                DataBase ServerDataBase = new DataBase(login, password);
                DataBaseConnection = ServerDataBase.Connection;
        }

        public static bool CheckUserExist(string login = "qwe", string password = "sadfsd")
        {
            return true;
        }

        public static void ServerStop()
        {
            serverSocket.Stop();
            serverSocket = null;
        }
    }
}
