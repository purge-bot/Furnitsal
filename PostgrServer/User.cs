using Npgsql;
using PostgrServer.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostgrServer
{
    public class User : IDataBase
    {
        public string IP;
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string LastName { get; private set; }
        public string Login { get; private set; }
        public string Role { get; private set; }
        public NpgsqlConnection ConnectionDB { get; set; }

        private static string[] PrepareData(byte[] requestBody)
        {
            string request = Encoding.ASCII.GetString(requestBody);
            string[] loginPass = request.Split('|', 2, StringSplitOptions.None);
            return loginPass;
        }

        public bool Verification(byte[] requestBody, DataBase dataBase)
        {
            string[] loginPass = PrepareData(requestBody);
            string login = loginPass[0];
            string password = loginPass[1];

            using (NpgsqlCommand command = new NpgsqlCommand(Query.VerifyUser, dataBase.Connection))
            {
                var a = command.CreateParameter();
                a.ParameterName = "login";
                a.Value = login;
                command.Parameters.Add(a);

                int b;
                string val;
                string val1;
                string val2;

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        b = reader.FieldCount;
                        val = reader.GetString(0);
                        val1 = reader.GetString(1);
                        val2 = reader.GetString(2);

                        if ((val == login) && (val1 == password))
                        {
                            Login = login;
                            Role = val2;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }


                    return false;
                }
            }
        }
    }
}
