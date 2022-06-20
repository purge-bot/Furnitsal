using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;


namespace Furnitsal
{
    public class DataBase
    {
        public NpgsqlConnection connection;
        public string Ip;
        public string Port;

        public DataBase(string ip, string port)
        {
            Ip = ip.Trim();
            Port = port.Trim();
        }

        /// <summary> Создание подключения к БД </summary>
        public bool Connect(User user)
        {
            if (user == null)
                return false;

            string connectionParam = $"Server={Ip};Port={Port};UserId=manager;Password=3520189;Database=shop";

            connection = new NpgsqlConnection(connectionParam);

            try
            {
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool VerverifyingUser(string login, string password, string ip, string port)
        {
            bool result;
            string connectionParamLoginer = $"Server={ip};Port={port};UserId=administrator;Password=wxkmjdt76;Database=shop";

            string sqlCheckUser = $"SELECT login, id FROM managers where login = :login";

            connection = new NpgsqlConnection(connectionParamLoginer);

            connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand(sqlCheckUser, connection))
            {
                var a = command.CreateParameter();
                a.ParameterName = "login";
                a.Value = login;
                command.Parameters.Add(a);
                int b;
                string val;
                string val1;
                NpgsqlDataReader reader = command.ExecuteReader();
                 while (reader.Read())
                {
                    b = reader.FieldCount;
                    val = reader.GetString(0);
                    val1 = Convert.ToString(reader.GetInt32(1));
                    if (val == login)
                    { 
                        //break;
                    }
                    else
                    {
                        connection.Close();
                    }
                }

                if (connection.State == System.Data.ConnectionState.Open)
                { 
                    connection.Close();
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }


    }
}