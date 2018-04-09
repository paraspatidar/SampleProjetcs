using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyLibrary
{
    class ConstantMappingNotFoundException : Exception
    {
         public ConstantMappingNotFoundException(string message)
        : base("Corrosponding calculative declaration  not found for :"+message)
        {
        }
    }
}
