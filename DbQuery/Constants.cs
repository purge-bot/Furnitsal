using System;
using System.Collections.Generic;
using System.Text;

namespace DbQuery
{
    public static class Constants
    {
        public const string VerifyUser = "SELECT login, password, role FROM checkuser.managers where login = :login";

        public const string TableNameByColumn = "select table_name from information_schema.columns where column_name = :column_name";

        public const string ColumnDescription =
            "select d.description " +
            "from pg_catalog.pg_description d " +
            "join pg_catalog.pg_statio_all_tables t on (t.relid = d.objoid) " +
            "join information_schema.columns c on (c.ordinal_position = d.objsubid) " +
            "where t.relname = :table_name and c.column_name = :column_name";

        public const string GetOrderProducts = "select product.article, lenght, width, edge_size, has_drawing, type_name, quantity from product " +
            "join order_structure on product.article = order_structure.article " +
            "join product_type on product.type_code = product_type.type_code " +
            "where order_structure.id_order = :id_order;";

        public const string GetProductType = "select type_name from product_type";

        public const string InsertClient = "INSERT INTO clients (full_name, address, phone_number) " +
            "Values(:full_name, :address, :phone_number) returning id;";

        public const string InsertOrder = "insert into orders(manager_login, id_client, status_order)" +
            " Values (:manager_login, :id_client, :status_order) returning id;";

        public const string InsertProduct = "insert into product (type_code, product_name, lenght, width, edge_size) " +
                    "Values ((select type_code from product_type where type_name = :type_name), " +
                    ":product_name, :lenght, :width, :edge_size) returning article; ";

        public const string InsertDivan = "insert into divan (article, fasteners_type, softness_name, mechanism, back_degree, textile_name) " +
                       "Values (:article, :fasteners_type, :softness_name, :mechanism, :back_degree, :textile_name);";

        public const string InsertOrderStructure = "insert into order_structure (id_order, article, quantity) " +
                       "Values (:id_order, :article, :quantity);";
    }
}

