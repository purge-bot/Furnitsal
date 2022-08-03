using DbQuery;
using Npgsql;
using PostgrServer.DbCommander;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace PostgrServer
{
    public class User
    {
        public string IP;
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string LastName { get; private set; }
        public string Login { get; private set; }
        public string Role { get; private set; }

        public NpgsqlConnection ConnectionDB { get; set; }
        public Client ConnectionClient;

        public User (Client client)
        {
            ConnectionClient = client;
        }

        public bool Verification(byte[] requestBody, DataBase dataBase, out Query query)
        {
            query = Query.ToQuery(requestBody);
            ColumnQuery columnQuery = new ColumnQuery(dataBase.Connection, query);
            query.Execute(columnQuery);

            if (query.QueryResult.Count > 0 && (Encoding.UTF8.GetString(query.QueryResult[0]) == query.ExtraInformation[0]) && (Encoding.UTF8.GetString(query.QueryResult[1]) == query.ExtraInformation[1]))
            {
                Login = Encoding.UTF8.GetString(query.QueryResult[0]);
                Role = Encoding.UTF8.GetString(query.QueryResult[2]);
                query.ExecuteCode = 2;
                return true;
            }
            else
            {
                query.ExecuteCode = 3;
                return false;
            }
        }

        public void RemoveUser()
        {
            ConnectionDB?.Close();
            ConnectionClient?.ClientClose();
        }
    }
}
