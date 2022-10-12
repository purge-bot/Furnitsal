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
    }
}

