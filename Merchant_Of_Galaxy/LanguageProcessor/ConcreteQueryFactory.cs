using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor
{
    class ConcreteQueryFactory : QueryFactory
    {
        public override IQuery GetQueryType(string query)
        {
            throw new NotImplementedException();
        }
    }
}
