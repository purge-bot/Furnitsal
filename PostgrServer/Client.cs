using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
//using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Imaging;

namespace PostgrServer
{
    class Client
    {
        private const int AUTHORIZE_SUCCESS = 100;
        private const int AUTHORIZE_FAIL = 101;
        private const int NORMAL_EXECUTION = 200;

        public int executeCode;

        public TcpClient socket;
        public string IPClient { get { try { return Convert.ToString(((IPEndPoint)socket.Client.RemoteEndPoint).Address); } catch { return "client not found"; } } }
        public DataBase userDB;

        private NetworkStream _stream { get { return socket.GetStream(); } }

        public Client(TcpClient client)
        {
            socket = client;
        }

        public void ConnectDataBase()
        {
            if (Server.CheckUserExist())
            {
                userDB = new DataBase();
                executeCode = AUTHORIZE_SUCCESS;
            }
            else
            {
                executeCode = AUTHORIZE_FAIL;
            }
        }

        public Request ReadRequest()
        {
            try
            {
                byte[] buffer = new byte[4];

                _stream.Read(buffer, 0, buffer.Length);
                byte executeCode = buffer[0];
                Array.Clear(buffer, 0, buffer.Length);

                _stream.Read(buffer, 0, buffer.Length);
                int length = BitConverter.ToInt32(buffer, 0);
                Array.Clear(buffer, 0, buffer.Length);

                if (length > 90000)
                {
                    ClientClose();
                    return new Request(1, BitConverter.GetBytes(1), BitConverter.GetBytes(1));
                }

                byte[] request = new byte[length];
                int total = 0;

                do
                {
                    total += socket.Client.Receive(request, length - total, SocketFlags.None);
                }
                while (total < length && _stream.DataAvailable);
                
                _stream.Flush();

                return new Request(executeCode, request, BitConverter.GetBytes(length));
            }
            catch (Exception e)
            {
                ClientClose();
                return new Request(e.Message);
            }          
        }

        public void PostRequest(Request request)
        {
            try
            {
                byte[] executeCode = new byte[4] { request.ExecuteCode, 0, 0, 0 };

                _stream.Write(executeCode, 0, executeCode.Length);
                _stream.Flush();

                _stream.Write(request.Length, 0, request.Length.Length);
                _stream.Flush();

                _stream.Write(request.RequestBody, 0, request.RequestBody.Length);
                _stream.Flush();
            }
            catch (Exception)
            {
                ClientClose();
            }
        }

        public void ClientClose()
        {
            if (userDB != null)
                userDB.ConnectionClose();

            socket.Close();
        }
    }
}
