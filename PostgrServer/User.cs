using DbQuery;
using Npgsql;
using PostgrServer.DbCommander;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Linq;
using System.Data;

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
            TableQuery executor = new TableQuery(dataBase.Connection);
            query.Execute(executor);

            if (query.TableResult.Rows.Count == 0)
            {
                query.ExecuteCode = 3;
                return false;
            }

            if (query.TableResult.Rows[0].Field<string>("password") == query.ExtraInformation[1])
            {
                query.ExecuteCode = 2;
                Login = query.TableResult.Rows[0].Field<string>("login");
                Role = query.TableResult.Rows[0].Field<string>("role");
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
