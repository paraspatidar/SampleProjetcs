using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyLibrary.Exceptions
{
    class InvalidRomanNumberException :Exception
    {
        public InvalidRomanNumberException()
        : base("Invalid Roman!! I have no idea what you are talking about")
        {
        }
    }
}
