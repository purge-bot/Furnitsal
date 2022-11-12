using DbQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPInteract;

namespace Furnitsal.DbCommander
{
    class NonQuery : QueryExec
    {
        public byte ExecuteCode;

        private readonly Client _client;

        public NonQuery(Client client, byte executeCode)
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

            query.ExtraInformation = inputQuery.ExtraInformation;
            query.ExecuteCode = inputQuery.ExecuteCode;
        }
    }
}
