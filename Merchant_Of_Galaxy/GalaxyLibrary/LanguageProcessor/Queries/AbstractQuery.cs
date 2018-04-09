using GalaxyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageProcessor
{
    abstract class AbstractQuery
    {
    
        public QueryConfiguration QueryConfiguration { get; set; }
        public string query { get; set; }

       
    }
}
