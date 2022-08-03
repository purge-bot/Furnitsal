using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbQuery
{
    public interface IQueryExecutor
    {
        Query QueryTarget { get; set; }

        void Execute();

    }
}
