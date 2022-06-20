using System;
using System.Collections.Generic;
using System.Text;

namespace PostgrServer.Models
{
   /* public class User
    {
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string LastName { get; private set; }
        public string Login { get; private set; }
        public string Role { get; private set; }

        private User(string login, DataBase dataBase)
        {
            Login = login;
        }

        public static User Instance(string login, string password, DataBase dataBase)
        {
            return Verification(login, password, dataBase) ? new User(login, dataBase) : null;
        }

        private static bool Verification(string login, string password, DataBase dataBase)
        {
            string connectionParamLoginer = $"Server={dataBase.Ip};Port={dataBase.Port};UserId=postgres;Password=wxkmjdt76;Database=shop";

            string sqlCheckUser = $"SELECT login, password FROM checkuser.managers where login = :login";

            dataBase.connection = new NpgsqlConnection(connectionParamLoginer);

            dataBase.connection.Open();

            using (NpgsqlCommand command = new NpgsqlCommand(sqlCheckUser, dataBase.connection))
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
                    val1 = reader.GetString(1);

                    if ((val == login) && (val1 == password))
                    {
                        dataBase.connection.Close();
                        return true;
                    }
                    else
                    {
                        dataBase.connection.Close();
                        return false;
                    }
                }

                dataBase.connection.Close();
                return false;
            }
        }
    }*/
}

