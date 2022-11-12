using DbQuery;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnitsal.Models.Products
{
    public abstract class BaseProduct
    {
        public int article { get; set; }
        public string type_name { get; set; }
        public string product_name { get; set; }
        public int length { get; set; }
        public int width { get; set; }
        public double edge_size { get; set; }
        public bool has_drawing { get; set; }
        public string constructor_login { get; set; }
        public int quantity;

        public Query Insert(Query query, QueryExec executor)
        {
            query.AddSql(Constants.InsertProduct);
            query.AddParam("type_name", type_name);
            query.AddParam("product_name", product_name);
            query.AddParam("lenght", length);
            query.AddParam("width", width);
            query.AddParam("edge_size", edge_size);

            query.Execute(executor);

            article = Convert.ToInt32(query.ExtraInformation[0]);

            return query;
        }
    }
}
