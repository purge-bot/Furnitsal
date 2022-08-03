using System;
using System.Net;
using System.Net.Sockets;

namespace TCPInteraction
{
   public class Client
    {
        public TcpClient socket;
        public string IPClient { get { try { return Convert.ToString(((IPEndPoint)socket.Client.RemoteEndPoint).Address); } catch { return "client not found"; } } }

        private NetworkStream _stream { get { return socket.GetStream(); } }

        public Client(TcpClient client)
        {
            socket = client;
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
                    return new Request("");
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

        private void ClientClose()
        {
            Console.WriteLine("\nКлиент отключен:  " + IPClient);
            socket.Close();
        }
    }
}
