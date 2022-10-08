using DbQuery;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace PostgrServer.DbCommander
{
    internal class TableQuery : QueryExec
    {
        private NpgsqlConnection _connection;

        public TableQuery(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        protected override void ImplementExec(Query query)
        {
            using (NpgsqlCommand command = new NpgsqlCommand(query.SqlQuery, _connection))
            {
                command.Parameters.AddRange(query.CollectionParameters.ToArray());
                MemoryStream memoryStream = new MemoryStream();
                using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command))
                {
                    DataSet Table = new DataSet();
                    int i = adapter.Fill(Table);
                    Table.WriteXml(memoryStream);
                    query.TableResult = Table.Tables[0];
                }
                memoryStream.Close();
            }
        }
    }
}
