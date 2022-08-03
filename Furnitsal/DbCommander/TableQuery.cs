using DbQuery;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPInteraction;

namespace Furnitsal.DbCommander
{
    class TableQuery : IQueryExecutor
    {
        public DataSet TableData;
        public byte ExecuteCode;
        public Query QueryTarget { get; set; }

        private readonly Client _client;

        public TableQuery(Client client, byte executeCode, Query query)
        {
            ExecuteCode = executeCode;
            _client = client;
            QueryTarget = query;
        }

        public void Execute()
        {
            byte[] outputRequest = QueryTarget.ToBytes();
            _client.PostRequest(new Request(ExecuteCode, outputRequest, BitConverter.GetBytes(outputRequest.Length)));

            Request inputRequest = _client.ReadRequest();
            Query inputQuery = Query.ToQuery(inputRequest.RequestBody);

            QueryTarget.QueryResult = inputQuery.QueryResult;
            QueryTarget.ExecuteCode = inputQuery.ExecuteCode;

            TableData = new DataSet();
            MemoryStream stream = new MemoryStream(QueryTarget.QueryResult[0]);
            TableData.ReadXml(stream);
        }
    }
}