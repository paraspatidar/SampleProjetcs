using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyLibrary
{
    class RomanMappingNotFoundException : Exception
    {
         public RomanMappingNotFoundException(string message)
        : base("Corrosponding delcaration not found for :"+message)
        {
        }
    }
}
