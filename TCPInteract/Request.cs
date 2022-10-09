using System;
using System.IO;
using System.Text;

namespace TCPInteract
{
    public class Request
    {
        public byte ExecuteCode;
        public byte[] Length;
        public byte[] RequestBody;

        private bool _file;

        public Request(byte executeCode, byte[] requestBody, byte[] length, bool file = false)
        {
            _file = file;
            ExecuteCode = executeCode;
            Length = length;
            RequestBody = requestBody;
        }

        public Request(string requestBody, byte executeCode = 255, bool file = false)
        {
            _file = file;
            ExecuteCode = executeCode;
            RequestBody = Message(requestBody);
            Length = BitConverter.GetBytes(RequestBody.Length);

        }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(RequestBody);
        }

        private byte[] PreparingFile(string pathFile)
        {
            return File.ReadAllBytes(pathFile);
        }

        private byte[] PreparingMessage(string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }

        private byte[] Message(string requestBody)
        {
            if (_file)
            {
                return PreparingFile(requestBody);
            }
            else
            {
                return PreparingMessage(requestBody);
            }
        }
    }
}
