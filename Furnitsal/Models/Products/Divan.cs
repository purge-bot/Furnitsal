using DbQuery;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnitsal.Models.Products
{
    public class Divan : BaseProduct
    {
        public string fasteners_type { get; set; }
        public string softness_name { get; set; }
        public string mechanism { get; set; }
        public int back_degree { get; set; }
        public string textile_name { get; set; }

        new public Query Insert(Query query, QueryExec executor)
        {
            query.AddSql(Constants.InsertDivan);
            query.AddParam("article", article);
            query.AddParam("fasteners_type", fasteners_type);
            query.AddParam("softness_name", softness_name);
            query.AddParam("mechanism", mechanism);
            query.AddParam("back_degree", back_degree);
            query.AddParam("textile_name", textile_name);

            query.Execute(executor);

            return query;
        }
    }
}
