using DbQuery;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PostgrServer.DbCommander
{
    class ColumnQuery : IQueryExecutor
    {
        public Query QueryTarget { get; set; }

        private readonly NpgsqlConnection _connection;

        public ColumnQuery(NpgsqlConnection connection, Query query)
        {
            _connection = connection;
            QueryTarget = query;
        }

        public void Execute()
        {
            QueryTarget.QueryResult = new List<byte[]>();
            using (NpgsqlCommand command = new NpgsqlCommand(QueryTarget.SqlQuery, _connection))
            {
                command.Parameters.AddRange(QueryTarget.CollectionParameters.ToArray());

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        QueryTarget.ExtraInformation.Add(reader.FieldCount.ToString());
                        int fieldCount = reader.FieldCount;
                        for (int i = 0; i < fieldCount; i++)
                        {
                            Stream stream = reader.GetStream(i);
                            byte[] buffer = new byte[stream.Length];
                            stream.Read(buffer, 0, (int)stream.Length);
                            QueryTarget.QueryResult.Add(buffer);
                            stream.Close();
                        }
                    }
                }
            }
        }
    }
}
