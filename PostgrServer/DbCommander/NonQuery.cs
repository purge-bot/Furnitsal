using DbQuery;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostgrServer.DbCommander
{
    class NonQuery : QueryExec
    {
        private NpgsqlConnection _connection;

        public NonQuery(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        protected override void ImplementExec(Query query)
        {
            using (NpgsqlCommand command = new NpgsqlCommand(query.SqlQuery, _connection))
            {
                command.Parameters.AddRange(query.CollectionParameters.ToArray());
                try
                {
                    query.ExtraInformation.Add(command.ExecuteScalar()?.ToString());

                }
                catch (Exception)
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
