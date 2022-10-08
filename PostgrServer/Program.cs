using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using DbQuery;
using PostgrServer.DbCommander;

namespace PostgrServer
{
    class Program
    {
        public static DataBase dataBaseServer;
        public static Dictionary<string, User> Users = new Dictionary<string, User>();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Подключение к базе данных");
                Console.WriteLine("Введите логин");
                string loginDB = "postgres";// Console.ReadLine().ToLower().Trim();

                Console.WriteLine("Введите пароль");
                string passwordDB = "wxkmjdt76";//Console.ReadLine().ToLower().Trim();

                try
                {
                    dataBaseServer = new DataBase(loginDB, passwordDB);
                    Console.WriteLine("Подключено к БД");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                while (Server.serverSocket == null)
                {
                    Console.WriteLine("Включение сервера");
                    Console.WriteLine("Введите порт сервера");
                    int port = 7000;//Convert.ToInt32(Console.ReadLine());

                    try
                    {
                        Server.ServerStart(port);
                        Console.WriteLine("Сервер запущен на " + port + " порту");
                    }
                    catch (Exception e)
                    {
                        Server.ServerStop();
                        Console.WriteLine("Ошибка запуска сервера, возможно данный порт занят. " + e.Message);
                    }
                }

                while (true)
                {
                    TcpClient clientSocket;
                    Server.ClientConnecting(out clientSocket);

                   

                    Thread connectionThread = new Thread(new ParameterizedThreadStart(ClientThread));
                    connectionThread.Start(clientSocket);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        enum Code : byte
        {
            VerificationUser = 1,
            SuccessVerification = 2,
            FailVerification = 3,
            GetOrders = 10,
            Post = 100,
            Get = 201
        }

        private static Request Selector(Request inputRequest, User user)
        {
            switch (inputRequest.ExecuteCode)
            {
                case (byte)Code.VerificationUser:
                    Query query;
                    if(user.Verification(inputRequest.RequestBody, dataBaseServer, out query))
                    {
                        DataBase clientDB = new DataBase(user.Role, "3520189");
                        user.ConnectionDB = clientDB.Connection;
                        Users.Add(user.IP, user);
                        return new Request((byte)Code.SuccessVerification, query.ToBytes(), BitConverter.GetBytes(query.ToBytes().Length));
                    }
                    else
                    {
                        return new Request((byte)Code.FailVerification, query.ToBytes(), BitConverter.GetBytes(query.ToBytes().Length));
                    }

                case (byte)Code.Get:
                    Query getQuery = Query.ToQuery(inputRequest.RequestBody);
                    TableQuery tableQuery = new TableQuery(user.ConnectionDB);
                    getQuery.Execute(tableQuery);
                    byte[] outputRequest = getQuery.ToBytes();
                    return new Request((byte)Code.Get, outputRequest, BitConverter.GetBytes(outputRequest.Length));
            }

            return new Request("Code Error");
        }

        private static void ClientThread(object clientSocket)
        {
            Client client = new Client((TcpClient)clientSocket);
            
            if (Users.ContainsKey(client.IPClient))
            {
                Console.WriteLine("Клиент отключен");
                client.ClientClose();
                return;
            }

            Console.WriteLine("Клиент подключен: " + client.IPClient);

            User user = new User(client);
            user.IP = client.IPClient;

            while (client.socket.Connected)
            {

                Request inputRequest = client.ReadRequest();

                if (inputRequest.ExecuteCode == 255)
                {
                    Users.Remove(user.IP);
                    Console.WriteLine(inputRequest.ExecuteCode + " - код выполнения;\n" + BitConverter.ToInt32(inputRequest.Length, 0) + " - длина сообщения;\n" + inputRequest.ToString() + " - сообщение.");
                    Console.WriteLine($"{user.IP}: Клиент отключен");
                    user.RemoveUser();
                    return;
                }

                Console.WriteLine(inputRequest.ExecuteCode + " - код выполнения;\n" + BitConverter.ToInt32(inputRequest.Length, 0) + " - длина сообщения;\n" + inputRequest.ToString() + " - сообщение.");

                Request outputRequest = Selector(inputRequest, user);

                if (outputRequest.ExecuteCode == (byte)Code.FailVerification)
                {
                    client.PostRequest(outputRequest);
                    Users.Remove(user.IP);
                    user.RemoveUser();
                }
                else
                    client.PostRequest(outputRequest);
                    
                if (client.socket.Connected == false)
                {
                    Users.Remove(user.IP);

                    foreach (var item in Users)
                    {
                        Console.WriteLine(item.Key);
                    }

                    return;
                }
            }
        }
    }
}
