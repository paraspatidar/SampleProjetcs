using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyLibrary.Exceptions
{
    class QueryConfigurationNotFoundException : Exception
    {
        public QueryConfigurationNotFoundException()
        : base("Unable to Initilize Query Configuration , Check is configuration file is at correct location.")
        {
        }
    }
}
