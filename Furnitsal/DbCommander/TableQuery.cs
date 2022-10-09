using DbQuery;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPInteract;

namespace Furnitsal.DbCommander
{
    class TableQuery : QueryExec
    {
        public byte ExecuteCode;

        private readonly Client _client;

        public TableQuery(Client client, byte executeCode)
        {
            ExecuteCode = executeCode;
            _client = client;
        }

        protected override void ImplementExec(Query query)
        {
            PostQuery(query);

            ReadQuery(query);
        }

        private void PostQuery(Query query)
        {
            byte[] outputRequest = query.ToBytes();
            _client.PostRequest(new Request(ExecuteCode, outputRequest, BitConverter.GetBytes(outputRequest.Length)));
        }

        private void ReadQuery(Query query)
        {
            Request inputRequest = _client.ReadRequest();
            Query inputQuery = Query.ToQuery(inputRequest.RequestBody);

            query.TableResult = inputQuery.TableResult;
            query.ExecuteCode = inputQuery.ExecuteCode;
        }
    }
}