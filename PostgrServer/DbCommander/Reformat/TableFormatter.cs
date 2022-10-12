using DbQuery;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PostgrServer.DbCommander.Reformat
{
    public class TableFormatter
    {
        private NpgsqlConnection _dbConnection;

        public TableFormatter(NpgsqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void ReformatTable(DataTable targetTable)
        {
            Query query = new Query();
            foreach (DataColumn item in targetTable.Columns)
            {
                string tableName = FindTableName(query, item.ColumnName);

                string columnNameFromDescription = FindColumnDescription(query, tableName, item.ColumnName);
                if (columnNameFromDescription != null)
                    item.ColumnName = columnNameFromDescription;
            }
        }

        private string FindTableName(Query query, string columnName)
        {
            query.AddSql(Constants.TableNameByColumn);
            NpgsqlParameter parameter = new NpgsqlParameter("column_name", columnName);
            query.CollectionParameters.Add(parameter);
            query.Execute(new TableQuery(_dbConnection));
            query.Clear();
            return query.TableResult.Rows[0].Field<string>("table_name");
        }

        private string FindColumnDescription(Query query, string tableName, string columnName)
        {
            query.AddSql(Constants.ColumnDescription);
            NpgsqlParameter tableParameter = new NpgsqlParameter("table_name", tableName);
            query.CollectionParameters.Add(tableParameter);  
            NpgsqlParameter columnParameter = new NpgsqlParameter("column_name", columnName);
            query.CollectionParameters.Add(columnParameter);
            query.Execute(new TableQuery(_dbConnection));
            query.Clear();
            try
            {
                return query.TableResult.Rows[0].Field<string>("description");
            }
            catch
            {
                return null;
            }
        }
    }
}
