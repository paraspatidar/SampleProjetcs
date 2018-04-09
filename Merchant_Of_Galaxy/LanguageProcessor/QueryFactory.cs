using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor
{
    public abstract class QueryFactory
    {
        public abstract IQuery GetQueryType(string query);
    }
}
