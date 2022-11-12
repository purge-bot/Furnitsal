using DbQuery;
using Furnitsal.Models.Counterparty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnitsal.Models
{
    public class Order
    {
        public int id;
        public string manager_login { get; set; }
        public string submanager_login { get; set; }
        public int id_client { get; set; }
        public string status_order { get; set; }

        public Query Insert(Query query, QueryExec executor)
        {
            query.AddSql(Constants.InsertOrder);
            query.AddParam("manager_login", manager_login);
            query.AddParam("status_order", status_order);
            query.AddParam(":id_client", id_client);

            query.Execute(executor);

            id = Convert.ToInt32(query.ExtraInformation[0]);

            return query;
        }
    }
}
