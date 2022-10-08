using System;
using System.Collections.Generic;
using System.Text;

namespace DbQuery
{
    public abstract class QueryExec
    {
        internal void Execute(Query targetQuery) { ImplementExec(targetQuery); }

        protected abstract void ImplementExec(Query query);
    }
}
