using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyLibrary
{
    class InValidQueryException : Exception
    {
         public InValidQueryException()
        : base("I have no idea what you are talking about")
        {
        }
    }
}
