using System.Collections.Generic;

namespace GalaxyLibrary.DataMapping
{
    public interface IDataMappingHolder
    {
         Dictionary<string, RomanNumber> RomanConstantsTable { get; set; }
         Dictionary<string, double> DeclarativeCalculationTable { get; set; }
    }
}