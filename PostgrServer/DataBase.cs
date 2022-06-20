using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace PostgrServer
{
    public class DataBase
    {
        public string Ip { get; private set; }
        public string Port { get; private set; }
        public NpgsqlConnection Connection { get; private set; }

        public DataBase(string login = "Administrator", string password = "wxkmjdt76", string ip = "127.0.0.1", string port = "5432", string dataBaseName = "shop")
        {
            login = login.ToLower().Trim();
            password = password.Trim();
            ip = ip.Trim();
            port = port.Trim();
            dataBaseName = dataBaseName.ToLower().Trim();

            Connect(login, password, ip, port, dataBaseName);
        }

        public void Connect(string login = "Administrator", string password = "wxkmjdt76", string ip = "127.0.0.1", string port = "5432", string dataBaseName = "shop")
        {
            string connectionParam = $"Server={ip};Port={port};UserId={login};Password={password};Database={dataBaseName};Pooling=false";

            Connection = new NpgsqlConnection(connectionParam);

            Connection.Open();

        }

        public string Select()
        {
            return "1234123";
        }

        public void ConnectionClose()
        {
            Connection.Close();
        }
    }
}
