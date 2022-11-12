using DbQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnitsal.Models
{
    public class OrderStructure
    {
        public int id_order;
        public int article;
        public int quantity;

        public Query Insert(Query query, QueryExec executor)
        {
            query.AddSql(Constants.InsertOrderStructure);
            query.AddParam("id_order", id_order);
            query.AddParam("article", article);
            query.AddParam("quantity", quantity);
            query.Execute(executor);

            return query;
        }
    }
}
