using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Npgsql;
using TCPInteraction;
using DbQuery;
using Furnitsal.DbCommander;
using Furnitsal.Cript;

namespace Furnitsal
{
    public class User
    {
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string LastName { get; private set; }
        public string Login { get; private set; }
        public string Role { get; private set; }
        public Client Connection { get; private set; }

        public User(Client client)
        {
            Connection = client;
        }

        public bool Verification(string login, string password)
        {
            List<string> extraData = new List<string>();
            extraData.Add(login);
            extraData.Add(CriptString.GetHash(password));

            Query query = new Query(extraData);
            query.AddSql(Constants.VerifyUser);
            query.AddParam("login", login);
            ColumnQuery columnQuery = new ColumnQuery(Connection, 1, query);
            query.Execute(columnQuery);

            if (query.ExecuteCode == 2)
            {
                return true;
            }
            else
                return false;
        }
    }
}
