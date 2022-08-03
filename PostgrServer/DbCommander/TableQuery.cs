using DbQuery;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace PostgrServer.DbCommander
{
    internal class TableQuery : IQueryExecutor
    {
        public Query QueryTarget { get; set; }

        private NpgsqlConnection _connection;

        public TableQuery(NpgsqlConnection connection, Query query)
        {
            QueryTarget = query;
            _connection = connection;
        }


        public void Execute()
        {
            using (NpgsqlCommand command = new NpgsqlCommand(QueryTarget.SqlQuery, _connection))
            {
                command.Parameters.AddRange(QueryTarget.CollectionParameters.ToArray());
                QueryTarget.QueryResult = new List<byte[]>();
                MemoryStream memoryStream = new MemoryStream();
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                {
                    DataSet dataSet = new DataSet();
                    int i = adapter.Fill(dataSet);
                    dataSet.WriteXml(memoryStream);
                    QueryTarget.QueryResult.Add(memoryStream.ToArray());
                }
                memoryStream.Close();
            }
        }
    }
}
