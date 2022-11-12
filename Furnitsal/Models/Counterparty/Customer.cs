using DbQuery;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Furnitsal.Models.Counterparty
{
    public class Customer
    {
        public int id;
        public string address;
        public string full_name;
        public string phone_number;
        public string extra_info;

        public Query Insert(Query query, QueryExec executor)
        {
            query.AddSql(Constants.InsertClient);
            query.AddParam("full_name", full_name);
            query.AddParam("address", address);
            query.AddParam("phone_number", phone_number);

            query.Execute(executor);

            id = Convert.ToInt32(query.ExtraInformation[0]);

            return query;
        }

    }
}
