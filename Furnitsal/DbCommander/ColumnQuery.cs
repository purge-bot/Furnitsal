using DbQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPInteraction;

namespace Furnitsal.DbCommander
{
    class ColumnQuery : IQueryExecutor
    {
        public Query QueryTarget { get; set; }
        public byte ExecuteCode;
        private readonly Client _client;

        public ColumnQuery(Client client, byte executeCode, Query query)
        {
            ExecuteCode = executeCode;
            _client = client;
            QueryTarget = query;
        }

        public void Execute()
        {
            GetQueryResult();
        }

        private void GetQueryResult()
        {
            byte[] outputRequest = QueryTarget.ToBytes();
            _client.PostRequest(new Request(ExecuteCode, outputRequest, BitConverter.GetBytes(outputRequest.Length)));

            Request inputRequest = _client.ReadRequest();
            Query inputQuery = Query.ToQuery(inputRequest.RequestBody);

            QueryTarget.QueryResult = inputQuery.QueryResult;
            QueryTarget.ExecuteCode = inputQuery.ExecuteCode;
        }
    }
}
