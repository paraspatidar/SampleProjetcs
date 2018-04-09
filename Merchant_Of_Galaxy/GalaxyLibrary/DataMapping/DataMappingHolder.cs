using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxyLibrary.DataMapping
{
    class DataMappingHolder : IDataMappingHolder
    {

        public Dictionary<string, RomanNumber> RomanConstantsTable { get; set; }
        public Dictionary<string, double> DeclarativeCalculationTable { get; set; }
        public DataMappingHolder()
        {
            RomanConstantsTable = new Dictionary<string, RomanNumber>();
            DeclarativeCalculationTable = new Dictionary<string, double>();
        }

      
    }
}
