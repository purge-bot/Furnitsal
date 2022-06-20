using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace PostgrServer
{
    class Program
    {
        public static DataBase dataBase;
        public static Dictionary<string, User> Users = new Dictionary<string, User>();

        static void Main(string[] args)
        {
            try
            {
                //while (Server.DataBaseConnection == null)
                // {
                Console.WriteLine("Подключение к базе данных");
                Console.WriteLine("Введите логин");
                string loginDB = "postgres";// Console.ReadLine().ToLower().Trim();

                Console.WriteLine("Введите пароль");
                string passwordDB = "wxkmjdt76";//Console.ReadLine().ToLower().Trim();

                try
                {
                    dataBase = new DataBase(loginDB, passwordDB);
                    Console.WriteLine("Подключено к БД");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                //}

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
            Post = 101,
            Get = 201
        }

        public static bool Selector(byte executeCode, byte[] requestBody, User user)
        {
            switch (executeCode)
            {
                case (byte)Code.VerificationUser:
                    
                    if(user.Verification(requestBody, dataBase))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }    
                case (byte)Code.Post:
                    return false;

            }
            return false;
        }

        static void ClientThread(object clientSocket)
        {
            Client client = new Client((TcpClient)clientSocket);
            Console.WriteLine("Клиент подключен: " + client.IPClient);

            User user = new User();
            DataBase clientDB;

            while (client.socket.Connected)
            {

                Request inputRequest = client.ReadRequest();

                if (Users.ContainsKey(client.IPClient))
                {
                    Console.WriteLine("Клиент отключен");
                    client.ClientClose();
                    return;
                }

                if (inputRequest.ExecuteCode == 255)
                {
                    user.ConnectionDB?.Close();
                    Console.WriteLine("Клиент отключен");
                    client.ClientClose();
                    return;
                }

                Console.WriteLine(inputRequest.ExecuteCode + " - код выполнения;\n" + BitConverter.ToInt32(inputRequest.Length, 0) + " - длина сообщения;\n" + inputRequest.ToString() + " - сообщение.");

                if (Enum.IsDefined(typeof(Code), inputRequest.ExecuteCode))
                {
                    if (Selector(inputRequest.ExecuteCode, inputRequest.RequestBody, user))
                    {
                        clientDB = new DataBase();
                        clientDB.Connect(user.Role, "3520189");
                        user.ConnectionDB = clientDB.Connection;
                        client.PostRequest(new Request("Done!", false, (byte)Code.SuccessVerification));
                        Users.Add(client.IPClient, user);
                        foreach (var item in Users)
                        {
                            Console.WriteLine(item.Key);
                        }
                    } 
                    else
                    {
                        client.PostRequest(new Request("Fail!", false, (byte)Code.FailVerification));
                    }
                }

                if (client.socket.Connected == false)
                {
                    Users.Remove(client.IPClient);

                    foreach (var item in Users)
                    {
                        Console.WriteLine(item.Key);
                    }

                    return;
                }

                /*if (client.userDB == null && inputRequest.ExecuteCode == 100)
                {
                    client.ConnectDataBase();
                    client.PostRequest(new Request("Success connection"));
                    client.socket.ReceiveTimeout = 0;
                }
                else
                {
                    if (inputRequest.ExecuteCode == 1)
                        client.PostRequest(new Request(@"C:\Users\Anton\Desktop\shop\qwert.png", true));
                    else
                        client.PostRequest(new Request("Message"));
                }*/
            }
        }
    }
}
