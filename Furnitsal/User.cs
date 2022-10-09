using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Npgsql;
using DbQuery;
using Furnitsal.DbCommander;
using Furnitsal.Cript;
using TCPInteract;

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
            TableQuery executor = new TableQuery(Connection, ((byte)ExecuteCode.VerificationUser));
            query.Execute(executor);

            return query.ExecuteCode == ((byte)ExecuteCode.VerificationSuccess);
        }
    }
}
