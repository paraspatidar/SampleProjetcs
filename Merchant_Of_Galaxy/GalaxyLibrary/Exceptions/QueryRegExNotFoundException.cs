using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyLibrary.Exceptions
{
    class QueryRegExNotFoundException : Exception
    {
        public QueryRegExNotFoundException()
        : base("Unable to find Reg Ex for this query.")
        {
        }
    }
}
